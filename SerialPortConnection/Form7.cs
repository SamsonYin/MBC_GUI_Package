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
using static SerialPortConnection.Form2;
using System.Runtime.InteropServices;

namespace SerialPortConnection
{
    public partial class Form7 : Form
    {
        SerialPort sp1 = new SerialPort();

        public Form7()
        {
            InitializeComponent();
        }

        public static bool Delay_s(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }

        public static void Delay_ms(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //预设Polar值
            PolarBox.SelectedIndex = 0;

            //预设控件状态
            Resumebtn.Enabled = false;
            AutoModebtn.Enabled = false;
            LockCurrentPointbtn.Enabled = false;

            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("Fail to searching serial port！", "Error 033");
                return;
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

            sp1.PortName = Common.serialName;
            sp1.BaudRate = 57600;
            sp1.DataBits = 8;
            sp1.StopBits = StopBits.One;
            sp1.Parity = Parity.None;
            try
            {
                sp1.Open();
            }
            catch
            {
                MessageBox.Show("Connection exception, please restart the program", "Error 034");
            }
        }

        public static class FormParameter
        {
            public static string strRcv;
            public static uint byteID;
            public static int UART_CMD;
            public static int mode_flag;
            public static uint arm;
            public static string dither_amp;
            public static uint shortDataLength = 9;
        }

