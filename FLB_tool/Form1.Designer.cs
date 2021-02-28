namespace FLB_tool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.enableTransforming = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.uiStringsLB = new System.Windows.Forms.ListBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.reloadANCH0 = new System.Windows.Forms.Button();
            this.saveANCH0 = new System.Windows.Forms.Button();
            this.applyDeform = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yOffset = new System.Windows.Forms.NumericUpDown();
            this.xOffset = new System.Windows.Forms.NumericUpDown();
            this.deformationGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ySkew = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.xSkew = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.yScale = new System.Windows.Forms.NumericUpDown();
            this.xScale = new System.Windows.Forms.NumericUpDown();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.uiPositionsLB = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new FLB_tool.TransparentPictureBox();
            this.transparentPictureBox1 = new FLB_tool.TransparentPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xOffset)).BeginInit();
            this.deformationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ySkew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSkew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparentPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.splitter3);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.splitter2);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1338, 774);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.splitContainer1.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            // 
            // splitContainer2
            // 
            this.splitContainer2.AllowDrop = true;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AllowDrop = true;
            this.splitContainer2.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(153, 774);
            this.splitContainer2.SplitterDistance = 294;
            this.splitContainer2.TabIndex = 1;
            this.splitContainer2.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.splitContainer2.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "OPEN FLB"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(153, 294);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.enableTransforming);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(153, 476);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Open FLB";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(3, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export .PNG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(3, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Replace .PNG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // enableTransforming
            // 
            this.enableTransforming.AutoSize = true;
            this.enableTransforming.Location = new System.Drawing.Point(3, 90);
            this.enableTransforming.Name = "enableTransforming";
            this.enableTransforming.Size = new System.Drawing.Size(135, 17);
            this.enableTransforming.TabIndex = 3;
            this.enableTransforming.Text = "Show Image Transform";
            this.enableTransforming.UseVisualStyleBackColor = true;
            this.enableTransforming.CheckedChanged += new System.EventHandler(this.enableTransforming_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.uiStringsLB);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(892, 396);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 378);
            this.panel4.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Unknown UI Identifiers";
            // 
            // uiStringsLB
            // 
            this.uiStringsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiStringsLB.FormattingEnabled = true;
            this.uiStringsLB.Location = new System.Drawing.Point(9, 25);
            this.uiStringsLB.Name = "uiStringsLB";
            this.uiStringsLB.Size = new System.Drawing.Size(268, 342);
            this.uiStringsLB.TabIndex = 25;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.SystemColors.Control;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(892, 393);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(289, 3);
            this.splitter3.TabIndex = 6;
            this.splitter3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.reloadANCH0);
            this.panel3.Controls.Add(this.saveANCH0);
            this.panel3.Controls.Add(this.applyDeform);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.yOffset);
            this.panel3.Controls.Add(this.xOffset);
            this.panel3.Controls.Add(this.deformationGroup);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(892, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 222);
            this.panel3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "X Position";
            // 
            // reloadANCH0
            // 
            this.reloadANCH0.Location = new System.Drawing.Point(171, 189);
            this.reloadANCH0.Name = "reloadANCH0";
            this.reloadANCH0.Size = new System.Drawing.Size(109, 23);
            this.reloadANCH0.TabIndex = 29;
            this.reloadANCH0.Text = "Reload";
            this.reloadANCH0.UseVisualStyleBackColor = true;
            this.reloadANCH0.Click += new System.EventHandler(this.reloadANCH0_Click);
            // 
            // saveANCH0
            // 
            this.saveANCH0.Location = new System.Drawing.Point(16, 189);
            this.saveANCH0.Name = "saveANCH0";
            this.saveANCH0.Size = new System.Drawing.Size(109, 23);
            this.saveANCH0.TabIndex = 28;
            this.saveANCH0.Text = "Save";
            this.saveANCH0.UseVisualStyleBackColor = true;
            this.saveANCH0.Click += new System.EventHandler(this.saveANCH0_Click);
            // 
            // applyDeform
            // 
            this.applyDeform.AutoSize = true;
            this.applyDeform.Location = new System.Drawing.Point(9, 45);
            this.applyDeform.Name = "applyDeform";
            this.applyDeform.Size = new System.Drawing.Size(112, 17);
            this.applyDeform.TabIndex = 26;
            this.applyDeform.Text = "Apply Deformation";
            this.applyDeform.UseVisualStyleBackColor = true;
            this.applyDeform.CheckedChanged += new System.EventHandler(this.applyDeform_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Y Position";
            // 
            // yOffset
            // 
            this.yOffset.DecimalPlaces = 2;
            this.yOffset.Location = new System.Drawing.Point(179, 19);
            this.yOffset.Maximum = new decimal(new int[] {
            2147483643,
            2,
            0,
            131072});
            this.yOffset.Minimum = new decimal(new int[] {
            1073741824,
            0,
            0,
            -2147418112});
            this.yOffset.Name = "yOffset";
            this.yOffset.Size = new System.Drawing.Size(101, 20);
            this.yOffset.TabIndex = 25;
            this.yOffset.ValueChanged += new System.EventHandler(this.yOffset_ValueChanged);
            // 
            // xOffset
            // 
            this.xOffset.DecimalPlaces = 2;
            this.xOffset.Location = new System.Drawing.Point(24, 19);
            this.xOffset.Maximum = new decimal(new int[] {
            2147483643,
            2,
            0,
            131072});
            this.xOffset.Minimum = new decimal(new int[] {
            1073741824,
            0,
            0,
            -2147418112});
            this.xOffset.Name = "xOffset";
            this.xOffset.Size = new System.Drawing.Size(101, 20);
            this.xOffset.TabIndex = 24;
            this.xOffset.ValueChanged += new System.EventHandler(this.xOffset_ValueChanged);
            // 
            // deformationGroup
            // 
            this.deformationGroup.Controls.Add(this.label4);
            this.deformationGroup.Controls.Add(this.label3);
            this.deformationGroup.Controls.Add(this.ySkew);
            this.deformationGroup.Controls.Add(this.label6);
            this.deformationGroup.Controls.Add(this.xSkew);
            this.deformationGroup.Controls.Add(this.label5);
            this.deformationGroup.Controls.Add(this.yScale);
            this.deformationGroup.Controls.Add(this.xScale);
            this.deformationGroup.Enabled = false;
            this.deformationGroup.Location = new System.Drawing.Point(9, 68);
            this.deformationGroup.Name = "deformationGroup";
            this.deformationGroup.Size = new System.Drawing.Size(271, 115);
            this.deformationGroup.TabIndex = 27;
            this.deformationGroup.TabStop = false;
            this.deformationGroup.Text = "Deformation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Horizontal Scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Vertical Scale";
            // 
            // ySkew
            // 
            this.ySkew.DecimalPlaces = 7;
            this.ySkew.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ySkew.Location = new System.Drawing.Point(164, 81);
            this.ySkew.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.ySkew.Name = "ySkew";
            this.ySkew.Size = new System.Drawing.Size(101, 20);
            this.ySkew.TabIndex = 19;
            this.ySkew.ValueChanged += new System.EventHandler(this.ySkew_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Horizontal Skew";
            // 
            // xSkew
            // 
            this.xSkew.DecimalPlaces = 7;
            this.xSkew.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.xSkew.Location = new System.Drawing.Point(18, 80);
            this.xSkew.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xSkew.Name = "xSkew";
            this.xSkew.Size = new System.Drawing.Size(101, 20);
            this.xSkew.TabIndex = 18;
            this.xSkew.ValueChanged += new System.EventHandler(this.xSkew_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Vertical Skew";
            // 
            // yScale
            // 
            this.yScale.DecimalPlaces = 7;
            this.yScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.yScale.Location = new System.Drawing.Point(164, 38);
            this.yScale.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yScale.Name = "yScale";
            this.yScale.Size = new System.Drawing.Size(101, 20);
            this.yScale.TabIndex = 17;
            this.yScale.ValueChanged += new System.EventHandler(this.yScale_ValueChanged);
            // 
            // xScale
            // 
            this.xScale.DecimalPlaces = 7;
            this.xScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.xScale.Location = new System.Drawing.Point(18, 37);
            this.xScale.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xScale.Name = "xScale";
            this.xScale.Size = new System.Drawing.Size(101, 20);
            this.xScale.TabIndex = 14;
            this.xScale.ValueChanged += new System.EventHandler(this.xScale_ValueChanged);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.Control;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(892, 168);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(289, 3);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.uiPositionsLB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(892, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 168);
            this.panel2.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "UI Position Items";
            // 
            // uiPositionsLB
            // 
            this.uiPositionsLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPositionsLB.FormattingEnabled = true;
            this.uiPositionsLB.Location = new System.Drawing.Point(9, 25);
            this.uiPositionsLB.Name = "uiPositionsLB";
            this.uiPositionsLB.Size = new System.Drawing.Size(268, 134);
            this.uiPositionsLB.TabIndex = 28;
            this.uiPositionsLB.SelectedIndexChanged += new System.EventHandler(this.uiPositionsLB_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(889, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 774);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.transparentPictureBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 774);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // transparentPictureBox1
            // 
            this.transparentPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.transparentPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("transparentPictureBox1.Image")));
            this.transparentPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.transparentPictureBox1.Name = "transparentPictureBox1";
            this.transparentPictureBox1.Size = new System.Drawing.Size(854, 640);
            this.transparentPictureBox1.TabIndex = 2;
            this.transparentPictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::FLB_tool.Properties.Resources.checkerboard;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(889, 774);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "default_transparent.png");
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::FLB_tool.Properties.Resources.checkerboard;
            this.ClientSize = new System.Drawing.Size(1338, 774);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "FFVI - FLB tool by Maki (Marcin Gomulak) & Enfyve";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xOffset)).EndInit();
            this.deformationGroup.ResumeLayout(false);
            this.deformationGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ySkew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSkew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparentPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox deformationGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ySkew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown xSkew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown yScale;
        private System.Windows.Forms.NumericUpDown xScale;
        private System.Windows.Forms.CheckBox applyDeform;
        private System.Windows.Forms.NumericUpDown yOffset;
        private System.Windows.Forms.NumericUpDown xOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox uiPositionsLB;
        private System.Windows.Forms.Button saveANCH0;
        private System.Windows.Forms.Button reloadANCH0;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox uiStringsLB;
        private TransparentPictureBox pictureBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox enableTransforming;
        private TransparentPictureBox transparentPictureBox1;
    }
}

