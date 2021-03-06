﻿using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SerialPortConnection
{
    public partial class Form2 : Form
    {
        public static Form2 MainWindow = null;
        private Button btnSwitch;
        private ComboBox cbSerial;
        private Label label1;

        SerialPort sp1 = new SerialPort();
        //sp1.ReceivedBytesThreshold = 1;//只要有1个字符送达端口时便触发DataReceived事件 
        private delegate void ShowFormDelegate();
        Form MBC_Control_Unit = null;
        //ShowFormDelegate ShowFormDelegateCommand = null;

        public Form2()
        {
            InitializeComponent();
            MainWindow = this;
        }

        private void ShowForm()
        {
            switch (Common.MBCVersion)
            {
                case 1:
                    sp1.Close();
                    MBC_Control_Unit = new Form1();
                    this.Hide();
                    MBC_Control_Unit.Show();
                    Common.formstatus = 1;
                    //DPIQ
                    break;
                case 2:
                    sp1.Close();
                    MBC_Control_Unit = new Form3();
                    this.Hide();
                    MBC_Control_Unit.Show();
                    Common.formstatus = 1;
                    //IQ
                    break;
                case 3:
                    sp1.Close();
                    MBC_Control_Unit = new Form4();
                    this.Hide();
                    MBC_Control_Unit.Show();
                    Common.formstatus = 1;
                    //MZM
                    break;
                case 4:
                    sp1.Close();
                    MBC_Control_Unit = new Form5();
                    this.Hide();
                    MBC_Control_Unit.Show();
                    Common.formstatus = 1;
                    // Q
                    break;
                case 5:
                    sp1.Close();
                    MBC_Control_Unit = new Form6();
                    this.Hide();
                    MBC_Control_Unit.Show();
                    Common.formstatus = 1;
                    //NULL
                    break;
                case 6:
                    sp1.Close();
                    MBC_Control_Unit = new Form7();
                    this.Hide();
                    MBC_Control_Unit.Show();
                    Common.formstatus = 1;
                    //Q_Ditherless
                    break;
                default:
                    MessageBox.Show("Unable to launch control unit,please try again!", "Error 001"); //控制器响应异常，无法分辨控制器版本
                    sp1.Close();
                    //btnSwitch.Text = "打开串口";
                    break;
            }
            //sp1.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("No serial port was detected！", "Error 002");     //没有检测到串口
                return;
            }

            //添加串口项目
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口
                //System.Diagnostics.Debug.WriteLine(s);
                cbSerial.Items.Add(s);
            }

            Control.CheckForIllegalCrossThreadCalls = false;    //这个类中我们不检查跨线程的调用是否合法(因为.net 2.0以后加强了安全机制,，不允许在winform中直接跨线程访问控件的属性)
            sp1.DataReceived += new SerialDataReceivedEventHandler(sp1_DataReceived);
            //sp1.ReceivedBytesThreshold = 1;

            //准备就绪              
            sp1.DtrEnable = true;
            sp1.RtsEnable = true;
            //设置数据读取超时为1秒
            sp1.ReadTimeout = 1000;

            sp1.Close();

        }

        public static class Common
        {
            public static int MBCVersion;
            public static int formstatus;
            public static string serialName;
        }

        //接收控制器返回的数据
        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp1.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了
            {
                byte[] byteRead = new byte[sp1.BytesToRead];    //BytesToRead:sp1接收的字符个数
                try
                {
                    Byte[] receivedData = new Byte[sp1.BytesToRead];        //创建接收字节数组
                    sp1.Read(receivedData, 0, receivedData.Length);         //读取数据
                    sp1.DiscardInBuffer();                                  //清空SerialPort控件的Buffer
                    string strRcv = null;
                    //int decNum = 0;//存储十进制
                    for (int i = 0; i < receivedData.Length; i++) //窗体显示
                    {
                        strRcv += receivedData[i].ToString("X2");  //16进制显示
                    }
                    Common.MBCVersion = receivedData[1];
                    if (receivedData[0] == 170)
                    {
                        this.BeginInvoke(new MethodInvoker(() => ShowForm()));
                     }
                    else
                    {
                        MessageBox.Show("Unable to establish communication with MBC,please try again!", "Error 003");    //控制器响应异常
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error 004");
                    //txtSend.Text = "";
                }
            }
            else
            {
                MessageBox.Show("The serial port is closed. Please open the serial port", "Error 005");
            }
        }

        //串口开关按钮
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            //serialPort1.IsOpen
            if (!sp1.IsOpen) //(btnSwitch.Text == "打开串口") || (!sp1.IsOpen))
            {
                if (Common.formstatus == 0)
                {
                    try
                    {
                        //设置串口号
                        Common.serialName = cbSerial.SelectedItem.ToString();
                        sp1.PortName = Common.serialName;

                        sp1.BaudRate = 57600;
                        sp1.DataBits = 8;
                        sp1.StopBits = StopBits.One;
                        sp1.Parity = Parity.None;

                        if (sp1.IsOpen == true)//如果打开状态，则先关闭一下
                        {
                            sp1.Close();
                        }

                        sp1.Open();     //打开串口
                        //btnSwitch.Text = "关闭串口";

                        string[] strArray = { "aa", "0", "0", "0", "0", "0", "0" };

                        int byteBufferLength = strArray.Length;
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i] == "")
                            {
                                byteBufferLength--;
                            }
                        }
                        byte[] byteBuffer = new byte[byteBufferLength];
                        int ii = 0;
                        for (int i = 0; i < strArray.Length; i++)        //对获取的字符做相加运算
                        {
                            Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);

                            int decNum = 0;
                            if (strArray[i] == "")
                            {
                                //ii--;     //加上此句是错误的，下面的continue以延缓了一个ii，不与i同步
                                continue;
                            }
                            else
                            {
                                decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 
                            }

                            //try    //防止输错，使其只能输入一个字节的字符
                            //{
                            byteBuffer[ii] = Convert.ToByte(decNum);
                            //}
                            //catch (System.Exception ex)
                            //{
                            //    MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                            //    //tmSend.Enabled = false;
                            //    return;
                            //}

                            ii++;
                        }
                        sp1.Write(byteBuffer, 0, byteBuffer.Length);
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Please select the serial port to use this function!", "Error 006");
                        //tmSend.Enabled = false;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Control Unit has been launched!", "Error 007");
                }
            }
            else
            {
                sp1.Close();                    //关闭串口
            }
        }

        //关闭时事件
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp1.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btnSwitch = new System.Windows.Forms.Button();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(298, 46);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(82, 31);
            this.btnSwitch.TabIndex = 10;
            this.btnSwitch.Text = "Launch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // cbSerial
            // 
            this.cbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Location = new System.Drawing.Point(197, 51);
            this.cbSerial.Margin = new System.Windows.Forms.Padding(5);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(91, 26);
            this.cbSerial.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Serial Port:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(435, 130);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSerial);
            this.Controls.Add(this.btnSwitch);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MBC Control Unit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
