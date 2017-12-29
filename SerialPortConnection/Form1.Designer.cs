namespace SerialPortConnection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Resumebtn = new System.Windows.Forms.Button();
            this.Pausebtn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.BiasArm_txBox = new System.Windows.Forms.TextBox();
            this.ReadBiasbtn = new System.Windows.Forms.Button();
            this.ReadPowerbtn = new System.Windows.Forms.Button();
            this.ReadDCbtn = new System.Windows.Forms.Button();
            this.ReadVpibtn = new System.Windows.Forms.Button();
            this.ReadPolarbtn = new System.Windows.Forms.Button();
            this.Resetbtn = new System.Windows.Forms.Button();
            this.ReadStatusbtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.readVpi = new System.Windows.Forms.Button();
            this.vpiXP = new System.Windows.Forms.TextBox();
            this.Vpi_YI = new System.Windows.Forms.Label();
            this.vpiXQ = new System.Windows.Forms.TextBox();
            this.vpiXI = new System.Windows.Forms.TextBox();
            this.vpiYP = new System.Windows.Forms.TextBox();
            this.vpiYQ = new System.Windows.Forms.TextBox();
            this.vpiYI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTimeSend = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbRcvStr = new System.Windows.Forms.RadioButton();
            this.rbRcv16 = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.rdSendStr = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.tmSend = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsSpNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsBaudRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDataBits = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStopBits = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsParity = new System.Windows.Forms.ToolStripStatusLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.DitherYIAmp_txBox = new System.Windows.Forms.TextBox();
            this.DitherAmpSetbtn = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.DitherYQAmp_txBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.DitherXIAmp_txBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.DitherXQAmp_txBox = new System.Windows.Forms.TextBox();
            this.YIPolarBox = new System.Windows.Forms.ComboBox();
            this.YQPolarBox = new System.Windows.Forms.ComboBox();
            this.YPPolarBox = new System.Windows.Forms.ComboBox();
            this.XPPolarBox = new System.Windows.Forms.ComboBox();
            this.XQPolarBox = new System.Windows.Forms.ComboBox();
            this.XIPolarBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.SetPolarbtn = new System.Windows.Forms.Button();
            this.ManualModebtn = new System.Windows.Forms.Button();
            this.AutoModebtn = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.SetDACBox = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.SetDACtxBox = new System.Windows.Forms.TextBox();
            this.SetDACbtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SetDACbtn);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.SetDACtxBox);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.AutoModebtn);
            this.groupBox1.Controls.Add(this.SetDACBox);
            this.groupBox1.Controls.Add(this.ManualModebtn);
            this.groupBox1.Controls.Add(this.Resumebtn);
            this.groupBox1.Controls.Add(this.Pausebtn);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.BiasArm_txBox);
            this.groupBox1.Controls.Add(this.ReadBiasbtn);
            this.groupBox1.Controls.Add(this.ReadPowerbtn);
            this.groupBox1.Controls.Add(this.ReadDCbtn);
            this.groupBox1.Controls.Add(this.ReadVpibtn);
            this.groupBox1.Controls.Add(this.ReadPolarbtn);
            this.groupBox1.Controls.Add(this.Resetbtn);
            this.groupBox1.Controls.Add(this.ReadStatusbtn);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(445, 687);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能列表";
            // 
            // Resumebtn
            // 
            this.Resumebtn.Location = new System.Drawing.Point(252, 448);
            this.Resumebtn.Margin = new System.Windows.Forms.Padding(5);
            this.Resumebtn.Name = "Resumebtn";
            this.Resumebtn.Size = new System.Drawing.Size(113, 31);
            this.Resumebtn.TabIndex = 53;
            this.Resumebtn.Text = "ResumeControl";
            this.Resumebtn.UseVisualStyleBackColor = true;
            this.Resumebtn.Click += new System.EventHandler(this.Resumebtn_Click);
            // 
            // Pausebtn
            // 
            this.Pausebtn.Location = new System.Drawing.Point(64, 448);
            this.Pausebtn.Margin = new System.Windows.Forms.Padding(5);
            this.Pausebtn.Name = "Pausebtn";
            this.Pausebtn.Size = new System.Drawing.Size(113, 31);
            this.Pausebtn.TabIndex = 52;
            this.Pausebtn.Text = "PauseControl";
            this.Pausebtn.UseVisualStyleBackColor = true;
            this.Pausebtn.Click += new System.EventHandler(this.Pausebtn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(88, 399);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 18);
            this.label15.TabIndex = 51;
            this.label15.Text = "偏压通道:";
            // 
            // BiasArm_txBox
            // 
            this.BiasArm_txBox.Location = new System.Drawing.Point(185, 396);
            this.BiasArm_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.BiasArm_txBox.MaxLength = 1;
            this.BiasArm_txBox.Name = "BiasArm_txBox";
            this.BiasArm_txBox.Size = new System.Drawing.Size(51, 28);
            this.BiasArm_txBox.TabIndex = 50;
            this.BiasArm_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BiasArm_txBox_KeyPress);
            // 
            // ReadBiasbtn
            // 
            this.ReadBiasbtn.Location = new System.Drawing.Point(252, 393);
            this.ReadBiasbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadBiasbtn.Name = "ReadBiasbtn";
            this.ReadBiasbtn.Size = new System.Drawing.Size(113, 31);
            this.ReadBiasbtn.TabIndex = 49;
            this.ReadBiasbtn.Text = "ReadBias";
            this.ReadBiasbtn.UseVisualStyleBackColor = true;
            this.ReadBiasbtn.Click += new System.EventHandler(this.ReadBiasbtn_Click);
            // 
            // ReadPowerbtn
            // 
            this.ReadPowerbtn.Location = new System.Drawing.Point(252, 329);
            this.ReadPowerbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadPowerbtn.Name = "ReadPowerbtn";
            this.ReadPowerbtn.Size = new System.Drawing.Size(113, 31);
            this.ReadPowerbtn.TabIndex = 48;
            this.ReadPowerbtn.Text = "ReadPower";
            this.ReadPowerbtn.UseVisualStyleBackColor = true;
            this.ReadPowerbtn.Click += new System.EventHandler(this.ReadPowerbtn_Click);
            // 
            // ReadDCbtn
            // 
            this.ReadDCbtn.Location = new System.Drawing.Point(64, 329);
            this.ReadDCbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadDCbtn.Name = "ReadDCbtn";
            this.ReadDCbtn.Size = new System.Drawing.Size(113, 31);
            this.ReadDCbtn.TabIndex = 47;
            this.ReadDCbtn.Text = "ReadDC";
            this.ReadDCbtn.UseVisualStyleBackColor = true;
            this.ReadDCbtn.Click += new System.EventHandler(this.ReadDCbtn_Click);
            // 
            // ReadVpibtn
            // 
            this.ReadVpibtn.Location = new System.Drawing.Point(252, 265);
            this.ReadVpibtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadVpibtn.Name = "ReadVpibtn";
            this.ReadVpibtn.Size = new System.Drawing.Size(113, 31);
            this.ReadVpibtn.TabIndex = 46;
            this.ReadVpibtn.Text = "ReadVpi";
            this.ReadVpibtn.UseVisualStyleBackColor = true;
            this.ReadVpibtn.Click += new System.EventHandler(this.ReadVpibtn_Click);
            // 
            // ReadPolarbtn
            // 
            this.ReadPolarbtn.Location = new System.Drawing.Point(64, 265);
            this.ReadPolarbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadPolarbtn.Name = "ReadPolarbtn";
            this.ReadPolarbtn.Size = new System.Drawing.Size(113, 31);
            this.ReadPolarbtn.TabIndex = 45;
            this.ReadPolarbtn.Text = "ReadPolar";
            this.ReadPolarbtn.UseVisualStyleBackColor = true;
            this.ReadPolarbtn.Click += new System.EventHandler(this.ReadPolarbtn_Click);
            // 
            // Resetbtn
            // 
            this.Resetbtn.Location = new System.Drawing.Point(64, 204);
            this.Resetbtn.Margin = new System.Windows.Forms.Padding(5);
            this.Resetbtn.Name = "Resetbtn";
            this.Resetbtn.Size = new System.Drawing.Size(113, 31);
            this.Resetbtn.TabIndex = 44;
            this.Resetbtn.Text = "Reset";
            this.Resetbtn.UseVisualStyleBackColor = true;
            this.Resetbtn.Click += new System.EventHandler(this.Resetbtn_Click);
            // 
            // ReadStatusbtn
            // 
            this.ReadStatusbtn.Location = new System.Drawing.Point(252, 204);
            this.ReadStatusbtn.Margin = new System.Windows.Forms.Padding(5);
            this.ReadStatusbtn.Name = "ReadStatusbtn";
            this.ReadStatusbtn.Size = new System.Drawing.Size(113, 31);
            this.ReadStatusbtn.TabIndex = 43;
            this.ReadStatusbtn.Text = "ReadStatus";
            this.ReadStatusbtn.UseVisualStyleBackColor = true;
            this.ReadStatusbtn.Click += new System.EventHandler(this.ReadStatusbtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.readVpi);
            this.groupBox4.Controls.Add(this.vpiXP);
            this.groupBox4.Controls.Add(this.Vpi_YI);
            this.groupBox4.Controls.Add(this.vpiXQ);
            this.groupBox4.Controls.Add(this.vpiXI);
            this.groupBox4.Controls.Add(this.vpiYP);
            this.groupBox4.Controls.Add(this.vpiYQ);
            this.groupBox4.Controls.Add(this.vpiYI);
            this.groupBox4.Location = new System.Drawing.Point(7, 37);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(417, 137);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "半波电压";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(344, 34);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 18);
            this.label11.TabIndex = 45;
            this.label11.Text = "Vpi_XP";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 34);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 18);
            this.label10.TabIndex = 44;
            this.label10.Text = "Vpi_XQ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(208, 34);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 18);
            this.label12.TabIndex = 43;
            this.label12.Text = "Vpi_XI";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(140, 34);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 18);
            this.label13.TabIndex = 42;
            this.label13.Text = "Vpi_YP";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(73, 34);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 18);
            this.label14.TabIndex = 41;
            this.label14.Text = "Vpi_YQ";
            // 
            // readVpi
            // 
            this.readVpi.Location = new System.Drawing.Point(288, 97);
            this.readVpi.Margin = new System.Windows.Forms.Padding(5);
            this.readVpi.Name = "readVpi";
            this.readVpi.Size = new System.Drawing.Size(113, 31);
            this.readVpi.TabIndex = 33;
            this.readVpi.Text = "读取";
            this.readVpi.UseVisualStyleBackColor = true;
            this.readVpi.Click += new System.EventHandler(this.readVpi_Click);
            // 
            // vpiXP
            // 
            this.vpiXP.Enabled = false;
            this.vpiXP.Location = new System.Drawing.Point(350, 65);
            this.vpiXP.Margin = new System.Windows.Forms.Padding(2);
            this.vpiXP.Name = "vpiXP";
            this.vpiXP.Size = new System.Drawing.Size(51, 28);
            this.vpiXP.TabIndex = 39;
            // 
            // Vpi_YI
            // 
            this.Vpi_YI.AutoSize = true;
            this.Vpi_YI.Location = new System.Drawing.Point(5, 34);
            this.Vpi_YI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Vpi_YI.Name = "Vpi_YI";
            this.Vpi_YI.Size = new System.Drawing.Size(62, 18);
            this.Vpi_YI.TabIndex = 40;
            this.Vpi_YI.Text = "Vpi_YI";
            // 
            // vpiXQ
            // 
            this.vpiXQ.Enabled = false;
            this.vpiXQ.Location = new System.Drawing.Point(281, 65);
            this.vpiXQ.Margin = new System.Windows.Forms.Padding(2);
            this.vpiXQ.Name = "vpiXQ";
            this.vpiXQ.Size = new System.Drawing.Size(51, 28);
            this.vpiXQ.TabIndex = 38;
            // 
            // vpiXI
            // 
            this.vpiXI.Enabled = false;
            this.vpiXI.Location = new System.Drawing.Point(213, 65);
            this.vpiXI.Margin = new System.Windows.Forms.Padding(2);
            this.vpiXI.Name = "vpiXI";
            this.vpiXI.Size = new System.Drawing.Size(51, 28);
            this.vpiXI.TabIndex = 37;
            this.vpiXI.TextChanged += new System.EventHandler(this.vpiXI_TextChanged);
            // 
            // vpiYP
            // 
            this.vpiYP.Enabled = false;
            this.vpiYP.Location = new System.Drawing.Point(145, 65);
            this.vpiYP.Margin = new System.Windows.Forms.Padding(2);
            this.vpiYP.Name = "vpiYP";
            this.vpiYP.Size = new System.Drawing.Size(51, 28);
            this.vpiYP.TabIndex = 36;
            // 
            // vpiYQ
            // 
            this.vpiYQ.Enabled = false;
            this.vpiYQ.Location = new System.Drawing.Point(76, 65);
            this.vpiYQ.Margin = new System.Windows.Forms.Padding(2);
            this.vpiYQ.Name = "vpiYQ";
            this.vpiYQ.Size = new System.Drawing.Size(51, 28);
            this.vpiYQ.TabIndex = 35;
            // 
            // vpiYI
            // 
            this.vpiYI.Enabled = false;
            this.vpiYI.Location = new System.Drawing.Point(8, 65);
            this.vpiYI.Margin = new System.Windows.Forms.Padding(2);
            this.vpiYI.Name = "vpiYI";
            this.vpiYI.Size = new System.Drawing.Size(51, 28);
            this.vpiYI.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(1342, 731);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(332, 18);
            this.label9.TabIndex = 31;
            this.label9.Text = "(16进制时，用空格或“，”将字节隔开)";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1678, 748);
            this.btnSend.Margin = new System.Windows.Forms.Padding(5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 37);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(1340, 701);
            this.txtSend.Margin = new System.Windows.Forms.Padding(5);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(421, 28);
            this.txtSend.TabIndex = 21;
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
            this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSend_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1345, 757);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "发送数据：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1657, 793);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "秒";
            // 
            // txtSecond
            // 
            this.txtSecond.Location = new System.Drawing.Point(1585, 785);
            this.txtSecond.Margin = new System.Windows.Forms.Padding(5);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(64, 28);
            this.txtSecond.TabIndex = 18;
            this.txtSecond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSecond_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1501, 787);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "时间间隔：";
            // 
            // cbTimeSend
            // 
            this.cbTimeSend.AutoSize = true;
            this.cbTimeSend.Location = new System.Drawing.Point(1345, 787);
            this.cbTimeSend.Margin = new System.Windows.Forms.Padding(5);
            this.cbTimeSend.Name = "cbTimeSend";
            this.cbTimeSend.Size = new System.Drawing.Size(142, 22);
            this.cbTimeSend.TabIndex = 16;
            this.cbTimeSend.Text = "定时发送数据";
            this.cbTimeSend.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbRcvStr);
            this.groupBox8.Controls.Add(this.rbRcv16);
            this.groupBox8.Location = new System.Drawing.Point(1789, 748);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox8.Size = new System.Drawing.Size(213, 54);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "接收数据格式";
            // 
            // rbRcvStr
            // 
            this.rbRcvStr.AutoSize = true;
            this.rbRcvStr.Location = new System.Drawing.Point(108, 21);
            this.rbRcvStr.Margin = new System.Windows.Forms.Padding(5);
            this.rbRcvStr.Name = "rbRcvStr";
            this.rbRcvStr.Size = new System.Drawing.Size(87, 22);
            this.rbRcvStr.TabIndex = 2;
            this.rbRcvStr.TabStop = true;
            this.rbRcvStr.Text = "字符串";
            this.rbRcvStr.UseVisualStyleBackColor = true;
            // 
            // rbRcv16
            // 
            this.rbRcv16.AutoSize = true;
            this.rbRcv16.Location = new System.Drawing.Point(13, 21);
            this.rbRcv16.Margin = new System.Windows.Forms.Padding(5);
            this.rbRcv16.Name = "rbRcv16";
            this.rbRcv16.Size = new System.Drawing.Size(87, 22);
            this.rbRcv16.TabIndex = 1;
            this.rbRcv16.TabStop = true;
            this.rbRcv16.Text = "16进制";
            this.rbRcv16.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radio1);
            this.groupBox7.Controls.Add(this.rdSendStr);
            this.groupBox7.Location = new System.Drawing.Point(1790, 674);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox7.Size = new System.Drawing.Size(201, 55);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "发送数据格式";
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Location = new System.Drawing.Point(13, 23);
            this.radio1.Margin = new System.Windows.Forms.Padding(5);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(87, 22);
            this.radio1.TabIndex = 7;
            this.radio1.TabStop = true;
            this.radio1.Text = "16进制";
            this.radio1.UseVisualStyleBackColor = true;
            // 
            // rdSendStr
            // 
            this.rdSendStr.AutoSize = true;
            this.rdSendStr.Location = new System.Drawing.Point(109, 23);
            this.rdSendStr.Margin = new System.Windows.Forms.Padding(5);
            this.rdSendStr.Name = "rdSendStr";
            this.rdSendStr.Size = new System.Drawing.Size(87, 22);
            this.rdSendStr.TabIndex = 6;
            this.rdSendStr.TabStop = true;
            this.rdSendStr.Text = "字符串";
            this.rdSendStr.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReceive);
            this.groupBox2.Location = new System.Drawing.Point(1529, 28);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(473, 549);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收方";
            // 
            // txtReceive
            // 
            this.txtReceive.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtReceive.Location = new System.Drawing.Point(27, 31);
            this.txtReceive.Margin = new System.Windows.Forms.Padding(5);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.Size = new System.Drawing.Size(423, 491);
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
            this.btnClear.Location = new System.Drawing.Point(1804, 604);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 35);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1902, 604);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 35);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSpNum,
            this.tsBaudRate,
            this.tsDataBits,
            this.tsStopBits,
            this.tsParity});
            this.statusStrip1.Location = new System.Drawing.Point(0, 822);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2035, 29);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsSpNum
            // 
            this.tsSpNum.Name = "tsSpNum";
            this.tsSpNum.Size = new System.Drawing.Size(141, 24);
            this.tsSpNum.Text = "串口号：未指定|";
            // 
            // tsBaudRate
            // 
            this.tsBaudRate.Name = "tsBaudRate";
            this.tsBaudRate.Size = new System.Drawing.Size(127, 24);
            this.tsBaudRate.Text = "波特率:未指定|";
            // 
            // tsDataBits
            // 
            this.tsDataBits.Name = "tsDataBits";
            this.tsDataBits.Size = new System.Drawing.Size(127, 24);
            this.tsDataBits.Text = "数据位:未指定|";
            // 
            // tsStopBits
            // 
            this.tsStopBits.Name = "tsStopBits";
            this.tsStopBits.Size = new System.Drawing.Size(127, 24);
            this.tsStopBits.Text = "停止位:未指定|";
            // 
            // tsParity
            // 
            this.tsParity.Name = "tsParity";
            this.tsParity.Size = new System.Drawing.Size(127, 24);
            this.tsParity.Text = "停止位:未指定|";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(486, 211);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(170, 18);
            this.label16.TabIndex = 56;
            this.label16.Text = "Set YI Dither Amp:";
            // 
            // DitherYIAmp_txBox
            // 
            this.DitherYIAmp_txBox.Location = new System.Drawing.Point(660, 208);
            this.DitherYIAmp_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.DitherYIAmp_txBox.MaxLength = 1;
            this.DitherYIAmp_txBox.Name = "DitherYIAmp_txBox";
            this.DitherYIAmp_txBox.Size = new System.Drawing.Size(51, 28);
            this.DitherYIAmp_txBox.TabIndex = 55;
            this.DitherYIAmp_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DitherYIAmp_txBox_KeyPress);
            // 
            // DitherAmpSetbtn
            // 
            this.DitherAmpSetbtn.Location = new System.Drawing.Point(727, 205);
            this.DitherAmpSetbtn.Margin = new System.Windows.Forms.Padding(5);
            this.DitherAmpSetbtn.Name = "DitherAmpSetbtn";
            this.DitherAmpSetbtn.Size = new System.Drawing.Size(113, 162);
            this.DitherAmpSetbtn.TabIndex = 54;
            this.DitherAmpSetbtn.Text = "Set Dither Amp";
            this.DitherAmpSetbtn.UseVisualStyleBackColor = true;
            this.DitherAmpSetbtn.Click += new System.EventHandler(this.DitherAmpSetbtn_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(487, 254);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(170, 18);
            this.label17.TabIndex = 58;
            this.label17.Text = "Set YQ Dither Amp:";
            // 
            // DitherYQAmp_txBox
            // 
            this.DitherYQAmp_txBox.Location = new System.Drawing.Point(661, 251);
            this.DitherYQAmp_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.DitherYQAmp_txBox.MaxLength = 1;
            this.DitherYQAmp_txBox.Name = "DitherYQAmp_txBox";
            this.DitherYQAmp_txBox.Size = new System.Drawing.Size(51, 28);
            this.DitherYQAmp_txBox.TabIndex = 57;
            this.DitherYQAmp_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DitherYQAmp_txBox_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(487, 299);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(170, 18);
            this.label18.TabIndex = 60;
            this.label18.Text = "Set XI Dither Amp:";
            // 
            // DitherXIAmp_txBox
            // 
            this.DitherXIAmp_txBox.Location = new System.Drawing.Point(661, 296);
            this.DitherXIAmp_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.DitherXIAmp_txBox.MaxLength = 1;
            this.DitherXIAmp_txBox.Name = "DitherXIAmp_txBox";
            this.DitherXIAmp_txBox.Size = new System.Drawing.Size(51, 28);
            this.DitherXIAmp_txBox.TabIndex = 59;
            this.DitherXIAmp_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DitherXIAmp_txBox_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(487, 342);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(170, 18);
            this.label19.TabIndex = 62;
            this.label19.Text = "Set XQ Dither Amp:";
            // 
            // DitherXQAmp_txBox
            // 
            this.DitherXQAmp_txBox.Location = new System.Drawing.Point(661, 339);
            this.DitherXQAmp_txBox.Margin = new System.Windows.Forms.Padding(2);
            this.DitherXQAmp_txBox.MaxLength = 1;
            this.DitherXQAmp_txBox.Name = "DitherXQAmp_txBox";
            this.DitherXQAmp_txBox.Size = new System.Drawing.Size(51, 28);
            this.DitherXQAmp_txBox.TabIndex = 61;
            this.DitherXQAmp_txBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DitherXQAmp_txBox_KeyPress);
            // 
            // YIPolarBox
            // 
            this.YIPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YIPolarBox.FormattingEnabled = true;
            this.YIPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.YIPolarBox.Location = new System.Drawing.Point(619, 430);
            this.YIPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.YIPolarBox.Name = "YIPolarBox";
            this.YIPolarBox.Size = new System.Drawing.Size(115, 26);
            this.YIPolarBox.TabIndex = 63;
            // 
            // YQPolarBox
            // 
            this.YQPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YQPolarBox.FormattingEnabled = true;
            this.YQPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.YQPolarBox.Location = new System.Drawing.Point(619, 483);
            this.YQPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.YQPolarBox.Name = "YQPolarBox";
            this.YQPolarBox.Size = new System.Drawing.Size(115, 26);
            this.YQPolarBox.TabIndex = 64;
            // 
            // YPPolarBox
            // 
            this.YPPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YPPolarBox.FormattingEnabled = true;
            this.YPPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.YPPolarBox.Location = new System.Drawing.Point(618, 540);
            this.YPPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.YPPolarBox.Name = "YPPolarBox";
            this.YPPolarBox.Size = new System.Drawing.Size(115, 26);
            this.YPPolarBox.TabIndex = 65;
            // 
            // XPPolarBox
            // 
            this.XPPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XPPolarBox.FormattingEnabled = true;
            this.XPPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.XPPolarBox.Location = new System.Drawing.Point(619, 696);
            this.XPPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.XPPolarBox.Name = "XPPolarBox";
            this.XPPolarBox.Size = new System.Drawing.Size(115, 26);
            this.XPPolarBox.TabIndex = 68;
            // 
            // XQPolarBox
            // 
            this.XQPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XQPolarBox.FormattingEnabled = true;
            this.XQPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.XQPolarBox.Location = new System.Drawing.Point(618, 640);
            this.XQPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.XQPolarBox.Name = "XQPolarBox";
            this.XQPolarBox.Size = new System.Drawing.Size(115, 26);
            this.XQPolarBox.TabIndex = 67;
            // 
            // XIPolarBox
            // 
            this.XIPolarBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XIPolarBox.FormattingEnabled = true;
            this.XIPolarBox.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.XIPolarBox.Location = new System.Drawing.Point(618, 587);
            this.XIPolarBox.Margin = new System.Windows.Forms.Padding(5);
            this.XIPolarBox.Name = "XIPolarBox";
            this.XIPolarBox.Size = new System.Drawing.Size(115, 26);
            this.XIPolarBox.TabIndex = 66;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(486, 433);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(125, 18);
            this.label20.TabIndex = 69;
            this.label20.Text = "Set YI Polar:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(486, 486);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 18);
            this.label21.TabIndex = 70;
            this.label21.Text = "Set YQ Polar:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(486, 543);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 18);
            this.label22.TabIndex = 71;
            this.label22.Text = "Set YP Polar:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(486, 590);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 18);
            this.label23.TabIndex = 72;
            this.label23.Text = "Set XI Polar:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(486, 643);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 18);
            this.label24.TabIndex = 73;
            this.label24.Text = "Set XQ Polar:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(485, 701);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(125, 18);
            this.label25.TabIndex = 74;
            this.label25.Text = "Set XP Polar:";
            // 
            // SetPolarbtn
            // 
            this.SetPolarbtn.Location = new System.Drawing.Point(784, 430);
            this.SetPolarbtn.Margin = new System.Windows.Forms.Padding(5);
            this.SetPolarbtn.Name = "SetPolarbtn";
            this.SetPolarbtn.Size = new System.Drawing.Size(113, 292);
            this.SetPolarbtn.TabIndex = 75;
            this.SetPolarbtn.Text = "Set Polar";
            this.SetPolarbtn.UseVisualStyleBackColor = true;
            this.SetPolarbtn.Click += new System.EventHandler(this.SetPolarbtn_Click);
            // 
            // ManualModebtn
            // 
            this.ManualModebtn.Location = new System.Drawing.Point(252, 512);
            this.ManualModebtn.Margin = new System.Windows.Forms.Padding(5);
            this.ManualModebtn.Name = "ManualModebtn";
            this.ManualModebtn.Size = new System.Drawing.Size(113, 31);
            this.ManualModebtn.TabIndex = 54;
            this.ManualModebtn.Text = "ManualMode";
            this.ManualModebtn.UseVisualStyleBackColor = true;
            this.ManualModebtn.Click += new System.EventHandler(this.ManualModebtn_Click);
            // 
            // AutoModebtn
            // 
            this.AutoModebtn.Location = new System.Drawing.Point(64, 512);
            this.AutoModebtn.Margin = new System.Windows.Forms.Padding(5);
            this.AutoModebtn.Name = "AutoModebtn";
            this.AutoModebtn.Size = new System.Drawing.Size(113, 31);
            this.AutoModebtn.TabIndex = 55;
            this.AutoModebtn.Text = "AutoMode";
            this.AutoModebtn.UseVisualStyleBackColor = true;
            this.AutoModebtn.Click += new System.EventHandler(this.AutoModebtn_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(51, 578);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(134, 18);
            this.label26.TabIndex = 77;
            this.label26.Text = "选择偏压通道：";
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
            this.SetDACBox.Location = new System.Drawing.Point(190, 575);
            this.SetDACBox.Margin = new System.Windows.Forms.Padding(5);
            this.SetDACBox.Name = "SetDACBox";
            this.SetDACBox.Size = new System.Drawing.Size(119, 26);
            this.SetDACBox.TabIndex = 76;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(59, 615);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(125, 18);
            this.label27.TabIndex = 79;
            this.label27.Text = "输出偏压(V)：";
            // 
            // SetDACtxBox
            // 
            this.SetDACtxBox.Location = new System.Drawing.Point(190, 611);
            this.SetDACtxBox.Margin = new System.Windows.Forms.Padding(2);
            this.SetDACtxBox.MaxLength = 10;
            this.SetDACtxBox.Name = "SetDACtxBox";
            this.SetDACtxBox.Size = new System.Drawing.Size(119, 28);
            this.SetDACtxBox.TabIndex = 78;
            // 
            // SetDACbtn
            // 
            this.SetDACbtn.Location = new System.Drawing.Point(319, 575);
            this.SetDACbtn.Margin = new System.Windows.Forms.Padding(5);
            this.SetDACbtn.Name = "SetDACbtn";
            this.SetDACbtn.Size = new System.Drawing.Size(113, 64);
            this.SetDACbtn.TabIndex = 80;
            this.SetDACbtn.Text = "SetDAC";
            this.SetDACbtn.UseVisualStyleBackColor = true;
            this.SetDACbtn.Click += new System.EventHandler(this.SetDACbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2035, 851);
            this.Controls.Add(this.SetPolarbtn);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.XPPolarBox);
            this.Controls.Add(this.XQPolarBox);
            this.Controls.Add(this.XIPolarBox);
            this.Controls.Add(this.YPPolarBox);
            this.Controls.Add(this.YQPolarBox);
            this.Controls.Add(this.YIPolarBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.DitherXQAmp_txBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.DitherXIAmp_txBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.DitherYQAmp_txBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.DitherYIAmp_txBox);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.DitherAmpSetbtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.txtSecond);
            this.Controls.Add(this.cbTimeSend);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上位机测试软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rbRcvStr;
        private System.Windows.Forms.RadioButton rbRcv16;
        private System.Windows.Forms.RadioButton rdSendStr;
        //private System.Windows.Forms.RadioButton rdse;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbTimeSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.Timer tmSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsSpNum;
        private System.Windows.Forms.ToolStripStatusLabel tsBaudRate;
        private System.Windows.Forms.ToolStripStatusLabel tsDataBits;
        private System.Windows.Forms.ToolStripStatusLabel tsStopBits;
        private System.Windows.Forms.ToolStripStatusLabel tsParity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button readVpi;
        private System.Windows.Forms.TextBox vpiXP;
        private System.Windows.Forms.Label Vpi_YI;
        private System.Windows.Forms.TextBox vpiXQ;
        private System.Windows.Forms.TextBox vpiXI;
        private System.Windows.Forms.TextBox vpiYP;
        private System.Windows.Forms.TextBox vpiYQ;
        private System.Windows.Forms.TextBox vpiYI;
        private System.Windows.Forms.Button ReadStatusbtn;
        private System.Windows.Forms.Button Resetbtn;
        private System.Windows.Forms.Button ReadPolarbtn;
        private System.Windows.Forms.Button ReadVpibtn;
        private System.Windows.Forms.Button ReadDCbtn;
        private System.Windows.Forms.Button ReadPowerbtn;
        private System.Windows.Forms.Button ReadBiasbtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox BiasArm_txBox;
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
    }
}

