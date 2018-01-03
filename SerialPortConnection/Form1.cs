using System;
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
    public partial class Form1 : Form
    {
        SerialPort sp1 = new SerialPort();
        //sp1.ReceivedBytesThreshold = 1;//只要有1个字符送达端口时便触发DataReceived事件 

        public Form1()
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

        //加载
        private void Form1_Load(object sender, EventArgs e)
        {
            //预设Polar值
            YIPolarBox.SelectedIndex = 0;
            YQPolarBox.SelectedIndex = 0;
            YPPolarBox.SelectedIndex = 0;
            XIPolarBox.SelectedIndex = 0;
            XQPolarBox.SelectedIndex = 0;
            XPPolarBox.SelectedIndex = 0;

            //预设控件状态
            Resumebtn.Enabled = false;
            AutoModebtn.Enabled = false;
            SetDACBox.SelectedIndex = 0;
            BiasChBox.SelectedIndex = 0;

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
            public static string YI_dither_amp;
            public static string YQ_dither_amp;
            public static string XI_dither_amp;
            public static string XQ_dither_amp;
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
            switch(FormParameter.byteID)
            {
                case 101:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 101)
                        {
                            float_U32 Power = new float_U32();
                            Power.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                            Power.intData = Power.intData + (Convert.ToUInt32(uart_result[1]));
                            txtReceive.Text += "Feedback Power = " + (Convert.ToString(Power.floatData)) + "uW \r\n";
                        }
                        else
                        {
                            txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        }
                        break;
                    }
                case 102:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 102)
                        {
                            switch (BiasChBox.Text)
                            {
                                case "Y-I":
                                    {
                                        float_U32 bias = new float_U32();
                                        bias.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "YI_Bias:" + (Convert.ToString(bias.floatData)) + " V\r\n";
                                        break;
                                    }
                                case "Y-Q":
                                    {
                                        float_U32 bias = new float_U32();
                                        bias.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "YQ_Bias:" + (Convert.ToString(bias.floatData)) + " V\r\n";
                                        break;
                                    }
                                case "Y-P":
                                    {
                                        float_U32 bias = new float_U32();
                                        bias.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "YP_Bias:" + (Convert.ToString(bias.floatData)) + " V\r\n";
                                        break;
                                    }
                                case "X-I":
                                    {
                                        float_U32 bias = new float_U32();
                                        bias.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "XI_Bias:" + (Convert.ToString(bias.floatData)) + " V\r\n";
                                        break;
                                    }
                                case "X-Q":
                                    {
                                        float_U32 bias = new float_U32();
                                        bias.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "XQ_Bias:" + (Convert.ToString(bias.floatData)) + " V\r\n";
                                        break;
                                    }
                                case "X-P":
                                    {
                                        float_U32 bias = new float_U32();
                                        bias.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        bias.intData = bias.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "XP_Bias:" + (Convert.ToString(bias.floatData)) + " V\r\n";
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "ReadBias Error. Please try again. \r\n";
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
                case 103:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 103)
                        {
                            switch(FormParameter.arm)
                            {
                                case 1:
                                    {
                                        float_U32 vpi = new float_U32();
                                        vpi.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "YI_Vpi:" + (Convert.ToString(vpi.floatData)) + " V\r\n";
                                        YIVpitxBox.Text = Convert.ToString(vpi.floatData) + "V";
                                        break;
                                    }
                                case 2:
                                    {
                                        float_U32 vpi = new float_U32();
                                        vpi.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "YQ_Vpi:" + (Convert.ToString(vpi.floatData)) + " V\r\n";
                                        YQVpitxBox.Text = Convert.ToString(vpi.floatData) + "V";
                                        break;
                                    }
                                case 3:
                                    {
                                        float_U32 vpi = new float_U32();
                                        vpi.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "YP_Vpi:" + (Convert.ToString(vpi.floatData)) + " V\r\n";
                                        YPVpitxBox.Text = Convert.ToString(vpi.floatData) + "V";
                                        break;
                                    }
                                case 4:
                                    {
                                        float_U32 vpi = new float_U32();
                                        vpi.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "XI_Vpi:" + (Convert.ToString(vpi.floatData)) + " V\r\n";
                                        XIVpitxBox.Text = Convert.ToString(vpi.floatData) + "V";
                                        break;
                                    }
                                case 5:
                                    {
                                        float_U32 vpi = new float_U32();
                                        vpi.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "XQ_Vpi:" + (Convert.ToString(vpi.floatData)) + " V\r\n";
                                        XQVpitxBox.Text = Convert.ToString(vpi.floatData) + "V";
                                        break;
                                    }
                                case 6:
                                    {
                                        float_U32 vpi = new float_U32();
                                        vpi.intData = (Convert.ToUInt32(uart_result[4]) << 24);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[3]) << 16);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[2]) << 8);
                                        vpi.intData = vpi.intData + (Convert.ToUInt32(uart_result[1]));
                                        txtReceive.Text += "XP_Vpi:" + (Convert.ToString(vpi.floatData)) + " V\r\n";
                                        XPVpitxBox.Text = Convert.ToString(vpi.floatData) + "V";
                                        break;
                                    }
                                default:
                                    {
                                        txtReceive.Text += "ReadVpi Error. Please try again. \r\n";
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
                case 104:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 104)
                        {
                            int polarI_1;
                            int polarQ_1;
                            int polarP_1;
                            int polarI_2;
                            int polarQ_2;
                            int polarP_2;
                            polarI_1 = uart_result[1] + 1;
                            polarQ_1 = uart_result[2] + 1;
                            polarP_1 = uart_result[3] + 1;
                            polarI_2 = uart_result[4] + 1;
                            polarQ_2 = uart_result[5] + 1;
                            polarP_2 = uart_result[6] + 1;
                            if (polarI_1 == 1)
                            {
                                txtReceive.Text += "Polar YI: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar YI: Negative \r\n";
                            }
                            if (polarQ_1 == 1)
                            {
                                txtReceive.Text += "Polar YQ: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar YQ: Negative \r\n";
                            }
                            if (polarP_1 == 1)
                            {
                                txtReceive.Text += "Polar YP: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar YP: Negative \r\n";
                            }
                            if (polarI_2 == 1)
                            {
                                txtReceive.Text += "Polar XI: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar XI: Negative \r\n";
                            }
                            if (polarQ_2 == 1)
                            {
                                txtReceive.Text += "Polar XQ: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar XQ: Negative \r\n";
                            }
                            if (polarP_2 == 1)
                            {
                                txtReceive.Text += "Polar XP: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar XP: Negative \r\n";
                            }
                            if(uart_result[7] == 119)
                            {
                                txtReceive.Text += "This function cannot be used now, please try later \r\n";
                            }
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
                                        txtReceive.Text += "Light too weak. \r\n";
                                        break;
                                    }
                                case 4:
                                    {
                                        txtReceive.Text += "Light too strong. \r\n";
                                        break;
                                    }
                                case 5:
                                    {
                                        txtReceive.Text += "Manual control. \r\n";
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
                case 106:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 106)
                        {
                            switch (uart_result[1])
                            {
                                case 17:
                                    {
                                        if(FormParameter.mode_flag == 2)
                                        {
                                            txtReceive.Text += "Manual Mode Set! \r\n";
                                            AutoModebtn.Enabled = true;
                                            ManualModebtn.Enabled = false;
                                        }
                                        else if(FormParameter.mode_flag == 1)
                                        {
                                            txtReceive.Text += "Auto Mode Set! \r\n";
                                            AutoModebtn.Enabled = false;
                                            ManualModebtn.Enabled = true;
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
                                        txtReceive.Text += "Output voltage has been Updated! \r\n";
                                        Resumebtn.Enabled = true;
                                        break;
                                    }
                                case 136:
                                    {
                                        txtReceive.Text += "Output voltage failed. \r\n";
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
                                        txtReceive.Text += "Set Polar Command Sended! \r\n";
                                        break;
                                    }
                                case 119:
                                    {
                                        txtReceive.Text += "This function cannot be used now, please try later. \r\n";
                                        break;
                                    }
                                case 136:
                                    {
                                        txtReceive.Text += "Setup failed, please try later. \r\n";
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
                                        txtReceive.Text += "Set Dither Amp Command has been sended! \r\n";
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
                case 120:
                    {
                        // 输出当前时间
                        DateTime dt = DateTime.Now;
                        txtReceive.Text += DateTime.Now.Date.ToString("yyyy-MM-dd", new System.Globalization.CultureInfo("en-us")) + " " + DateTime.Now.ToString("t") + "\r\n";//dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                        txtReceive.SelectAll();
                        txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                        if (FormParameter.UART_CMD == 120)
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

        ////发送按钮
        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    if (cbTimeSend.Checked)
        //    {
        //        tmSend.Enabled = true;
        //    }
        //    else
        //    {
        //        tmSend.Enabled = false;
        //    }

        //    if (!sp1.IsOpen) //如果没打开
        //    {
        //        MessageBox.Show("请先打开串口！", "Error");
        //        return;
        //    }

        //    String strSend = txtSend.Text;
        //    if (radio1.Checked == true)	//“HEX发送” 按钮 
        //    {
        //        //处理数字转换
        //        string sendBuf = strSend;
        //        string sendnoNull = sendBuf.Trim();
        //        string sendNOComma = sendnoNull.Replace(',', ' ');    //去掉英文逗号
        //        string sendNOComma1 = sendNOComma.Replace('，', ' '); //去掉中文逗号
        //        string strSendNoComma2 = sendNOComma1.Replace("0x", "");   //去掉0x
        //        strSendNoComma2.Replace("0X", "");   //去掉0X
        //        string[] strArray = strSendNoComma2.Split(' ');

        //        int byteBufferLength = strArray.Length;
        //        for (int i = 0; i < strArray.Length; i++)
        //        {
        //            if (strArray[i] == "")
        //            {
        //                byteBufferLength--;
        //            }
        //        }
        //        // int temp = 0;
        //        byte[] byteBuffer = new byte[byteBufferLength];
        //        int ii = 0;
        //        for (int i = 0; i < strArray.Length; i++)        //对获取的字符做相加运算
        //        {

        //            Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);

        //            int decNum = 0;
        //            if (strArray[i] == "")
        //            {
        //                //ii--;     //加上此句是错误的，下面的continue以延缓了一个ii，不与i同步
        //                continue;
        //            }
        //            else
        //            {
        //                decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 
        //            }

        //            try    //防止输错，使其只能输入一个字节的字符
        //            {
        //                byteBuffer[ii] = Convert.ToByte(decNum);
        //            }
        //            catch (System.Exception ex)
        //            {
        //                MessageBox.Show("字节越界，请逐个字节输入！", "Error");
        //                tmSend.Enabled = false;
        //                return;
        //            }

        //            ii++;
        //        }
        //        sp1.Write(byteBuffer, 0, byteBuffer.Length);
        //    }
        //    else		//以字符串形式发送时 
        //    {
        //        sp1.WriteLine(txtSend.Text);    //写入数据
        //    }
        //}

        ////开关按钮
        //private void btnSwitch_Click(object sender, EventArgs e)
        //{
        //    //serialPort1.IsOpen
        //    if (!sp1.IsOpen)
        //    {
        //        try
        //        {
        //            ////设置串口号
        //            //string serialName = cbSerial.SelectedItem.ToString();
        //            //sp2.PortName = serialName;

        //            ////设置各“串口设置”
        //            //string strBaudRate = cbBaudRate.Text;
        //            //string strDateBits = cbDataBits.Text;
        //            //string strStopBits = cbStop.Text;
        //            //Int32 iBaudRate = Convert.ToInt32(strBaudRate);
        //            //Int32 iDateBits = Convert.ToInt32(strDateBits);

        //            //sp2.BaudRate = iBaudRate;       //波特率
        //            //sp2.DataBits = iDateBits;       //数据位
        //            //switch (cbStop.Text)            //停止位
        //            //{
        //            //    case "1":
        //            //        sp2.StopBits = StopBits.One;
        //            //        break;
        //            //    case "1.5":
        //            //        sp2.StopBits = StopBits.OnePointFive;
        //            //        break;
        //            //    case "2":
        //            //        sp2.StopBits = StopBits.Two;
        //            //        break;
        //            //    default:
        //            //        MessageBox.Show("Error：参数不正确!", "Error");
        //            //        break;
        //            //}
        //            //switch (cbParity.Text)             //校验位
        //            //{
        //            //    case "无":
        //            //        sp2.Parity = Parity.None;
        //            //        break;
        //            //    case "奇校验":
        //            //        sp2.Parity = Parity.Odd;
        //            //        break;
        //            //    case "偶校验":
        //            //        sp2.Parity = Parity.Even;
        //            //        break;
        //            //    default:
        //            //        MessageBox.Show("Error：参数不正确!", "Error");
        //            //        break;
        //            //}

        //            if (sp1.IsOpen == true)//如果打开状态，则先关闭一下
        //            {
        //                sp1.Close();
        //            }
        //            //sp2.PortName = Common.serialName;
        //            //sp2.BaudRate = 57600;
        //            //sp2.DataBits = 8;
        //            //sp2.StopBits = StopBits.One;
        //            //sp2.Parity = Parity.None;
        //            //sp2.Open();
        //            //状态栏设置
        //            tsSpNum.Text = "串口号：" + sp1.PortName + "|";
        //            tsBaudRate.Text = "波特率：" + sp1.BaudRate + "|";
        //            tsDataBits.Text = "数据位：" + sp1.DataBits + "|";
        //            tsStopBits.Text = "停止位：" + sp1.StopBits + "|";
        //            tsParity.Text = "校验位：" + sp1.Parity + "|";

        //            //设置必要控件不可用
        //            cbSerial.Enabled = false;
        //            cbBaudRate.Enabled = false;
        //            cbDataBits.Enabled = false;
        //            cbStop.Enabled = false;
        //            cbParity.Enabled = false;

        //            //sp2.Open();     //打开串口
        //            //btnSwitch.Text = "关闭串口";
        //        }
        //        catch (System.Exception ex)
        //        {
        //            MessageBox.Show("Error:" + ex.Message, "Error");
        //            tmSend.Enabled = false;
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        //状态栏设置
        //        tsSpNum.Text = "串口号：未指定|";
        //        tsBaudRate.Text = "波特率：未指定|";
        //        tsDataBits.Text = "数据位：未指定|";
        //        tsStopBits.Text = "停止位：未指定|";
        //        tsParity.Text = "校验位：未指定|";
        //        //恢复控件功能
        //        //设置必要控件不可用
        //        cbSerial.Enabled = true;
        //        cbBaudRate.Enabled = true;
        //        cbDataBits.Enabled = true;
        //        cbStop.Enabled = true;
        //        cbParity.Enabled = true;

        //        sp1.Close();                    //关闭串口
        //        btnSwitch.Text = "打开串口";
        //        tmSend.Enabled = false;         //关闭计时器
        //    }
        //    sp1.PortName = Common.serialName;
        //    sp1.BaudRate = 57600;
        //    sp1.DataBits = 8;
        //    sp1.StopBits = StopBits.One;
        //    sp1.Parity = Parity.None;
        //    sp1.Open();
        //}

        //清空按钮

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReceive.Text = "";       //清空文本
            OriginalDataTextBox.Text = "";
        }

        //退出按钮
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //关闭时事件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Common.formstatus = 0;
            Form2.MainWindow.Show();
            sp1.Close();
        }

        //private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (radio1.Checked== true)
        //    {
        //        //正则匹配
        //        string patten = "[0-9a-fA-F]|\b|0x|0X| "; //“\b”：退格键
        //        Regex r = new Regex(patten);
        //        Match m = r.Match(e.KeyChar.ToString());

        //        if (m.Success )//&&(txtSend.Text.LastIndexOf(" ") != txtSend.Text.Length-1))
        //        {
        //            e.Handled = false;
        //        }
        //        else
        //        {
        //            e.Handled = true;
        //        }
        //    }//end of radio1
        //    else
        //    {
        //        e.Handled = false;
        //    }
        //}

        //定时器

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
                    //btnSend.PerformClick();
                }
            }
            catch (System.Exception ex)
            {
                tmSend.Enabled = false;
                MessageBox.Show("错误的定时输入！", "Error");
            }

        }

        //private void txtSecond_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string patten = "[0-9]|\b"; //“\b”：退格键
        //    Regex r = new Regex(patten);
        //    Match m = r.Match(e.KeyChar.ToString());

        //    if (m.Success)
        //    {
        //        e.Handled = false;   //没操作“过”，系统会处理事件    
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void ReadStatusbtn_Click(object sender, EventArgs e)
        {
            if(!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 010");
                return;
            }

            string[] strArray = { "69", "0", "0", "0", "0", "0", "0" };

            Command_tx(strArray);

            FormParameter.UART_CMD = 105;
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 011");
                return;
            }

            string[] strArray = { "6D", "0", "0", "0", "0", "0", "0" };

            Command_tx(strArray);

            FormParameter.UART_CMD = 109;
            txtReceive.Text += "Reset Command has been sended. \r\n";
        }

        private void ReadPolarbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 012");
                return;
            }

            string[] strArray = { "68", "0", "0", "0", "0", "0", "0" };

            Command_tx(strArray);

            FormParameter.UART_CMD = 104;
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.Select(txtReceive.Text.Length, 0);
            txtReceive.ScrollToCaret();
        }

        private void ReadVpibtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 013");
                return;
            }

            FormParameter.UART_CMD = 103;

            string[] strArray = { "67", "1", "0", "0", "0", "0", "0" };
            FormParameter.arm = 1;
            Command_tx(strArray);
            //Delay_s(1);
            Delay_ms(100);

            strArray[1] = "2";
            FormParameter.arm = 2;
            Command_tx(strArray);
            //Delay_s(1);
            Delay_ms(100);

            strArray[1] = "3";
            FormParameter.arm = 3;
            Command_tx(strArray);
            //Delay_s(1);
            Delay_ms(100);

            strArray[1] = "4";
            FormParameter.arm = 4;
            Command_tx(strArray);
            //Delay_s(1);
            Delay_ms(100);

            strArray[1] = "5";
            FormParameter.arm = 5;
            Command_tx(strArray);
            //Delay_s(1);
            Delay_ms(100);

            strArray[1] = "6";
            FormParameter.arm = 6;
            Command_tx(strArray);
            //Delay_s(1);
            Delay_ms(100);

        }

        private void ReadDCbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 014");
                return;
            }

            FormParameter.UART_CMD = 120;

            string[] strArray = { "78", "0", "0", "0", "0", "0", "0" };
            Command_tx(strArray);
        }

        private void ReadPowerbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 015");
                return;
            }

            FormParameter.UART_CMD = 101;

            string[] strArray = { "65", "0", "0", "0", "0", "0", "0" };
            Command_tx(strArray);
        }

        private void ReadBiasbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 016");
                return;
            }

            FormParameter.UART_CMD = 102;

            string[] strArray = { "66", "0", "0", "0", "0", "0", "0" };

            switch (BiasChBox.Text)
            {
                case "Y-I":
                    {
                        strArray[1] = Convert.ToString(1);
                        break;
                    }
                case "Y-Q":
                    {
                        strArray[1] = Convert.ToString(2);
                        break;
                    }
                case "Y-P":
                    {
                        strArray[1] = Convert.ToString(3);
                        break;
                    }
                case "X-I":
                    {
                        strArray[1] = Convert.ToString(4);
                        break;
                    }
                case "X-Q":
                    {
                        strArray[1] = Convert.ToString(5);
                        break;
                    }
                case "X-P":
                    {
                        strArray[1] = Convert.ToString(6);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please choose bias channel", "Error 017");
                        return;
                    }
            }
            Command_tx(strArray);
        }

        private void BiasArm_txBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 55) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
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

        private void DitherAmpSetbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 020");
                return;
            }

            FormParameter.UART_CMD = 111;

            if (String.IsNullOrEmpty(DitherYIAmp_txBox.Text) == false)
            {
                FormParameter.YI_dither_amp = DitherYIAmp_txBox.Text;
            }
            else
            {
                MessageBox.Show("Please enter YI dither amplitude coefficient!", "Error 021");
                return;
            }
            if (String.IsNullOrEmpty(DitherYQAmp_txBox.Text) == false)
            {
                FormParameter.YQ_dither_amp = DitherYQAmp_txBox.Text;
            }
            else
            {
                MessageBox.Show("Please enter YQ dither amplitude coefficient!", "Error 022");
                return;
            }
            if (String.IsNullOrEmpty(DitherXIAmp_txBox.Text) == false)
            {
                FormParameter.XI_dither_amp = DitherXIAmp_txBox.Text;
            }
            else
            {
                MessageBox.Show("Please enter XI dither amplitude coefficient!", "Error 023");
                return;
            }
            if (String.IsNullOrEmpty(DitherXQAmp_txBox.Text) == false)
            {
                FormParameter.XQ_dither_amp = DitherXQAmp_txBox.Text;
            }
            else
            {
                MessageBox.Show("Please enter XQ dither amplitude coefficient!", "Error 024");
                return;
            }

            string[] strArray = { "6F", "1", "1", "1", "1", "0", "0" };
            strArray[1] = FormParameter.YI_dither_amp;
            strArray[2] = FormParameter.YQ_dither_amp;
            strArray[3] = FormParameter.XI_dither_amp;
            strArray[4] = FormParameter.XQ_dither_amp;
            Command_tx(strArray);
        }

        private void DitherYIAmp_txBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void DitherYQAmp_txBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void DitherXIAmp_txBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void DitherXQAmp_txBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void SetPolarbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 025");
                return;
            }


            FormParameter.UART_CMD = 108;

            string[] strArray = { "6C", "1", "1", "1", "1", "1", "1" };
            if ((YIPolarBox.Text) == "Positive")
            {
                strArray[1] = Convert.ToString(1);
            }
            else
            {
                strArray[1] = Convert.ToString(2);
            }
            if ((YQPolarBox.Text) == "Positive")
            {
                strArray[2] = Convert.ToString(1);
            }
            else
            {
                strArray[2] = Convert.ToString(2);
            }
            if ((YPPolarBox.Text) == "Positive")
            {
                strArray[3] = Convert.ToString(1);
            }
            else
            {
                strArray[3] = Convert.ToString(2);
            }
            if ((XIPolarBox.Text) == "Positive")
            {
                strArray[4] = Convert.ToString(1);
            }
            else
            {
                strArray[4] = Convert.ToString(2);
            }
            if ((XQPolarBox.Text) == "Positive")
            {
                strArray[5] = Convert.ToString(1);
            }
            else
            {
                strArray[5] = Convert.ToString(2);
            }
            if ((XPPolarBox.Text) == "Positive")
            {
                strArray[6] = Convert.ToString(1);
            }
            else
            {
                strArray[6] = Convert.ToString(2);
            }

            Command_tx(strArray);
        }

        private void ManualModebtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 026");
                return;
            }

            string[] strArray = { "6A", "2", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 106;
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

            string[] strArray = { "6A", "1", "0", "0", "0", "0", "0" };

            FormParameter.UART_CMD = 106;
            FormParameter.mode_flag = 1;

            Command_tx(strArray);
        }

        private void SetDACbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("Please open a serial port！", "Error 028");
                return;
            }

            FormParameter.UART_CMD = 107;

            string[] strArray = { "6B", "0", "0", "0", "0", "0", "0" };
            switch(SetDACBox.Text)
            {
                case "Y-I":
                    {
                        strArray[1] = Convert.ToString(1);
                        break;
                    }
                case "Y-Q":
                    {
                        strArray[1] = Convert.ToString(2);
                        break;
                    }
                case "Y-P":
                    {
                        strArray[1] = Convert.ToString(3);
                        break;
                    }
                case "X-I":
                    {
                        strArray[1] = Convert.ToString(4);
                        break;
                    }
                case "X-Q":
                    {
                        strArray[1] = Convert.ToString(5);
                        break;
                    }
                case "X-P":
                    {
                        strArray[1] = Convert.ToString(6);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please choose a bias channel", "Error 029");
                        return;
                    }
            }

            double SetDACvalue;
            double tempVoltage;
            uint dataOne;
            uint dataTwo;
            if (String.IsNullOrEmpty(SetDACtxBox.Text) == false)
            {
                SetDACvalue = Convert.ToDouble(SetDACtxBox.Text);
                if(SetDACvalue >= 0)
                {
                    strArray[4] = "0";
                }
                else
                {
                    strArray[4] = "1";
                }
                tempVoltage = Math.Floor(System.Math.Abs(SetDACvalue)*1000);
                dataOne = (uint)Math.Floor(tempVoltage/256);
                dataTwo = ((uint)tempVoltage) % 256;
                strArray[2] = dataOne.ToString("x2");   //转成两位十六进制数
                strArray[3] = dataTwo.ToString("x2");
                if(ManualModebtn.Enabled == false)
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

        private void OriginalDataTextBox_TextChanged(object sender, EventArgs e)
        {
            OriginalDataTextBox.Select(txtReceive.Text.Length, 0);
            OriginalDataTextBox.ScrollToCaret();
        }
    }
}
