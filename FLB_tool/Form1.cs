using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

/*
 * Final Fantasy VI .FLB tool
 * Made by Maki (Marcin Gomulak)
 * Feel free to contact me on makipol@gmail.com
 * See me on github.com/makipl
 * 
 */

namespace FLB_tool
{
    public partial class Form1 : Form
    {
        private uint[] imchSpritePointers;
        private uint imchPointer;
        private Bitmap[] sprites;
        private string lastOpenPath;
        private List<FLBUIPosition> uiPositions;

        uint[] indices;
        ushort width = 0;
        ushort height = 0;

        uint SHCH;
        uint SPCH;
        uint BTCH;
        uint ANCH0;

        public Form1()
        {
            InitializeComponent();
        }

        private void File_DragDrop(object sender, DragEventArgs e)
        {
            lastOpenPath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            LoadFLBFile(lastOpenPath);
        }

        private void File_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathFilename;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Final Fantasy VI FLB (*.FLB)|*.FLB";
                ofd.ShowDialog();
                ofd.Multiselect = false;
                if (string.IsNullOrWhiteSpace(ofd.FileName)) return;
                pathFilename = ofd.FileName;
            }
            lastOpenPath = pathFilename;

            LoadFLBFile(pathFilename);
        }

        private void LoadFLBFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            if (Encoding.UTF8.GetString(br.ReadBytes(4), 0, 4) != "FLBD") { MessageBox.Show("Wrong or corrupted FLB file"); return; }
            fs.Seek(4, SeekOrigin.Current); //pass 0101
            uint headerSize = br.ReadUInt32();
            fs.Seek(8, SeekOrigin.Current); //pass section count
            imchPointer = br.ReadUInt32() + headerSize;
            SHCH = br.ReadUInt32() + headerSize;
            SPCH = br.ReadUInt32() + headerSize;
            BTCH = br.ReadUInt32() + headerSize;
            ANCH0 = br.ReadUInt32() + headerSize;

            fs.Seek(imchPointer, SeekOrigin.Begin);
            if (Encoding.UTF8.GetString(br.ReadBytes(4), 0, 4) != "IMCH") { MessageBox.Show("Wrong or corrupted FLB file"); return; }
            uint imchSize = br.ReadUInt32();
            uint imchSpriteSize = br.ReadUInt32();
            imchSpritePointers = new uint[imchSpriteSize];
            indices = new uint[imchSpriteSize];
            sprites = new Bitmap[imchSpriteSize];
            for (int i = 0; i < imchSpriteSize; i++)
            {
                uint pointer = br.ReadUInt32();
                imchSpritePointers[i] = imchPointer + imchSize + pointer;
            }
            //==read sprites to bitmap==
            for (int i = 0; i < imchSpritePointers.Length; i++)
            {
                fs.Seek(imchSpritePointers[i] + 20, SeekOrigin.Begin);
                indices[i] = br.ReadUInt32();
                width = br.ReadUInt16();
                height = br.ReadUInt16();

                sprites[i] = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                BitmapData bmpData = sprites[i].LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                byte[] bmpBuffer = new byte[width * height * 4];
                for (int n = 0; n < width * height * 4; n += 4)
                {
                    uint pixel = br.ReadUInt32();
                    bmpBuffer[n] = (byte)(pixel >> 24 & 0xff);
                    bmpBuffer[n + 1] = (byte)(pixel >> 16 & 0xff);
                    bmpBuffer[n + 2] = (byte)(pixel >> 8 & 0xff);
                    bmpBuffer[n + 3] = (byte)(pixel & 0xff);
                }
                Marshal.Copy(bmpBuffer, 0, bmpData.Scan0, bmpBuffer.Length);
                sprites[i].UnlockBits(bmpData);
            }
            if (sprites.Length > 0)
                pictureBox2.Image = sprites[0];

            pictureBox2.Visible = true;

            listBox1.DataSource = indices;

            button1.Enabled = true;
            button2.Enabled = true;

            // Skip to ANCH0
            fs.Seek(ANCH0 + 16, SeekOrigin.Begin);
            uint uiPositionsPtr = br.ReadUInt32() + ANCH0 + 30 + 18;
            fs.Seek(4, SeekOrigin.Current);
            uint uiStringsPtr = br.ReadUInt32() + uiPositionsPtr - 4;
            fs.Seek(uiPositionsPtr, SeekOrigin.Begin);

            int count = br.ReadInt32(); // get number of position entries;
            uiPositions = new List<FLBUIPosition>(count);
            int[] uiItems = new int[count];

            for(int i = 0; i < count; i++)
            {
                uiPositions.Add(new FLBUIPosition() {
                    applyDeformation = br.ReadInt32(),
                    xScale = br.ReadSingle(),
                    yScale = br.ReadSingle(),
                    xSkew = br.ReadSingle(),
                    ySkew = br.ReadSingle(),
                    xPos = br.ReadInt32(),
                    yPos = br.ReadInt32()
                });

                uiItems[i] = i;
            }

            uiPositionsLB.DataSource = uiItems;


            // Read UI strings
            fs.Seek(uiStringsPtr, SeekOrigin.Begin);
            count = br.ReadInt32();
            var uiStrings = new List<string>(count);

            for(int i = 0; i < count; i++)
            {
                string s = Encoding.ASCII.GetString(br.ReadBytes(0x80));
                fs.Seek(4, SeekOrigin.Current);

                uiStrings.Add(s);
            }

            uiStringsLB.DataSource = uiStrings;

            fs.Close();
            fs.Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                pictureBox2.Image = sprites[(sender as ListBox).SelectedIndex];
                width = (ushort)pictureBox2.Image.Width;
                height = (ushort)pictureBox2.Image.Height;
                pictureBox2.Width = width;
                pictureBox2.Height = height;
                
            }
            catch { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null) return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG *.PNG|*.PNG", CheckPathExists = true })
            {
                sfd.ShowDialog();
                if (!string.IsNullOrWhiteSpace(sfd.FileName))
                {
                    if (File.Exists(sfd.FileName))
                    {
                        File.Delete(sfd.FileName);
                        pictureBox2.Image.Save(sfd.FileName, ImageFormat.Png);
                    }
                    else pictureBox2.Image.Save(sfd.FileName, ImageFormat.Png);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pngFilePath;
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PNG file (*.PNG)|*.PNG", Multiselect=false })
            {
                ofd.ShowDialog();
                if (string.IsNullOrWhiteSpace(ofd.FileName)) return;
                pngFilePath = ofd.FileName;
            }
            Image pngData = Image.FromFile(pngFilePath);

            if(pngData.PixelFormat != PixelFormat.Format32bppArgb)
            {
                MessageBox.Show("File you are trying to import is not either .PNG or is not 32 bit ARGB pixel format!");
                return;
            }
            Bitmap bmp = new Bitmap(pngData);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte[] buffer = new byte[bmpData.Height * bmpData.Width * 4];
            Marshal.Copy(bmpData.Scan0, buffer, 0, buffer.Length);

            bmp.UnlockBits(bmpData); //this unlocks png handle

            if (pngData.Width != width || pngData.Height != height)
                ReplaceDynamic(buffer, (ushort)bmpData.Width, (ushort)bmpData.Height);
            else
            {
                using (FileStream fs = new FileStream(lastOpenPath, FileMode.Open, FileAccess.ReadWrite))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    fs.Seek(int.Parse(listBox1.SelectedValue.ToString())+28, SeekOrigin.Begin);
                    for (int i = 0; i < buffer.Length; i += 4)
                    {
                        bw.Write(buffer[i+3]);
                        bw.Write(buffer[i + 2]);
                        bw.Write(buffer[i + 1]);
                        bw.Write(buffer[i+0]);
                    }
                }
            }
            MessageBox.Show("Replacing completed! Please pack the file to .gz or re-open the same file again to see changes.");
        }

        private void ReplaceDynamic(byte[] buffer, ushort newWidth, ushort newHeight) //buffer is the import image data
        {
            int pointerIndex = listBox1.SelectedIndex; //so we need to tweak all the pointers AFTER this one
            uint oldBufferSize = (uint)(width * height * 4); //naturally
            int bufferSizeDifference = (int)(buffer.Length - oldBufferSize); //when we import smaller image it naturally gets decreased
            uint shchTweaked = (uint)(SHCH + bufferSizeDifference);
            uint spchTweaked = (uint)(SPCH + bufferSizeDifference);
            uint btchTweaked = (uint)(BTCH + bufferSizeDifference);
            uint anch0Tweaked = (uint)(ANCH0 + bufferSizeDifference);


            //phase 1. Replace SPCH... pointers
            using (FileStream fs = new FileStream(lastOpenPath, FileMode.Open, FileAccess.ReadWrite))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                fs.Seek(0x18, SeekOrigin.Begin);
                bw.Write(shchTweaked);
                bw.Write(spchTweaked);
                bw.Write(btchTweaked);
                bw.Write(anch0Tweaked);

                //phase 2. Get to sprite pointer and tweak height and width
                fs.Seek(int.Parse(listBox1.SelectedValue.ToString()) + 24, SeekOrigin.Begin);
                bw.Write(newWidth);
                bw.Write(newHeight);                

                //phase 3. Get to IMCH and tweak pointers from currentIndex+1 if available and add via bufferSizeDifference
                fs.Seek(imchPointer+12, SeekOrigin.Begin);
                fs.Seek(listBox1.SelectedIndex * 4, SeekOrigin.Current);
                if (listBox1.SelectedIndex != listBox1.Items.Count-1) //some pointers need tweaking
                {
                    int maxListbox = listBox1.Items.Count - listBox1.SelectedIndex-1;
                    fs.Seek(4, SeekOrigin.Current);
                    for (int i = 0; i < maxListbox; i++)
                        bw.Write((uint)(imchSpritePointers[listBox1.SelectedIndex + i+1] + bufferSizeDifference-120)); //-120 because IMCH header + FLBD header
                }

            }

            //phase 4. Dump current-modified file and rebuild
            byte[] fullBuffer = File.ReadAllBytes(lastOpenPath);
            byte[] finalBuffer = new byte[fullBuffer.Length + bufferSizeDifference];
            int startCopyPointer = (int)imchSpritePointers[listBox1.SelectedIndex] + 28;
            Buffer.BlockCopy(fullBuffer, 0, finalBuffer, 0, startCopyPointer);

            for (int i = 0; i<buffer.Length; i+=4)
            {
                finalBuffer[startCopyPointer + i] = buffer[i+3];
                finalBuffer[startCopyPointer + i+1] = buffer[i + 2];
                finalBuffer[startCopyPointer + i+2] = buffer[i + 1];
                finalBuffer[startCopyPointer + i+3] = buffer[i];
            }


            if(imchSpritePointers.Length != 1) //more than one sprite
            {
                int dstOffset = (int)imchSpritePointers[listBox1.SelectedIndex] + 28 + buffer.Length;
                if (listBox1.SelectedIndex != listBox1.Items.Count-1)
                {
                    int cnt = fullBuffer.Length - (int)imchSpritePointers[listBox1.SelectedIndex + 1];
                    Buffer.BlockCopy(fullBuffer, (int)imchSpritePointers[listBox1.SelectedIndex + 1], finalBuffer, dstOffset, cnt);
                }
                else
                {
                    int cnt = fullBuffer.Length - (int)SHCH;
                    Buffer.BlockCopy(fullBuffer, (int)SHCH, finalBuffer, dstOffset, cnt-40);
                }
            }
            else
            {
                int dstOffset = (int)imchSpritePointers[listBox1.SelectedIndex] + buffer.Length;
                int cnt = fullBuffer.Length - (int)SHCH;
                Buffer.BlockCopy(fullBuffer, (int)SHCH, finalBuffer, dstOffset, cnt-12);
            }
            File.WriteAllBytes(lastOpenPath, finalBuffer);
        }

        private void uiPositionsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (sender as ListBox).SelectedIndex;
            xOffset.Value = (decimal)(uiPositions[index].xPos / 20.0);
            yOffset.Value = (decimal)(uiPositions[index].yPos / 20.0);
            xScale.Value = (decimal)uiPositions[index].xScale;
            yScale.Value = (decimal)uiPositions[index].yScale;
            xSkew.Value = (decimal)uiPositions[index].xSkew;
            ySkew.Value = (decimal)uiPositions[index].ySkew;

            applyDeform.Checked = (uiPositions[index].applyDeformation == 1);


            UpdateImage();
        }

        private void UpdateImage()
        {
            int index = uiPositionsLB.SelectedIndex;
            if (enableTransforming.Checked) 
            {
                pictureBox2.Location = new Point(uiPositions[index].xPos / 20, uiPositions[index].yPos / 20);
            } 
            else
            {
                pictureBox2.Location = new Point(0, 0);
            }

            if (applyDeform.Checked && enableTransforming.Checked)
            {
                pictureBox2.Width = (int)Math.Round(width * uiPositions[index].xScale);
                pictureBox2.Height = (int)Math.Round(height * uiPositions[index].yScale);
            }
            else
            {
                pictureBox2.Width = width;
                pictureBox2.Height = height;
            }
        }

        private void applyDeform_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = (sender as CheckBox).Checked;
            deformationGroup.Enabled = isChecked;

            int i = uiPositionsLB.SelectedIndex;
            uiPositions[i].applyDeformation = isChecked ? 1 : 0;
        }

        private void saveANCH0_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(lastOpenPath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);

            fs.Seek(ANCH0 + 16, SeekOrigin.Begin);
            uint uiPosPtr = br.ReadUInt32() + ANCH0 + 30 + 18;

            fs.Seek(uiPosPtr, SeekOrigin.Begin);

            int count = br.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                bw.Write(uiPositions[i].applyDeformation);
                bw.Write(uiPositions[i].xScale);
                bw.Write(uiPositions[i].yScale);
                bw.Write(uiPositions[i].xSkew);
                bw.Write(uiPositions[i].ySkew);
                bw.Write(uiPositions[i].xPos);
                bw.Write(uiPositions[i].yPos);
            }
            bw.Flush();
            fs.Close();
            fs.Dispose();
        }

        private void reloadANCH0_Click(object sender, EventArgs e)
        {
            int prevUIPosIndex = uiPositionsLB.SelectedIndex;
            int prevUIStringsIndex = uiStringsLB.SelectedIndex;

            FileStream fs = new FileStream(lastOpenPath, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);


            // Skip to ANCH0
            fs.Seek(ANCH0 + 16, SeekOrigin.Begin);
            uint uiPositionsPtr = br.ReadUInt32() + ANCH0 + 30 + 18;
            fs.Seek(4, SeekOrigin.Current);
            uint uiStringsPtr = br.ReadUInt32() + uiPositionsPtr - 4;
            fs.Seek(uiPositionsPtr, SeekOrigin.Begin);

            int count = br.ReadInt32(); // get number of position entries;
            uiPositions = new List<FLBUIPosition>(count);
            int[] uiItems = new int[count];

            for (int i = 0; i < count; i++)
            {
                uiPositions.Add(new FLBUIPosition()
                {
                    applyDeformation = br.ReadInt32(),
                    xScale = br.ReadSingle(),
                    yScale = br.ReadSingle(),
                    xSkew = br.ReadSingle(),
                    ySkew = br.ReadSingle(),
                    xPos = br.ReadInt32(),
                    yPos = br.ReadInt32()
                });

                uiItems[i] = i;
            }

            uiPositionsLB.DataSource = uiItems;


            // Read UI strings
            fs.Seek(uiStringsPtr, SeekOrigin.Begin);
            count = br.ReadInt32();
            var uiStrings = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                string s = Encoding.ASCII.GetString(br.ReadBytes(0x80));
                fs.Seek(4, SeekOrigin.Current);

                uiStrings.Add(s);
            }

            uiStringsLB.DataSource = uiStrings;

            fs.Close();
            fs.Dispose();

            // Reapply selection index
            uiPositionsLB.SelectedIndex = prevUIPosIndex;
            uiStringsLB.SelectedIndex = prevUIStringsIndex;

        }

        private void enableTransforming_CheckedChanged(object sender, EventArgs e)
        {
            UpdateImage();
        }

        private void xOffset_ValueChanged(object sender, EventArgs e)
        {
            int i = uiPositionsLB.SelectedIndex;
            uiPositions[i].xPos = Convert.ToInt32(xOffset.Value * 20.0M);

            UpdateImage();
        }

        private void yOffset_ValueChanged(object sender, EventArgs e)
        {
            int i = uiPositionsLB.SelectedIndex;
            uiPositions[i].yPos = Convert.ToInt32(yOffset.Value * 20.0M);

            UpdateImage();
        }

        private void xScale_ValueChanged(object sender, EventArgs e)
        {
            int i = uiPositionsLB.SelectedIndex;
            uiPositions[i].xScale = Convert.ToSingle(xScale.Value);

            UpdateImage();
        }

        private void yScale_ValueChanged(object sender, EventArgs e)
        {
            int i = uiPositionsLB.SelectedIndex;
            uiPositions[i].yScale = Convert.ToSingle(yScale.Value);

            UpdateImage();
        }

        private void xSkew_ValueChanged(object sender, EventArgs e)
        {
            int i = uiPositionsLB.SelectedIndex;
            uiPositions[i].xSkew = Convert.ToSingle(xSkew.Value);
        }

        private void ySkew_ValueChanged(object sender, EventArgs e)
        {
            int i = uiPositionsLB.SelectedIndex;
            uiPositions[i].ySkew = Convert.ToSingle(ySkew.Value);
        }
    }
}
