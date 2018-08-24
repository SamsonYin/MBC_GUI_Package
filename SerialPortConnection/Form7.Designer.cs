namespace SerialPortConnection
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.OriginalDataTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SetDACbtn = new System.Windows.Forms.Button();
            this.SetDACtxBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SetPolarbtn = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.PolarBox = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ReadLaserPowerbtn = new System.Windows.Forms.Button();
            this.ReadDCbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.VpitxBox = new System.Windows.Forms.TextBox();
            this.ReadStatusbtn = new System.Windows.Forms.Button();
            this.ReadPolarbtn = new System.Windows.Forms.Button();
            this.ReadVpibtn = new System.Windows.Forms.Button();
            this.ReadModulatorPowerbtn = new System.Windows.Forms.Button();
            this.ReadBiasbtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LockCurrentPointbtn = new System.Windows.Forms.Button();
            this.JumpVpiPbtn = new System.Windows.Forms.Button();
            this.JumpVpiNbtn = new System.Windows.Forms.Button();
            this.Resetbtn = new System.Windows.Forms.Button();
            this.Pausebtn = new System.Windows.Forms.Button();
            this.Resumebtn = new System.Windows.Forms.Button();
            this.AutoModebtn = new System.Windows.Forms.Button();
            this.ManualModebtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tmSend = new System.Windows.Forms.Timer(this.components);
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.OriginalDataTextBox);
            this.groupBox5.Location = new System.Drawing.Point(892, 331);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(475, 295);
            this.groupBox5.TabIndex = 108;
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
            this.OriginalDataTextBox.Size = new System.Drawing.Size(423, 245);
            this.OriginalDataTextBox.TabIndex = 0;
            this.OriginalDataTextBox.Text = "";
            this.OriginalDataTextBox.TextChanged += new System.EventHandler(this.OriginalDataTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReceive);
            this.groupBox2.Location = new System.Drawing.Point(892, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(475, 295);
            this.groupBox2.TabIndex = 107;
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
            this.txtReceive.Size = new System.Drawing.Size(423, 245);
            this.txtReceive.TabIndex = 0;
            this.txtReceive.Text = "";
            this.txtReceive.TextChanged += new System.EventHandler(this.txtReceive_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(690, 566);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 35);
            this.btnExit.TabIndex = 105;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(539, 566);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 35);
            this.btnClear.TabIndex = 106;
            this.btnClear.Text = "Clean Data";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.SetDACbtn);
            this.groupBox3.Controls.Add(this.SetDACtxBox);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Location = new System.Drawing.Point(11, 503);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(411, 123);
            this.groupBox3.TabIndex = 102;
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
            // SetDACbtn
            // 
            this.SetDACbtn.Location = new System.Drawing.Point(287, 53);
            this.SetDACbtn.Margin = new System.Windows.Forms.Padding(5);
            this.SetDACbtn.Name = "SetDACbtn";
            this.SetDACbtn.Size = new System.Drawing.Size(113, 55);
            this.SetDACbtn.TabIndex = 80;
            this.SetDACbtn.Text = "SetDAC";
            this.SetDACbtn.UseVisualStyleBackColor = true;
            this.SetDACbtn.Click += new System.EventHandler(this.SetDACbtn_Click);
            // 
            // SetDACtxBox
            // 
            this.SetDACtxBox.Location = new System.Drawing.Point(153, 67);
            this.SetDACtxBox.Margin = new System.Windows.Forms.Padding(2);
            this.SetDACtxBox.MaxLength = 10;
            this.SetDACtxBox.Name = "SetDACtxBox";
            this.SetDACtxBox.Size = new System.Drawing.Size(119, 28);
            this.SetDACtxBox.TabIndex = 78;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 71);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(143, 18);
            this.label27.TabIndex = 79;
            this.label27.Text = "Set Voltage(V):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SetPolarbtn);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.PolarBox);
            this.groupBox1.Location = new System.Drawing.Point(11, 383);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(411, 100);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Point Setting";
            // 
            // SetPolarbtn
            // 
            this.SetPolarbtn.Location = new System.Drawing.Point(279, 27);
            this.SetPolarbtn.Margin = new System.Windows.Forms.Padding(5);
            this.SetPolarbtn.Name = "SetPolarbtn";
            this.SetPolarbtn.Size = new System.Drawing.Size(113, 55);
            this.SetPolarbtn.TabIndex = 75;
            this.SetPolarbtn.Text = "Set Polar";
            this.SetPolarbtn.UseVisualStyleBackColor = true;
            this.SetPolarbtn.Click += new System.EventHandler(this.SetPolarbtn_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 43);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 18);
            this.label20.TabIndex = 69;
            this.label20.Text = "Set Polar:";
            // 
            // PolarBox
            // 
            this.PolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PolarBox.FormattingEnabled = true;
            this.PolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.PolarBox.Location = new System.Drawing.Point(137, 40);
            this.PolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.PolarBox.Name = "PolarBox";
            this.PolarBox.Size = new System.Drawing.Size(115, 26);
            this.PolarBox.TabIndex = 63;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ReadLaserPowerbtn);
            this.groupBox7.Controls.Add(this.ReadDCbtn);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.VpitxBox);
            this.groupBox7.Controls.Add(this.ReadStatusbtn);
            this.groupBox7.Controls.Add(this.ReadPolarbtn);
            this.groupBox7.Controls.Add(this.ReadVpibtn);
            this.groupBox7.Controls.Add(this.ReadModulatorPowerbtn);
            this.groupBox7.Controls.Add(this.ReadBiasbtn);
            this.groupBox7.Location = new System.Drawing.Point(438, 18);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox7.Size = new System.Drawing.Size(411, 328);
            this.groupBox7.TabIndex = 100;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Read Parameters";
            // 
            // ReadLaserPowerbtn
            // 
            this.ReadLaserPowerbtn.Location = new System.Drawing.Point(204, 181);
            this.ReadLaserPowerbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadLaserPowerbtn.Name = "ReadLaserPowerbtn";
            this.ReadLaserPowerbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadLaserPowerbtn.TabIndex = 90;
            this.ReadLaserPowerbtn.Text = "Read Laser Channel Power";
            this.ReadLaserPowerbtn.UseVisualStyleBackColor = true;
            this.ReadLaserPowerbtn.Click += new System.EventHandler(this.ReadLaserPowerbtn_Click);
            // 
            // ReadDCbtn
            // 
            this.ReadDCbtn.Location = new System.Drawing.Point(204, 106);
            this.ReadDCbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadDCbtn.Name = "ReadDCbtn";
            this.ReadDCbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadDCbtn.TabIndex = 89;
            this.ReadDCbtn.Text = "Read DC";
            this.ReadDCbtn.UseVisualStyleBackColor = true;
            this.ReadDCbtn.Click += new System.EventHandler(this.ReadDCbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 274);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 84;
            this.label1.Text = "Vpi:";
            // 
            // VpitxBox
            // 
            this.VpitxBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.VpitxBox.Location = new System.Drawing.Point(86, 269);
            this.VpitxBox.Margin = new System.Windows.Forms.Padding(2);
            this.VpitxBox.MaxLength = 0;
            this.VpitxBox.Name = "VpitxBox";
            this.VpitxBox.ReadOnly = true;
            this.VpitxBox.Size = new System.Drawing.Size(100, 28);
            this.VpitxBox.TabIndex = 83;
            // 
            // ReadStatusbtn
            // 
            this.ReadStatusbtn.Location = new System.Drawing.Point(19, 31);
            this.ReadStatusbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadStatusbtn.Name = "ReadStatusbtn";
            this.ReadStatusbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadStatusbtn.TabIndex = 43;
            this.ReadStatusbtn.Text = "Read Status";
            this.ReadStatusbtn.UseVisualStyleBackColor = true;
            this.ReadStatusbtn.Click += new System.EventHandler(this.ReadStatusbtn_Click);
            // 
            // ReadPolarbtn
            // 
            this.ReadPolarbtn.Location = new System.Drawing.Point(204, 31);
            this.ReadPolarbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadPolarbtn.Name = "ReadPolarbtn";
            this.ReadPolarbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadPolarbtn.TabIndex = 45;
            this.ReadPolarbtn.Text = "Read Polar";
            this.ReadPolarbtn.UseVisualStyleBackColor = true;
            this.ReadPolarbtn.Click += new System.EventHandler(this.ReadPolarbtn_Click);
            // 
            // ReadVpibtn
            // 
            this.ReadVpibtn.Location = new System.Drawing.Point(204, 256);
            this.ReadVpibtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadVpibtn.Name = "ReadVpibtn";
            this.ReadVpibtn.Size = new System.Drawing.Size(155, 55);
            this.ReadVpibtn.TabIndex = 46;
            this.ReadVpibtn.Text = "Read Vpi";
            this.ReadVpibtn.UseVisualStyleBackColor = true;
            this.ReadVpibtn.Click += new System.EventHandler(this.ReadVpibtn_Click);
            // 
            // ReadModulatorPowerbtn
            // 
            this.ReadModulatorPowerbtn.Location = new System.Drawing.Point(19, 181);
            this.ReadModulatorPowerbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadModulatorPowerbtn.Name = "ReadModulatorPowerbtn";
            this.ReadModulatorPowerbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadModulatorPowerbtn.TabIndex = 48;
            this.ReadModulatorPowerbtn.Text = "Read Modulator Channel Power";
            this.ReadModulatorPowerbtn.UseVisualStyleBackColor = true;
            this.ReadModulatorPowerbtn.Click += new System.EventHandler(this.ReadModulatorPowerbtn_Click);
            // 
            // ReadBiasbtn
            // 
            this.ReadBiasbtn.Location = new System.Drawing.Point(19, 106);
            this.ReadBiasbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadBiasbtn.Name = "ReadBiasbtn";
            this.ReadBiasbtn.Size = new System.Drawing.Size(155, 55);
            this.ReadBiasbtn.TabIndex = 49;
            this.ReadBiasbtn.Text = "Read Bias";
            this.ReadBiasbtn.UseVisualStyleBackColor = true;
            this.ReadBiasbtn.Click += new System.EventHandler(this.ReadBiasbtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LockCurrentPointbtn);
            this.groupBox4.Controls.Add(this.JumpVpiPbtn);
            this.groupBox4.Controls.Add(this.JumpVpiNbtn);
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
            this.groupBox4.Size = new System.Drawing.Size(411, 344);
            this.groupBox4.TabIndex = 99;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Operation Setting";
            // 
            // LockCurrentPointbtn
            // 
            this.LockCurrentPointbtn.Location = new System.Drawing.Point(30, 269);
            this.LockCurrentPointbtn.Margin = new System.Windows.Forms.Padding(5);
            this.LockCurrentPointbtn.Name = "LockCurrentPointbtn";
            this.LockCurrentPointbtn.Size = new System.Drawing.Size(155, 55);
            this.LockCurrentPointbtn.TabIndex = 58;
            this.LockCurrentPointbtn.Text = "Lock Current Point";
            this.LockCurrentPointbtn.UseVisualStyleBackColor = true;
            this.LockCurrentPointbtn.Click += new System.EventHandler(this.LockCurrentPointbtn_Click);
            // 
            // JumpVpiPbtn
            // 
            this.JumpVpiPbtn.Location = new System.Drawing.Point(215, 195);
            this.JumpVpiPbtn.Margin = new System.Windows.Forms.Padding(5);
            this.JumpVpiPbtn.Name = "JumpVpiPbtn";
            this.JumpVpiPbtn.Size = new System.Drawing.Size(155, 55);
            this.JumpVpiPbtn.TabIndex = 57;
            this.JumpVpiPbtn.Text = "JumpVpi+";
            this.JumpVpiPbtn.UseVisualStyleBackColor = true;
            this.JumpVpiPbtn.Click += new System.EventHandler(this.JumpVpiPbtn_Click);
            // 
            // JumpVpiNbtn
            // 
            this.JumpVpiNbtn.Location = new System.Drawing.Point(30, 195);
            this.JumpVpiNbtn.Margin = new System.Windows.Forms.Padding(5);
            this.JumpVpiNbtn.Name = "JumpVpiNbtn";
            this.JumpVpiNbtn.Size = new System.Drawing.Size(155, 55);
            this.JumpVpiNbtn.TabIndex = 56;
            this.JumpVpiNbtn.Text = "JumpVpi-";
            this.JumpVpiNbtn.UseVisualStyleBackColor = true;
            this.JumpVpiNbtn.Click += new System.EventHandler(this.JumpVpiNbtn_Click);
            // 
            // Resetbtn
            // 
            this.Resetbtn.Location = new System.Drawing.Point(215, 269);
            this.Resetbtn.Margin = new System.Windows.Forms.Padding(5);
            this.Resetbtn.Name = "Resetbtn";
            this.Resetbtn.Size = new System.Drawing.Size(155, 55);
            this.Resetbtn.TabIndex = 44;
            this.Resetbtn.Text = "Reset";
            this.Resetbtn.UseVisualStyleBackColor = true;
            this.Resetbtn.Click += new System.EventHandler(this.Resetbtn_Click);
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
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1390, 644);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form7";
            this.Text = "HF Control Unit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form7_FormClosing);
            this.Load += new System.EventHandler(this.Form7_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox OriginalDataTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SetDACbtn;
        private System.Windows.Forms.TextBox SetDACtxBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SetPolarbtn;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox PolarBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button ReadDCbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox VpitxBox;
        private System.Windows.Forms.Button ReadStatusbtn;
        private System.Windows.Forms.Button ReadPolarbtn;
        private System.Windows.Forms.Button ReadVpibtn;
        private System.Windows.Forms.Button ReadModulatorPowerbtn;
        private System.Windows.Forms.Button ReadBiasbtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button JumpVpiPbtn;
        private System.Windows.Forms.Button JumpVpiNbtn;
        private System.Windows.Forms.Button Resetbtn;
        private System.Windows.Forms.Button Pausebtn;
        private System.Windows.Forms.Button Resumebtn;
        private System.Windows.Forms.Button AutoModebtn;
        private System.Windows.Forms.Button ManualModebtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer tmSend;
        private System.Windows.Forms.Button ReadLaserPowerbtn;
        private System.Windows.Forms.Button LockCurrentPointbtn;
    }
}