        [StructLayout(LayoutKind.Explicit, Size = 8)]
        public struct float_U32
        {
            [FieldOffset(0)] public uint intData;
            [FieldOffset(0)] public float floatData;
        }

        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(50);
            if (sp1.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了
            {
                byte[] byteRead = new byte[sp1.BytesToRead];    //BytesToRead:sp1接收的字符个数
                //if (rdSendStr.Checked)                          //'发送字符串'单选按钮
                //{
                //    txtReceive.Text += sp1.ReadLine() + "\r\n"; //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                //    sp1.DiscardInBuffer();                      //清空SerialPort控件的Buffer 
                //}
                //else                                            //'发送16进制按钮'
                //{
                if (sp1.BytesToRead <= 0)
                {
                    MessageBox.Show("Please open a serial port!", "Error 032");
                }
                else
                {
                    try
                    {
                        Byte[] receivedData = new Byte[FormParameter.shortDataLength];   //直接收9个byte  //new Byte[sp1.BytesToRead];        //创建接收字节数组
                        sp1.Read(receivedData, 0, receivedData.Length);         //读取数据
                                                                                //string text = sp1.Read();   //Encoding.ASCII.GetString(receivedData);
                        sp1.DiscardInBuffer();                                  //清空SerialPort控件的Buffer
                                                                                //这是用以显示字符串
                                                                                //    string strRcv = null;
                                                                                //    for (int i = 0; i < receivedData.Length; i++ )
                                                                                //    {
                                                                                //        strRcv += ((char)Convert.ToInt32(receivedData[i])) ;
                                                                                //    }
                                                                                //    txtReceive.Text += strRcv + "\r\n";             //显示信息
                                                                                //}
                        FormParameter.strRcv = null;
                        //int decNum = 0;//存储十进制
                        for (int i = 0; i < receivedData.Length; i++) //窗体显示
                        {
                            FormParameter.strRcv += receivedData[i].ToString("X2");  //16进制显示
                        }
                        ////输出当前时间
                        //DateTime dt = DateTime.Now;
                        //txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        //txtReceive.SelectAll();
                        //txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        FormParameter.byteID = receivedData[0];
                        UART_Handler(receivedData);  //receivedData是收到的数据，数据格式为十进制
                                                     //txtReceive.Text += FormParameter.strRcv + "\r\n";
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error 008");
                        //txtSend.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please open a serial port!", "Error 009");
            }
        }

        private void UART_Handler(Byte[] uart_result)
        {
            OriginalDataTextBox.Text += FormParameter.strRcv + "\r\n";
            switch (FormParameter.byteID)
            {
                case 102:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 102)
                        {
                            float_U32 DCvalue = new float_U32();
                            DCvalue.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                            DCvalue.intData = DCvalue.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                            DCvalue.intData = DCvalue.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                            DCvalue.intData = DCvalue.intData + (Convert.ToUInt32(uart_result[1]));
                            txtReceive.Text += "DC = " + (Convert.ToString(DCvalue.floatData)) + " \r\n";
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 103:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 103)
                        {
                            float_U32 Power = new float_U32();
                            Power.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[1]));
                            txtReceive.Text += "Modulator Channel Power = " + (Convert.ToString(Power.floatData)) + "uW \r\n";
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 104:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 104)
                        {
                            float_U32 bias = new float_U32();
                            bias.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                            bias.intData = bias.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                            bias.intData = bias.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                            bias.intData = bias.intData + (Convert.ToUInt32(uart_result[1]));
                            txtReceive.Text += "Bias Voltage:" + (Convert.ToString(bias.floatData)) + " V\r\n";
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 105:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 105)
                        {
                            if (uart_result[5] == 17)
                            {
                                float_U32 vpi = new float_U32();
                                vpi.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[1]));
                                txtReceive.Text += "Vpi:" + (Convert.ToString(vpi.floatData)) + " V\r\n";
                                VpitxBox.Text = Convert.ToString(vpi.floatData) + "V";
                            }
                            else
                            {
                                txtReceive.Text += "Read Vpi Error. Please try again. \r\n";
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 107:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 107)
                        {
                            switch (uart_result[1])
                            {
                                case 17:
                                    {
                                        if (FormParameter.mode_flag == 2)
                                        {
                                            txtReceive.Text += "Manual Mode Set! \r\n";
                                            AutoModebtn.Enabled = true;
                                            ManualModebtn.Enabled = false;
                                            LockCurrentPointbtn.Enabled = true;
                                        }
                                        else if (FormParameter.mode_flag == 1)
                                        {
                                            txtReceive.Text += "Auto Mode Set! \r\n";
                                            AutoModebtn.Enabled = false;
                                            ManualModebtn.Enabled = true;
                                            LockCurrentPointbtn.Enabled = false;
                                        }
                                        break;
                                    }
                                case 119:
                                    {
                                        txtReceive.Text += "This function cannot be used now, please try later. \r\n";
                                        break;
                                    }
                                case 136:
                                    {
                                        txtReceive.Text += "This command is unavailable in Pause Conrol Mode. \r\n";
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "Error! \r\n";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 108:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 108)
                        {
                            switch (uart_result[1])
                            {
                                case 17:
                                    {
                                        txtReceive.Text += "Output voltage has been Updated! \r\n";
                                        //Resumebtn.Enabled = true;
                                        break;
                                    }
                                case 136:
                                    {
                                        txtReceive.Text += "Output voltage update failed. \r\n";
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "Error! \r\n";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 109:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 109)
                        {
                            switch (uart_result[1])
                            {
                                case 17:
                                    {
                                        txtReceive.Text += "Polar has been successfully set. \r\n";
                                        break;
                                    }
                                case 136:
                                    {
                                        txtReceive.Text += "Unalbe to set polar, please try again. \r\n";
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "Error! \r\n";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 111:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 111)
                        {
                            switch (uart_result[1])
                            {
                                case 17:
                                    {
                                        txtReceive.Text += "JumpVpi succeed! \r\n";
                                        Resumebtn.Enabled = false;
                                        break;
                                    }
                                case 136:
                                    {
                                        txtReceive.Text += "Error:Unable to set JumpVpi! \r\n";
                                        Resumebtn.Enabled = false;
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "Error! \r\n";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 112:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 112)
                        {
                            switch (uart_result[1])
                            {
                                case 1:
                                    {
                                        txtReceive.Text += "Stablizing. \r\n";
                                        break;
                                    }
                                case 2:
                                    {
                                        txtReceive.Text += "Stablized. \r\n";
                                        break;
                                    }
                                case 3:
                                    {
                                        txtReceive.Text += "Modulator channel light too weak. \r\n";
                                        break;
                                    }
                                case 4:
                                    {
                                        txtReceive.Text += "Modulator channel light too strong. \r\n";
                                        break;
                                    }
                                case 5:
                                    {
                                        txtReceive.Text += "Manual control. \r\n";
                                        break;
                                    }
                                case 6:
                                    {
                                        txtReceive.Text += "Pause State. \r\n";
                                        break;
                                    }
                                case 7:
                                    {
                                        txtReceive.Text += "Laser channel light too weak. \r\n";
                                        break;
                                    }
                                case 8:
                                    {
                                        txtReceive.Text += "Laser channel light too strong. \r\n";
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "Error! \r\n";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 115:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 115)
                        {
                            switch (uart_result[1])
                            {
                                case 17:
                                    {
                                        txtReceive.Text += "Pause Control Set! \r\n";
                                        Resumebtn.Enabled = true;
                                        break;
                                    }
                                case 119:
                                    {
                                        txtReceive.Text += "This function cannot be used now, please try later. \r\n";
                                        break;
                                    }
                                case 136:
                                    {
                                        txtReceive.Text += "This command is unavailable in Manual Mode. \r\n";
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "Error! \r\n";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 116:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 116)
                        {
                            switch (uart_result[1])
                            {
                                case 17:
                                    {
                                        txtReceive.Text += "Resume Control Set! \r\n";
                                        Resumebtn.Enabled = false;
                                        break;
                                    }
                                case 119:
                                    {
                                        txtReceive.Text += "This function cannot be used now, please try later. \r\n";
                                        break;
                                    }
                                case 136:
                                    {
                                        txtReceive.Text += "This command is unavailable in Manual Mode. \r\n";
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "Error! \r\n";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 121:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 121)
                        {
                            float_U32 Power = new float_U32();
                            Power.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[1]));
                            txtReceive.Text += "Laser Channel Power = " + (Convert.ToString(Power.floatData)) + "uW \r\n";
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 125:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 125)
                        {
                            if (uart_result[1] == 17)
                            {
                                txtReceive.Text += "Start locking current point. \r\n";
                                LockCurrentPointbtn.Enabled = false;
                                AutoModebtn.Enabled = false;
                                ManualModebtn.Enabled = true;
                                FormParameter.mode_flag = 1;
                            }
                            else
                            {
                                txtReceive.Text += "Error! Please try again. \r\n";
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 126:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 126)
                        {
                            if ((uart_result[1] == 1) && (uart_result[2] == 17))
                            {
                                txtReceive.Text += "Current Polar: Positive \r\n";
                                //Current polar is positive;
                            }
                            else if ((uart_result[1] == 2) && (uart_result[2] == 17))
                            {
                                txtReceive.Text += "Current Polar: Negative \r\n";
                                //Current polar is negative;
                            }
                            else
                            {
                                txtReceive.Text += "Error! Please try again. \r\n";
                            }
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 255:
                    {
                        break;
                    }
                case 0:
                    {
                        break;
                    }
                default:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色

                        txtReceive.Text += "Unknown Error! \r\n";
                        break;
                    }
            }
        }

        private void Command_tx(string[] CMD_strArray)
        {
            int byteBufferLength = CMD_strArray.Length;
            for (int i = 0; i < CMD_strArray.Length; i++)
            {
                if (CMD_strArray[i] == "")
                {
                    byteBufferLength--;
                }
            }
            byte[] byteBuffer = new byte[byteBufferLength];
            int ii = 0;
            for (int i = 0; i < CMD_strArray.Length; i++)        //对获取的字符做相加运算
            {
                Byte[] bytesOfStr = Encoding.Default.GetBytes(CMD_strArray[i]);

                int decNum = 0;
                if (CMD_strArray[i] == "")
                {
                    //ii--;     //加上此句是错误的，下面的continue以延缓了一个ii，不与i同步
                    continue;
                }
                else
                {
                    decNum = Convert.ToInt32(CMD_strArray[i], 16); //atrArray[i] == 12时，temp == 18 ,十六进制转十进制
                }

                byteBuffer[ii] = Convert.ToByte(decNum);

                ii++;
            }
            sp1.Write(byteBuffer, 0, byteBuffer.Length);
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Common.formstatus = 0;
            Form2.MainWindow.Show();
            sp1.Close();
        }

        private void tmSend_Tick(object sender, EventArgs e)
        {
            //转换时间间隔
            //string strSecond = txtSecond.Text;
            try
            {
                //int isecond = int.Parse(strSecond) * 1000;//Interval以微秒为单位
                //tmSend.Interval = isecond;
                if (tmSend.Enabled == true)
                {
                    //btnSend.PerformCliCck();
                }
            }
            catch (System.Exception ex)
            {
                tmSend.Enabled = false;
                MessageBox.Show("错误的定时输入！", "Error");
            }
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.Select(txtReceive.Text.Length, 0);
            txtReceive.ScrollToCaret();
        }

        private void OriginalDataTextBox_TextChanged(object sender, EventArgs e)
        {
            OriginalDataTextBox.Select(txtReceive.Text.Length, 0);
            OriginalDataTextBox.ScrollToCaret();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReceive.Text = "";       //清空文本
            OriginalDataTextBox.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetDACbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 028");
                return;
            }

            FormParameter.UART_CMD = 108;

            string[] strArray = { "6C", "0", "0", "0", "0", "0", "0" };

            double SetDACvalue;
            double tempVoltage;
            uint dataOne;
            uint dataTwo;
            try
            {
                if (String.IsNullOrEmpty(SetDACtxBox.Text) == false)
                {
                    SetDACvalue = Convert.ToDouble(SetDACtxBox.Text);
                    if (SetDACvalue >= 0)
                    {
                        strArray[4] = "0";
                    }
                    else
                    {
                        strArray[4] = "1";
                    }
                    tempVoltage = Math.Floor(System.Math.Abs(SetDACvalue) * 1000);
                    dataOne = (uint)Math.Floor(tempVoltage / 256);
                    dataTwo = ((uint)tempVoltage) % 256;
                    strArray[2] = dataOne.ToString("x2");  //转成两位十六进制数
                    strArray[3] = dataTwo.ToString("x2");
                    if (ManualModebtn.Enabled == false)
                    {
                        Command_tx(strArray);
                    }
                    else
                    {
                        MessageBox.Show("This function can only be used in Manual Mode!", "Error 030");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter bias voltage value!", "Error 031");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Illegal input!", "Error 035");
            }
        }

        private void SetPolarbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 025");
                return;
            }


            FormParameter.UART_CMD = 109;

            string[] strArray = { "6D", "1", "0", "0", "0", "0", "0" };
            if ((PolarBox.Text) == "Positive")
            {
                strArray[1] = Convert.ToString(1);
            }
            else
            {
                strArray[1] = Convert.ToString(2);
            }

            Command_tx(strArray);
        }

        private void ReadVpibtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 013");
                return;
            }

            FormParameter.UART_CMD = 105;

            string[] strArray = { "69", "0", "0", "0", "0", "0", "0" };
            Command_tx(strArray);

        }

        private void ReadLaserPowerbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 015");
                return;
            }

            FormParameter.UART_CMD = 121;

            string[] strArray = { "79", "0", "0", "0", "0", "0", "0" };
            Command_tx(strArray);
        }

        private void ReadModulatorPowerbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 015");
                return;
            }

            FormParameter.UART_CMD = 103;

            string[] strArray = { "67", "0", "0", "0", "0", "0", "0" };
            Command_tx(strArray);
        }

        private void ReadDCbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 014");
                return;
            }

            FormParameter.UART_CMD = 102;

            string[] strArray = { "66", "0", "0", "0", "0", "0", "0" };
            Command_tx(strArray);
        }

        private void ReadBiasbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 016");
                return;
            }

