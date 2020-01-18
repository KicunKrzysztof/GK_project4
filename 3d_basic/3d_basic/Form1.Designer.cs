namespace _3d_basic
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
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SunCheckBox = new System.Windows.Forms.CheckBox();
            this.SpotlightCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BoundedCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.TrackingCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.ConstantCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PhongRadioButton = new System.Windows.Forms.RadioButton();
            this.GouraudRadioButton = new System.Windows.Forms.RadioButton();
            this.ConstantShadingRadioButton = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.kaTrackBar = new System.Windows.Forms.TrackBar();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.nTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.kalabel = new System.Windows.Forms.Label();
            this.kdlabel = new System.Windows.Forms.Label();
            this.kslabel = new System.Windows.Forms.Label();
            this.nlabel = new System.Windows.Forms.Label();
            this.spotlightAngleTrackBar = new System.Windows.Forms.TrackBar();
            this.spotlightNTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.spotlightAngleLabel = new System.Windows.Forms.Label();
            this.spotlightNLabel = new System.Windows.Forms.Label();
            this.MainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spotlightAngleTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spotlightNTrackBar)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 2;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.Controls.Add(this.pictureBox, 1, 0);
            this.MainLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 1;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(1382, 753);
            this.MainLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(303, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1076, 747);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00001F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 747);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SunCheckBox);
            this.groupBox3.Controls.Add(this.SpotlightCheckBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 105);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Oświetlenie";
            // 
            // SunCheckBox
            // 
            this.SunCheckBox.AutoSize = true;
            this.SunCheckBox.Checked = true;
            this.SunCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SunCheckBox.Location = new System.Drawing.Point(6, 21);
            this.SunCheckBox.Name = "SunCheckBox";
            this.SunCheckBox.Size = new System.Drawing.Size(73, 21);
            this.SunCheckBox.TabIndex = 4;
            this.SunCheckBox.Text = "Słońce";
            this.SunCheckBox.UseVisualStyleBackColor = true;
            this.SunCheckBox.Click += new System.EventHandler(this.SunCheckBox_Click);
            // 
            // SpotlightCheckBox
            // 
            this.SpotlightCheckBox.AutoSize = true;
            this.SpotlightCheckBox.Checked = true;
            this.SpotlightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SpotlightCheckBox.Location = new System.Drawing.Point(6, 48);
            this.SpotlightCheckBox.Name = "SpotlightCheckBox";
            this.SpotlightCheckBox.Size = new System.Drawing.Size(87, 21);
            this.SpotlightCheckBox.TabIndex = 5;
            this.SpotlightCheckBox.Text = "Reflektor";
            this.SpotlightCheckBox.UseVisualStyleBackColor = true;
            this.SpotlightCheckBox.Click += new System.EventHandler(this.SpotlightCheckBox_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BoundedCameraRadioButton);
            this.groupBox2.Controls.Add(this.TrackingCameraRadioButton);
            this.groupBox2.Controls.Add(this.ConstantCameraRadioButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 105);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kamera";
            // 
            // BoundedCameraRadioButton
            // 
            this.BoundedCameraRadioButton.AutoSize = true;
            this.BoundedCameraRadioButton.Location = new System.Drawing.Point(6, 75);
            this.BoundedCameraRadioButton.Name = "BoundedCameraRadioButton";
            this.BoundedCameraRadioButton.Size = new System.Drawing.Size(86, 21);
            this.BoundedCameraRadioButton.TabIndex = 2;
            this.BoundedCameraRadioButton.TabStop = true;
            this.BoundedCameraRadioButton.Text = "Bounded";
            this.BoundedCameraRadioButton.UseVisualStyleBackColor = true;
            this.BoundedCameraRadioButton.Click += new System.EventHandler(this.BoundedCameraRadioButton_Click);
            // 
            // TrackingCameraRadioButton
            // 
            this.TrackingCameraRadioButton.AutoSize = true;
            this.TrackingCameraRadioButton.Location = new System.Drawing.Point(6, 48);
            this.TrackingCameraRadioButton.Name = "TrackingCameraRadioButton";
            this.TrackingCameraRadioButton.Size = new System.Drawing.Size(87, 21);
            this.TrackingCameraRadioButton.TabIndex = 1;
            this.TrackingCameraRadioButton.TabStop = true;
            this.TrackingCameraRadioButton.Text = "Śledząca";
            this.TrackingCameraRadioButton.UseVisualStyleBackColor = true;
            this.TrackingCameraRadioButton.Click += new System.EventHandler(this.TrackingCameraRadioButton_Click);
            // 
            // ConstantCameraRadioButton
            // 
            this.ConstantCameraRadioButton.AutoSize = true;
            this.ConstantCameraRadioButton.Checked = true;
            this.ConstantCameraRadioButton.Location = new System.Drawing.Point(6, 21);
            this.ConstantCameraRadioButton.Name = "ConstantCameraRadioButton";
            this.ConstantCameraRadioButton.Size = new System.Drawing.Size(61, 21);
            this.ConstantCameraRadioButton.TabIndex = 0;
            this.ConstantCameraRadioButton.TabStop = true;
            this.ConstantCameraRadioButton.Text = "Stała";
            this.ConstantCameraRadioButton.UseVisualStyleBackColor = true;
            this.ConstantCameraRadioButton.Click += new System.EventHandler(this.ConstantCameraRadioButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PhongRadioButton);
            this.groupBox1.Controls.Add(this.GouraudRadioButton);
            this.groupBox1.Controls.Add(this.ConstantShadingRadioButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cieniowanie";
            // 
            // PhongRadioButton
            // 
            this.PhongRadioButton.AutoSize = true;
            this.PhongRadioButton.Location = new System.Drawing.Point(6, 75);
            this.PhongRadioButton.Name = "PhongRadioButton";
            this.PhongRadioButton.Size = new System.Drawing.Size(78, 21);
            this.PhongRadioButton.TabIndex = 2;
            this.PhongRadioButton.TabStop = true;
            this.PhongRadioButton.Text = "Phonga";
            this.PhongRadioButton.UseVisualStyleBackColor = true;
            this.PhongRadioButton.Click += new System.EventHandler(this.PhongRadioButton_Click);
            // 
            // GouraudRadioButton
            // 
            this.GouraudRadioButton.AutoSize = true;
            this.GouraudRadioButton.Location = new System.Drawing.Point(6, 48);
            this.GouraudRadioButton.Name = "GouraudRadioButton";
            this.GouraudRadioButton.Size = new System.Drawing.Size(93, 21);
            this.GouraudRadioButton.TabIndex = 1;
            this.GouraudRadioButton.TabStop = true;
            this.GouraudRadioButton.Text = "Gourauda";
            this.GouraudRadioButton.UseVisualStyleBackColor = true;
            this.GouraudRadioButton.Click += new System.EventHandler(this.GouraudRadioButton_Click);
            // 
            // ConstantShadingRadioButton
            // 
            this.ConstantShadingRadioButton.AutoSize = true;
            this.ConstantShadingRadioButton.Checked = true;
            this.ConstantShadingRadioButton.Location = new System.Drawing.Point(6, 21);
            this.ConstantShadingRadioButton.Name = "ConstantShadingRadioButton";
            this.ConstantShadingRadioButton.Size = new System.Drawing.Size(61, 21);
            this.ConstantShadingRadioButton.TabIndex = 0;
            this.ConstantShadingRadioButton.TabStop = true;
            this.ConstantShadingRadioButton.Text = "Stałe";
            this.ConstantShadingRadioButton.UseVisualStyleBackColor = true;
            this.ConstantShadingRadioButton.Click += new System.EventHandler(this.ConstantShadingRadioButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // groupBox4
            // 
            this.groupBox4.CausesValidation = false;
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.nlabel);
            this.groupBox4.Controls.Add(this.kslabel);
            this.groupBox4.Controls.Add(this.kdlabel);
            this.groupBox4.Controls.Add(this.kalabel);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.nTrackBar);
            this.groupBox4.Controls.Add(this.ksTrackBar);
            this.groupBox4.Controls.Add(this.kdTrackBar);
            this.groupBox4.Controls.Add(this.kaTrackBar);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 336);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(288, 294);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Współczynniki";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 636);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(288, 108);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Klatki na sekundę";
            // 
            // kaTrackBar
            // 
            this.kaTrackBar.Location = new System.Drawing.Point(6, 21);
            this.kaTrackBar.Maximum = 100;
            this.kaTrackBar.MaximumSize = new System.Drawing.Size(150, 30);
            this.kaTrackBar.Name = "kaTrackBar";
            this.kaTrackBar.Size = new System.Drawing.Size(150, 30);
            this.kaTrackBar.TabIndex = 0;
            this.kaTrackBar.Value = 15;
            this.kaTrackBar.ValueChanged += new System.EventHandler(this.kaTrackBar_ValueChanged);
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.Location = new System.Drawing.Point(6, 57);
            this.kdTrackBar.Maximum = 100;
            this.kdTrackBar.MaximumSize = new System.Drawing.Size(150, 30);
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(150, 30);
            this.kdTrackBar.TabIndex = 1;
            this.kdTrackBar.Value = 20;
            this.kdTrackBar.ValueChanged += new System.EventHandler(this.kdTrackBar_ValueChanged);
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.Location = new System.Drawing.Point(6, 93);
            this.ksTrackBar.Maximum = 100;
            this.ksTrackBar.MaximumSize = new System.Drawing.Size(150, 30);
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(150, 30);
            this.ksTrackBar.TabIndex = 2;
            this.ksTrackBar.Value = 50;
            this.ksTrackBar.ValueChanged += new System.EventHandler(this.ksTrackBar_ValueChanged);
            // 
            // nTrackBar
            // 
            this.nTrackBar.Location = new System.Drawing.Point(6, 129);
            this.nTrackBar.Maximum = 200;
            this.nTrackBar.MaximumSize = new System.Drawing.Size(150, 30);
            this.nTrackBar.Name = "nTrackBar";
            this.nTrackBar.Size = new System.Drawing.Size(150, 30);
            this.nTrackBar.TabIndex = 3;
            this.nTrackBar.Value = 20;
            this.nTrackBar.ValueChanged += new System.EventHandler(this.nTrackBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "ka:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "kd:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "ks:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "n:";
            // 
            // kalabel
            // 
            this.kalabel.AutoSize = true;
            this.kalabel.Location = new System.Drawing.Point(214, 21);
            this.kalabel.Name = "kalabel";
            this.kalabel.Size = new System.Drawing.Size(36, 17);
            this.kalabel.TabIndex = 8;
            this.kalabel.Text = "0.15";
            // 
            // kdlabel
            // 
            this.kdlabel.AutoSize = true;
            this.kdlabel.Location = new System.Drawing.Point(214, 57);
            this.kdlabel.Name = "kdlabel";
            this.kdlabel.Size = new System.Drawing.Size(36, 17);
            this.kdlabel.TabIndex = 9;
            this.kdlabel.Text = "0.20";
            // 
            // kslabel
            // 
            this.kslabel.AutoSize = true;
            this.kslabel.Location = new System.Drawing.Point(214, 93);
            this.kslabel.Name = "kslabel";
            this.kslabel.Size = new System.Drawing.Size(36, 17);
            this.kslabel.TabIndex = 10;
            this.kslabel.Text = "0.50";
            // 
            // nlabel
            // 
            this.nlabel.AutoSize = true;
            this.nlabel.Location = new System.Drawing.Point(214, 129);
            this.nlabel.Name = "nlabel";
            this.nlabel.Size = new System.Drawing.Size(24, 17);
            this.nlabel.TabIndex = 11;
            this.nlabel.Text = "20";
            // 
            // spotlightAngleTrackBar
            // 
            this.spotlightAngleTrackBar.Location = new System.Drawing.Point(6, 21);
            this.spotlightAngleTrackBar.Maximum = 900;
            this.spotlightAngleTrackBar.MaximumSize = new System.Drawing.Size(150, 30);
            this.spotlightAngleTrackBar.Name = "spotlightAngleTrackBar";
            this.spotlightAngleTrackBar.Size = new System.Drawing.Size(150, 30);
            this.spotlightAngleTrackBar.TabIndex = 12;
            this.spotlightAngleTrackBar.Value = 515;
            this.spotlightAngleTrackBar.ValueChanged += new System.EventHandler(this.spotlightAngleTrackBar_ValueChanged);
            // 
            // spotlightNTrackBar
            // 
            this.spotlightNTrackBar.Location = new System.Drawing.Point(6, 57);
            this.spotlightNTrackBar.Maximum = 200;
            this.spotlightNTrackBar.MaximumSize = new System.Drawing.Size(150, 30);
            this.spotlightNTrackBar.Name = "spotlightNTrackBar";
            this.spotlightNTrackBar.Size = new System.Drawing.Size(150, 30);
            this.spotlightNTrackBar.TabIndex = 13;
            this.spotlightNTrackBar.Value = 10;
            this.spotlightNTrackBar.ValueChanged += new System.EventHandler(this.spotlightNTrackBar_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.spotlightNLabel);
            this.groupBox5.Controls.Add(this.spotlightAngleLabel);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.spotlightNTrackBar);
            this.groupBox5.Controls.Add(this.spotlightAngleTrackBar);
            this.groupBox5.Location = new System.Drawing.Point(6, 165);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(276, 123);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Reflektor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "kąt:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "n:";
            // 
            // spotlightAngleLabel
            // 
            this.spotlightAngleLabel.AutoSize = true;
            this.spotlightAngleLabel.Location = new System.Drawing.Point(208, 21);
            this.spotlightAngleLabel.Name = "spotlightAngleLabel";
            this.spotlightAngleLabel.Size = new System.Drawing.Size(36, 17);
            this.spotlightAngleLabel.TabIndex = 16;
            this.spotlightAngleLabel.Text = "51.5";
            // 
            // spotlightNLabel
            // 
            this.spotlightNLabel.AutoSize = true;
            this.spotlightNLabel.Location = new System.Drawing.Point(208, 57);
            this.spotlightNLabel.Name = "spotlightNLabel";
            this.spotlightNLabel.Size = new System.Drawing.Size(24, 17);
            this.spotlightNLabel.TabIndex = 17;
            this.spotlightNLabel.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.MainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MainLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spotlightAngleTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spotlightNTrackBar)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PhongRadioButton;
        private System.Windows.Forms.RadioButton GouraudRadioButton;
        private System.Windows.Forms.RadioButton ConstantShadingRadioButton;
        private System.Windows.Forms.RadioButton BoundedCameraRadioButton;
        private System.Windows.Forms.RadioButton TrackingCameraRadioButton;
        private System.Windows.Forms.RadioButton ConstantCameraRadioButton;
        private System.Windows.Forms.CheckBox SpotlightCheckBox;
        private System.Windows.Forms.CheckBox SunCheckBox;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar nTrackBar;
        private System.Windows.Forms.TrackBar ksTrackBar;
        private System.Windows.Forms.TrackBar kdTrackBar;
        private System.Windows.Forms.TrackBar kaTrackBar;
        private System.Windows.Forms.Label nlabel;
        private System.Windows.Forms.Label kslabel;
        private System.Windows.Forms.Label kdlabel;
        private System.Windows.Forms.Label kalabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label spotlightNLabel;
        private System.Windows.Forms.Label spotlightAngleLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar spotlightNTrackBar;
        private System.Windows.Forms.TrackBar spotlightAngleTrackBar;
    }
}

