namespace SerialPortConnection
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SetPolarbtn = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.YIPolarBox = new System.Windows.Forms.ComboBox();
            this.XPPolarBox = new System.Windows.Forms.ComboBox();
            this.YQPolarBox = new System.Windows.Forms.ComboBox();
            this.XQPolarBox = new System.Windows.Forms.ComboBox();
            this.YPPolarBox = new System.Windows.Forms.ComboBox();
            this.XIPolarBox = new System.Windows.Forms.ComboBox();
            this.SetDACbtn = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.SetDACtxBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.SetDACBox = new System.Windows.Forms.ComboBox();
            this.AutoModebtn = new System.Windows.Forms.Button();
            this.ManualModebtn = new System.Windows.Forms.Button();
            this.Resumebtn = new System.Windows.Forms.Button();
            this.Pausebtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.ReadBiasbtn = new System.Windows.Forms.Button();
            this.ReadPowerbtn = new System.Windows.Forms.Button();
            this.ReadVpibtn = new System.Windows.Forms.Button();
            this.ReadPolarbtn = new System.Windows.Forms.Button();
            this.Resetbtn = new System.Windows.Forms.Button();
            this.ReadStatusbtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DitherAmpSetbtn = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.DitherYIAmp_txBox = new System.Windows.Forms.TextBox();
            this.DitherXQAmp_txBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.DitherYQAmp_txBox = new System.Windows.Forms.TextBox();
            this.DitherXIAmp_txBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PVpitxBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QVpitxBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IVpitxBox = new System.Windows.Forms.TextBox();
            this.BiasChBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.tmSend = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.OriginalDataTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SetPolarbtn);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.YIPolarBox);
            this.groupBox1.Controls.Add(this.XPPolarBox);
            this.groupBox1.Controls.Add(this.YQPolarBox);
            this.groupBox1.Controls.Add(this.XQPolarBox);
            this.groupBox1.Controls.Add(this.YPPolarBox);
            this.groupBox1.Controls.Add(this.XIPolarBox);
            this.groupBox1.Location = new System.Drawing.Point(442, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(429, 368);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polar Setting";
            // 
            // SetPolarbtn
            // 
            this.SetPolarbtn.Location = new System.Drawing.Point(285, 42);
            this.SetPolarbtn.Margin = new System.Windows.Forms.Padding(5);
            this.SetPolarbtn.Name = "SetPolarbtn";
            this.SetPolarbtn.Size = new System.Drawing.Size(113, 296);
            this.SetPolarbtn.TabIndex = 75;
            this.SetPolarbtn.Text = "Set Polar";
            this.SetPolarbtn.UseVisualStyleBackColor = true;
            this.SetPolarbtn.Click += new System.EventHandler(this.SetPolarbtn_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(19, 320);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(125, 18);
            this.label25.TabIndex = 74;
            this.label25.Text = "Set XP Polar:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 265);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 18);
            this.label24.TabIndex = 73;
            this.label24.Text = "Set XQ Polar:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 210);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 18);
            this.label23.TabIndex = 72;
            this.label23.Text = "Set XI Polar:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 155);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 18);
            this.label22.TabIndex = 71;
            this.label22.Text = "Set YP Polar:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 100);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 18);
            this.label21.TabIndex = 70;
            this.label21.Text = "Set YQ Polar:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 45);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(125, 18);
            this.label20.TabIndex = 69;
            this.label20.Text = "Set YI Polar:";
            // 
            // YIPolarBox
            // 
            this.YIPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YIPolarBox.FormattingEnabled = true;
            this.YIPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.YIPolarBox.Location = new System.Drawing.Point(150, 42);
            this.YIPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.YIPolarBox.Name = "YIPolarBox";
            this.YIPolarBox.Size = new System.Drawing.Size(115, 26);
            this.YIPolarBox.TabIndex = 63;
            // 
            // XPPolarBox
            // 
            this.XPPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XPPolarBox.FormattingEnabled = true;
            this.XPPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.XPPolarBox.Location = new System.Drawing.Point(150, 317);
            this.XPPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.XPPolarBox.Name = "XPPolarBox";
            this.XPPolarBox.Size = new System.Drawing.Size(115, 26);
            this.XPPolarBox.TabIndex = 68;
            // 
            // YQPolarBox
            // 
            this.YQPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YQPolarBox.FormattingEnabled = true;
            this.YQPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.YQPolarBox.Location = new System.Drawing.Point(150, 97);
            this.YQPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.YQPolarBox.Name = "YQPolarBox";
            this.YQPolarBox.Size = new System.Drawing.Size(115, 26);
            this.YQPolarBox.TabIndex = 64;
            // 
            // XQPolarBox
            // 
            this.XQPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XQPolarBox.FormattingEnabled = true;
            this.XQPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.XQPolarBox.Location = new System.Drawing.Point(150, 262);
            this.XQPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.XQPolarBox.Name = "XQPolarBox";
            this.XQPolarBox.Size = new System.Drawing.Size(115, 26);
            this.XQPolarBox.TabIndex = 67;
            // 
            // YPPolarBox
            // 
            this.YPPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YPPolarBox.FormattingEnabled = true;
            this.YPPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.YPPolarBox.Location = new System.Drawing.Point(150, 152);
            this.YPPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.YPPolarBox.Name = "YPPolarBox";
            this.YPPolarBox.Size = new System.Drawing.Size(115, 26);
            this.YPPolarBox.TabIndex = 65;
            // 
            // XIPolarBox
            // 
            this.XIPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XIPolarBox.FormattingEnabled = true;
            this.XIPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.XIPolarBox.Location = new System.Drawing.Point(150, 207);
            this.XIPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.XIPolarBox.Name = "XIPolarBox";
            this.XIPolarBox.Size = new System.Drawing.Size(115, 26);
            this.XIPolarBox.TabIndex = 66;
            // 
            // SetDACbtn
            // 
            this.SetDACbtn.Location = new System.Drawing.Point(293, 61);
            this.SetDACbtn.Margin = new System.Windows.Forms.Padding(5);
            this.SetDACbtn.Name = "SetDACbtn";
            this.SetDACbtn.Size = new System.Drawing.Size(113, 64);
            this.SetDACbtn.TabIndex = 80;
            this.SetDACbtn.Text = "SetDAC";
            this.SetDACbtn.UseVisualStyleBackColor = true;
            this.SetDACbtn.Click += new System.EventHandler(this.SetDACbtn_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 101);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(143, 18);
            this.label27.TabIndex = 79;
            this.label27.Text = "Set Voltage(V):";
            // 
            // SetDACtxBox
            // 
            this.SetDACtxBox.Location = new System.Drawing.Point(159, 97);
            this.SetDACtxBox.Margin = new System.Windows.Forms.Padding(2);
            this.SetDACtxBox.MaxLength = 10;
            this.SetDACtxBox.Name = "SetDACtxBox";
            this.SetDACtxBox.Size = new System.Drawing.Size(119, 28);
            this.SetDACtxBox.TabIndex = 78;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 64);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(125, 18);
            this.label26.TabIndex = 77;
            this.label26.Text = "Bias Channel:";
            // 
            // SetDACBox
            // 
            this.SetDACBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SetDACBox.FormattingEnabled = true;
            this.SetDACBox.Items.AddRange(new object[] {
            "Y-I",
            "Y-Q",
            "Y-P",
            "X-I",
            "X-Q",
            "X-P"});
            this.SetDACBox.Location = new System.Drawing.Point(159, 61);
            this.SetDACBox.Margin = new System.Windows.Forms.Padding(5);
            this.SetDACBox.Name = "SetDACBox";
            this.SetDACBox.Size = new System.Drawing.Size(119, 26);
            this.SetDACBox.TabIndex = 76;
            // 
            // AutoModebtn
            // 
            this.AutoModebtn.Location = new System.Drawing.Point(30, 120);
            this.AutoModebtn.Margin = new System.Windows.Forms.Padding(5);
            this.AutoModebtn.Name = "AutoModebtn";
            this.AutoModebtn.Size = new System.Drawing.Size(155, 55);
            this.AutoModebtn.TabIndex = 55;
            this.AutoModebtn.Text = "Auto Mode";
            this.AutoModebtn.UseVisualStyleBackColor = true;
            this.AutoModebtn.Click += new System.EventHandler(this.AutoModebtn_Click);
            // 
            // ManualModebtn
            // 
            this.ManualModebtn.Location = new System.Drawing.Point(215, 120);
            this.ManualModebtn.Margin = new System.Windows.Forms.Padding(5);
            this.ManualModebtn.Name = "ManualModebtn";
            this.ManualModebtn.Size = new System.Drawing.Size(155, 55);
            this.ManualModebtn.TabIndex = 54;
            this.ManualModebtn.Text = "Manual Mode";
            this.ManualModebtn.UseVisualStyleBackColor = true;
            this.ManualModebtn.Click += new System.EventHandler(this.ManualModebtn_Click);
            // 
            // Resumebtn
            // 
            this.Resumebtn.Location = new System.Drawing.Point(215, 45);
            this.Resumebtn.Margin = new System.Windows.Forms.Padding(5);
            this.Resumebtn.Name = "Resumebtn";
            this.Resumebtn.Size = new System.Drawing.Size(155, 55);
            this.Resumebtn.TabIndex = 53;
            this.Resumebtn.Text = "Resume Control";
            this.Resumebtn.UseVisualStyleBackColor = true;
            this.Resumebtn.Click += new System.EventHandler(this.Resumebtn_Click);
            // 
            // Pausebtn
            // 
            this.Pausebtn.Location = new System.Drawing.Point(30, 45);
            this.Pausebtn.Margin = new System.Windows.Forms.Padding(5);
            this.Pausebtn.Name = "Pausebtn";
            this.Pausebtn.Size = new System.Drawing.Size(155, 55);
            this.Pausebtn.TabIndex = 52;
            this.Pausebtn.Text = "Pause Control";
            this.Pausebtn.UseVisualStyleBackColor = true;
            this.Pausebtn.Click += new System.EventHandler(this.Pausebtn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F);
            this.label15.Location = new System.Drawing.Point(15, 210);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 18);
            this.label15.TabIndex = 51;
            this.label15.Text = "Bias Channel:";
            // 
            // ReadBiasbtn
            // 
            this.ReadBiasbtn.Location = new System.Drawing.Point(215, 195);
            this.ReadBiasbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadBiasbtn.Name = "ReadBiasbtn";
            this.ReadBiasbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadBiasbtn.TabIndex = 49;
            this.ReadBiasbtn.Text = "Read Bias";
            this.ReadBiasbtn.UseVisualStyleBackColor = true;
            this.ReadBiasbtn.Click += new System.EventHandler(this.ReadBiasbtn_Click);
            // 
            // ReadPowerbtn
            // 
            this.ReadPowerbtn.Location = new System.Drawing.Point(30, 120);
            this.ReadPowerbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadPowerbtn.Name = "ReadPowerbtn";
            this.ReadPowerbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadPowerbtn.TabIndex = 48;
            this.ReadPowerbtn.Text = "Read Power";
            this.ReadPowerbtn.UseVisualStyleBackColor = true;
            this.ReadPowerbtn.Click += new System.EventHandler(this.ReadPowerbtn_Click);
            // 
            // ReadVpibtn
            // 
            this.ReadVpibtn.Location = new System.Drawing.Point(215, 357);
            this.ReadVpibtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadVpibtn.Name = "ReadVpibtn";
            this.ReadVpibtn.Size = new System.Drawing.Size(155, 55);
            this.ReadVpibtn.TabIndex = 46;
            this.ReadVpibtn.Text = "Read Vpi";
            this.ReadVpibtn.UseVisualStyleBackColor = true;
            this.ReadVpibtn.Click += new System.EventHandler(this.ReadVpibtn_Click);
            // 
            // ReadPolarbtn
            // 
            this.ReadPolarbtn.Location = new System.Drawing.Point(215, 45);
            this.ReadPolarbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadPolarbtn.Name = "ReadPolarbtn";
            this.ReadPolarbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadPolarbtn.TabIndex = 45;
            this.ReadPolarbtn.Text = "Read Polar";
            this.ReadPolarbtn.UseVisualStyleBackColor = true;
            this.ReadPolarbtn.Click += new System.EventHandler(this.ReadPolarbtn_Click);
            // 
            // Resetbtn
            // 
            this.Resetbtn.Location = new System.Drawing.Point(30, 195);
            this.Resetbtn.Margin = new System.Windows.Forms.Padding(5);
            this.Resetbtn.Name = "Resetbtn";
            this.Resetbtn.Size = new System.Drawing.Size(155, 55);
            this.Resetbtn.TabIndex = 44;
            this.Resetbtn.Text = "Reset";
            this.Resetbtn.UseVisualStyleBackColor = true;
            this.Resetbtn.Click += new System.EventHandler(this.Resetbtn_Click);
            // 
            // ReadStatusbtn
            // 
            this.ReadStatusbtn.Location = new System.Drawing.Point(30, 45);
            this.ReadStatusbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadStatusbtn.Name = "ReadStatusbtn";
            this.ReadStatusbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadStatusbtn.TabIndex = 43;
            this.ReadStatusbtn.Text = "Read Status";
            this.ReadStatusbtn.UseVisualStyleBackColor = true;
            this.ReadStatusbtn.Click += new System.EventHandler(this.ReadStatusbtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Resetbtn);
            this.groupBox4.Controls.Add(this.Pausebtn);
            this.groupBox4.Controls.Add(this.Resumebtn);
            this.groupBox4.Controls.Add(this.AutoModebtn);
            this.groupBox4.Controls.Add(this.ManualModebtn);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBox4.Location = new System.Drawing.Point(11, 18);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(411, 277);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Operation Setting";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.DitherAmpSetbtn);
            this.groupBox8.Controls.Add(this.label19);
            this.groupBox8.Controls.Add(this.DitherYIAmp_txBox);
            this.groupBox8.Controls.Add(this.DitherXQAmp_txBox);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.DitherYQAmp_txBox);
            this.groupBox8.Controls.Add(this.DitherXIAmp_txBox);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Location = new System.Drawing.Point(442, 549);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox8.Size = new System.Drawing.Size(429, 224);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "DitherAmplitude Setting";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(20, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 18);
            this.label8.TabIndex = 82;
            this.label8.Text = "*Input Range:1-9";
            // 
            // DitherAmpSetbtn
            // 
            this.DitherAmpSetbtn.Location = new System.Drawing.Point(276, 54);
            this.DitherAmpSetbtn.Margin = new System.Windows.Forms.Padding(5);
            this.DitherAmpSetbtn.Name = "DitherAmpSetbtn";
            this.DitherAmpSetbtn.Size = new System.Drawing.Size(113, 153);
            this.DitherAmpSetbtn.TabIndex = 54;
            this.DitherAmpSetbtn.Text = "Set Dither Amp";
            this.DitherAmpSetbtn.UseVisualStyleBackColor = true;
            this.DitherAmpSetbtn.Click += new System.EventHandler(this.DitherAmpSetbtn_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(36, 182);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(170, 18);
            this.label19.TabIndex = 62;
            this.label19.Text = "Set XQ Dither Amp:";
            // 
            // DitherYIAmp_txBox
            // 
            this.DitherYIAmp_txBox.Location = new System.Drawing.Point(208, 54);
            this.DitherYIAmp_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.DitherYIAmp_txBox.MaxLength = 1;
            this.DitherYIAmp_txBox.Name = "DitherYIAmp_txBox";
            this.DitherYIAmp_txBox.Size = new System.Drawing.Size(51, 28);
            this.DitherYIAmp_txBox.TabIndex = 55;
            this.DitherYIAmp_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DitherYIAmp_txBox_KeyPress);
            // 
            // DitherXQAmp_txBox
            // 
            this.DitherXQAmp_txBox.Location = new System.Drawing.Point(208, 179);
            this.DitherXQAmp_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.DitherXQAmp_txBox.MaxLength = 1;
            this.DitherXQAmp_txBox.Name = "DitherXQAmp_txBox";
            this.DitherXQAmp_txBox.Size = new System.Drawing.Size(51, 28);
            this.DitherXQAmp_txBox.TabIndex = 61;
            this.DitherXQAmp_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DitherXQAmp_txBox_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 60);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(170, 18);
            this.label16.TabIndex = 56;
            this.label16.Text = "Set YI Dither Amp:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(36, 142);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 18);
            this.label18.TabIndex = 60;
            this.label18.Text = "Set XI Dither Amp:";
            // 
            // DitherYQAmp_txBox
            // 
            this.DitherYQAmp_txBox.Location = new System.Drawing.Point(208, 97);
            this.DitherYQAmp_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.DitherYQAmp_txBox.MaxLength = 1;
            this.DitherYQAmp_txBox.Name = "DitherYQAmp_txBox";
            this.DitherYQAmp_txBox.Size = new System.Drawing.Size(51, 28);
            this.DitherYQAmp_txBox.TabIndex = 57;
            this.DitherYQAmp_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DitherYQAmp_txBox_KeyPress);
            // 
            // DitherXIAmp_txBox
            // 
            this.DitherXIAmp_txBox.Location = new System.Drawing.Point(208, 139);
            this.DitherXIAmp_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.DitherXIAmp_txBox.MaxLength = 1;
            this.DitherXIAmp_txBox.Name = "DitherXIAmp_txBox";
            this.DitherXIAmp_txBox.Size = new System.Drawing.Size(51, 28);
            this.DitherXIAmp_txBox.TabIndex = 59;
            this.DitherXIAmp_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DitherXIAmp_txBox_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(36, 100);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(170, 18);
            this.label17.TabIndex = 58;
            this.label17.Text = "Set YQ Dither Amp:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.PVpitxBox);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.QVpitxBox);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.IVpitxBox);
            this.groupBox7.Controls.Add(this.BiasChBox);
            this.groupBox7.Controls.Add(this.ReadStatusbtn);
            this.groupBox7.Controls.Add(this.ReadPolarbtn);
            this.groupBox7.Controls.Add(this.ReadVpibtn);
            this.groupBox7.Controls.Add(this.ReadPowerbtn);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.ReadBiasbtn);
            this.groupBox7.Location = new System.Drawing.Point(11, 302);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox7.Size = new System.Drawing.Size(411, 504);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Read Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 355);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 88;
            this.label3.Text = "P Vpi:";
            // 
            // PVpitxBox
            // 
            this.PVpitxBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PVpitxBox.Location = new System.Drawing.Point(97, 350);
            this.PVpitxBox.Margin = new System.Windows.Forms.Padding(2);
            this.PVpitxBox.MaxLength = 0;
            this.PVpitxBox.Name = "PVpitxBox";
            this.PVpitxBox.ReadOnly = true;
            this.PVpitxBox.Size = new System.Drawing.Size(100, 28);
            this.PVpitxBox.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 316);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 86;
            this.label2.Text = "Q Vpi:";
            // 
            // QVpitxBox
            // 
            this.QVpitxBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.QVpitxBox.Location = new System.Drawing.Point(97, 311);
            this.QVpitxBox.Margin = new System.Windows.Forms.Padding(2);
            this.QVpitxBox.MaxLength = 0;
            this.QVpitxBox.Name = "QVpitxBox";
            this.QVpitxBox.ReadOnly = true;
            this.QVpitxBox.Size = new System.Drawing.Size(100, 28);
            this.QVpitxBox.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 277);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 84;
            this.label1.Text = "I Vpi:";
            // 
            // IVpitxBox
            // 
            this.IVpitxBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.IVpitxBox.Location = new System.Drawing.Point(97, 272);
            this.IVpitxBox.Margin = new System.Windows.Forms.Padding(2);
            this.IVpitxBox.MaxLength = 0;
            this.IVpitxBox.Name = "IVpitxBox";
            this.IVpitxBox.ReadOnly = true;
            this.IVpitxBox.Size = new System.Drawing.Size(100, 28);
            this.IVpitxBox.TabIndex = 83;
            // 
            // BiasChBox
            // 
            this.BiasChBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BiasChBox.FormattingEnabled = true;
            this.BiasChBox.Items.AddRange(new object[] {
            "I",
            "Q",
            "P"});
            this.BiasChBox.Location = new System.Drawing.Point(138, 207);
            this.BiasChBox.Margin = new System.Windows.Forms.Padding(5);
            this.BiasChBox.Name = "BiasChBox";
            this.BiasChBox.Size = new System.Drawing.Size(58, 26);
            this.BiasChBox.TabIndex = 82;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReceive);
            this.groupBox2.Location = new System.Drawing.Point(892, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(475, 394);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Response of MBC";
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtReceive.Location = new System.Drawing.Point(28, 31);
            this.txtReceive.Margin = new System.Windows.Forms.Padding(5);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(423, 336);
            this.txtReceive.TabIndex = 0;
            this.txtReceive.Text = "";
            this.txtReceive.TextChanged += new System.EventHandler(this.txtReceive_TextChanged);
            // 
            // tmSend
            // 
            this.tmSend.Tick += new System.EventHandler(this.tmSend_Tick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(580, 781);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 35);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clean Data";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(731, 781);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 35);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.SetDACbtn);
            this.groupBox3.Controls.Add(this.SetDACBox);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.SetDACtxBox);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Location = new System.Drawing.Point(442, 395);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(429, 144);
            this.groupBox3.TabIndex = 81;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setting Bias Voltage";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(20, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(332, 18);
            this.label7.TabIndex = 81;
            this.label7.Text = "*This function works in manual mode!";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.OriginalDataTextBox);
            this.groupBox5.Location = new System.Drawing.Point(892, 422);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(475, 394);
            this.groupBox5.TabIndex = 82;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Original data";
            // 
            // OriginalDataTextBox
            // 
            this.OriginalDataTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OriginalDataTextBox.Location = new System.Drawing.Point(28, 31);
            this.OriginalDataTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.OriginalDataTextBox.Name = "OriginalDataTextBox";
            this.OriginalDataTextBox.ReadOnly = true;
            this.OriginalDataTextBox.Size = new System.Drawing.Size(423, 336);
            this.OriginalDataTextBox.TabIndex = 0;
            this.OriginalDataTextBox.Text = "";
            this.OriginalDataTextBox.TextChanged += new System.EventHandler(this.OriginalDataTextBox_TextChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 827);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IQ  Control Unit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.Timer tmSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ReadStatusbtn;
        private System.Windows.Forms.Button Resetbtn;
        private System.Windows.Forms.Button ReadPolarbtn;
        private System.Windows.Forms.Button ReadVpibtn;
        private System.Windows.Forms.Button ReadPowerbtn;
        private System.Windows.Forms.Button ReadBiasbtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button Pausebtn;
        private System.Windows.Forms.Button Resumebtn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button DitherAmpSetbtn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox DitherYQAmp_txBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox DitherXIAmp_txBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox DitherXQAmp_txBox;
        private System.Windows.Forms.TextBox DitherYIAmp_txBox;
        private System.Windows.Forms.ComboBox YIPolarBox;
        private System.Windows.Forms.ComboBox YQPolarBox;
        private System.Windows.Forms.ComboBox YPPolarBox;
        private System.Windows.Forms.ComboBox XPPolarBox;
        private System.Windows.Forms.ComboBox XQPolarBox;
        private System.Windows.Forms.ComboBox XIPolarBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button SetPolarbtn;
        private System.Windows.Forms.Button ManualModebtn;
        private System.Windows.Forms.Button AutoModebtn;
        private System.Windows.Forms.Button SetDACbtn;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox SetDACtxBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox SetDACBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox BiasChBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IVpitxBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PVpitxBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox QVpitxBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox OriginalDataTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