            FormParameter.UART_CMD = 104;

            string[] strArray = { "68", "0", "0", "0", "0", "0", "0" };

            Command_tx(strArray);
        }

        private void ReadPolarbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 012");
                return;
            }

            string[] strArray = { "7E", "0", "0", "0", "0", "0", "0" };

            Command_tx(strArray);

            FormParameter.UART_CMD = 126;
        }

        private void ReadStatusbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 010");
                return;
            }

            string[] strArray = { "70", "0", "0", "0", "0", "0", "0" };

            Command_tx(strArray);

            FormParameter.UART_CMD = 112;
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 011");
                return;
            }

            string[] strArray = { "6E", "0", "0", "0", "0", "0", "0" };

            Command_tx(strArray);

            FormParameter.UART_CMD = 110;

            // 输出当前时间
            DateTime dt = DateTime.Now;
            txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
            txtReceive.SelectAll();
            txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色

            txtReceive.Text += "Reset Command has been sended. \r\n";
            ManualModebtn.Enabled = true;
            Resumebtn.Enabled = false;
            AutoModebtn.Enabled = false;
            LockCurrentPointbtn.Enabled = false;
        }

        private void LockCurrentPointbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 027");
                return;
            }

            string[] strArray = { "7D", "0", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 125;
            FormParameter.mode_flag = 1;

            Command_tx(strArray);
        }

        private void JumpVpiPbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 027");
                return;
            }

            string[] strArray = { "6F", "1", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 111;

            Command_tx(strArray);
        }

        private void JumpVpiNbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 027");
                return;
            }

            string[] strArray = { "6F", "2", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 111;

            Command_tx(strArray);
        }

        private void ManualModebtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 026");
                return;
            }

            string[] strArray = { "6B", "2", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 107;
            FormParameter.mode_flag = 2;

            Command_tx(strArray);
        }

        private void AutoModebtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 027");
                return;
            }

            string[] strArray = { "6B", "1", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 107;
            FormParameter.mode_flag = 1;

            Command_tx(strArray);
        }

        private void Resumebtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 019");
                return;
            }

            string[] strArray = { "74", "0", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 116;

            Command_tx(strArray);
        }

        private void Pausebtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 018");
                return;
            }

            string[] strArray = { "73", "0", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 115;

            Command_tx(strArray);
        }
    }
}
