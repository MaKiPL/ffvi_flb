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

namespace FLB_tool
{
    public partial class Form1 : Form
    {
        private uint[] imchSpritePointers;
        private uint imchPointer;
        private Bitmap[] sprites;
        private string lastOpenPath;

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

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //string[] test = e.Data.GetFormats(false);
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
            FileStream fs = new FileStream(pathFilename, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            if (Encoding.UTF8.GetString(br.ReadBytes(4), 0, 4) != "FLBD") { MessageBox.Show("Wrong or corrupted FLB file"); return; }
            fs.Seek(4, SeekOrigin.Current); //pass 0101
            imchPointer = br.ReadUInt32();

            fs.Seek(12, SeekOrigin.Current);
            SHCH = br.ReadUInt32();
            SPCH = br.ReadUInt32();
            BTCH = br.ReadUInt32();
            ANCH0 = br.ReadUInt32();

            fs.Seek(imchPointer, SeekOrigin.Begin);
            if (Encoding.UTF8.GetString(br.ReadBytes(4), 0, 4) != "IMCH") { MessageBox.Show("Wrong or corrupted FLB file"); return; }
            uint imchSize = br.ReadUInt32();
            uint imchSpriteSize = br.ReadUInt32();
            imchSpritePointers = new uint[imchSpriteSize];
            sprites = new Bitmap[imchSpriteSize];
            for (int i = 0; i < imchSpriteSize; i++)
            {
                uint pointer = br.ReadUInt32();
                imchSpritePointers[i] = imchPointer + imchSize + pointer;
            }
            //==read sprites to bitmap==
            for (int i = 0; i < imchSpritePointers.Length; i++)
            {
                fs.Seek(imchSpritePointers[i] + 24, SeekOrigin.Begin);
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
                pictureBox1.Image = sprites[0];

            listBox1.DataSource = imchSpritePointers;

            button1.Enabled = true;
            button2.Enabled = true;
            fs.Close();
            fs.Dispose();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = sprites[(sender as ListBox).SelectedIndex];
                width = (ushort)pictureBox1.Image.Width;
                height = (ushort)pictureBox1.Image.Height;
            }
            catch { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PNG *.PNG|*.PNG", CheckPathExists = true })
            {
                sfd.ShowDialog();
                if(!string.IsNullOrWhiteSpace(sfd.FileName))
                    pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
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
            Buffer.BlockCopy(fullBuffer, 0, finalBuffer, 0, (int)imchSpritePointers[listBox1.SelectedIndex] + 28);
            Buffer.BlockCopy(buffer, 0, finalBuffer, (int)imchSpritePointers[listBox1.SelectedIndex] + 28, buffer.Length);
            if(imchSpritePointers.Length != 1) //more than one sprite
            {
                int dstOffset = (int)imchSpritePointers[listBox1.SelectedIndex] + 28 + buffer.Length;
                int cnt = fullBuffer.Length - (int)imchSpritePointers[listBox1.SelectedIndex + 1];
                Buffer.BlockCopy(fullBuffer, (int)imchSpritePointers[listBox1.SelectedIndex + 1], finalBuffer, dstOffset, cnt);
            }
            else
            {
                int dstOffset = (int)imchSpritePointers[listBox1.SelectedIndex] + buffer.Length;
                int cnt = fullBuffer.Length - (int)SHCH;
                Buffer.BlockCopy(fullBuffer, (int)SHCH, finalBuffer, dstOffset, cnt);
            }
            File.WriteAllBytes(lastOpenPath, finalBuffer);
        }
    }
}
