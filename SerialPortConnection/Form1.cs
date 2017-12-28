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

        public static bool Delay(int delayTime)
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

        //加载
        private void Form1_Load(object sender, EventArgs e)
        {
            //// 预置波特率
            //cbBaudRate.SelectedIndex = 8;
            //// 预置数据位 
            //cbDataBits.SelectedIndex = 3;
            //// 预置停止位
            //cbStop.SelectedIndex = 0;
            //// 预置校验位
            //cbParity.SelectedIndex = 0;

            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }

            //添加串口项目
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口
                //System.Diagnostics.Debug.WriteLine(s);
                cbSerial.Items.Add(s);
            }

            //串口设置默认选择项
            //cbSerial.SelectedIndex = 0;         //note：获得COM9口，但别忘修改
            //cbBaudRate.SelectedIndex = 5;
            // cbDataBits.SelectedIndex = 3;
            // cbStop.SelectedIndex = 0;
            //  cbParity.SelectedIndex = 0;
            //sp2.BaudRate = 9600;

            Control.CheckForIllegalCrossThreadCalls = false;    //这个类中我们不检查跨线程的调用是否合法(因为.net 2.0以后加强了安全机制,，不允许在winform中直接跨线程访问控件的属性)
            sp1.DataReceived += new SerialDataReceivedEventHandler(sp1_DataReceived);
            //sp1.ReceivedBytesThreshold = 1;

            //radio1.Checked = true;  //单选按钮默认是选中的
            //rbRcvStr.Checked = true;

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
                MessageBox.Show("连接异常，请重启程序", "错误0x41");
            }

        }

        //private void UART_Init(object sender, EventArgs x)
        //{
        //    sp1.PortName = "COM8";// Common.serialName;
        //    sp1.BaudRate = 57600;
        //    sp1.DataBits = 8;
        //    sp1.StopBits = StopBits.One;
        //    sp1.Parity = Parity.None;
        //    try
        //    {
        //        sp1.Open();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("连接异常，请重启程序", "错误0x41");
        //    }
        //}

        public static class FormParameter
        {
            public static string strRcv;
            public static uint byteID;
            public static int UART_CMD;
        }

        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp1.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了
            {
                //输出当前时间
                //DateTime dt = DateTime.Now;
                //txtReceive.Text += dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                //txtReceive.SelectAll();
                //txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色

                byte[] byteRead = new byte[sp1.BytesToRead];    //BytesToRead:sp1接收的字符个数
                //if (rdSendStr.Checked)                          //'发送字符串'单选按钮
                //{
                //    txtReceive.Text += sp1.ReadLine() + "\r\n"; //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                //    sp1.DiscardInBuffer();                      //清空SerialPort控件的Buffer 
                //}
                //else                                            //'发送16进制按钮'
                //{
                try
                {
                    Byte[] receivedData = new Byte[sp1.BytesToRead];        //创建接收字节数组
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
                    FormParameter.byteID = receivedData[0];
                    UART_Handler(receivedData);  //receivedData是收到的数据，数据格式为十进制
                    //txtReceive.Text += FormParameter.strRcv + "\r\n";
                    //if (receivedData[0] == 105)
                    //{
                    //    vpiYI.Text = receivedData[1].ToString();
                    //}
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "出错提示");
                    txtSend.Text = "";
                }
                //}
            }
            else
            {
                MessageBox.Show("请打开某个串口", "错误提示");
            }
        }

        private void UART_Handler(Byte[] uart_result)
        {
            txtReceive.Text += FormParameter.strRcv + "\r\n";
            switch(FormParameter.byteID)
            {
                case 104:
                    {
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
                                txtReceive.Text += "Polar I_1: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar I_1: Negative \r\n";
                            }
                            if (polarQ_1 == 1)
                            {
                                txtReceive.Text += "Polar Q_1: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar Q_1: Negative \r\n";
                            }
                            if (polarP_1 == 1)
                            {
                                txtReceive.Text += "Polar P_1: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar P_1: Negative \r\n";
                            }
                            if (polarI_2 == 1)
                            {
                                txtReceive.Text += "Polar I_2: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar I_2: Negative \r\n";
                            }
                            if (polarQ_2 == 1)
                            {
                                txtReceive.Text += "Polar Q_2: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar Q_2: Negative \r\n";
                            }
                            if (polarP_2 == 1)
                            {
                                txtReceive.Text += "Polar P_2: Positive \r\n";
                            }
                            else
                            {
                                txtReceive.Text += "Polar P_2: Negative \r\n";
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
                        if(FormParameter.UART_CMD == 105)
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
                default:
                    {
                        txtReceive.Text += "Unknown Error. Please try again. \r\n";
                        break;
                    }     
            }
            //if (FormParameter.byteID == 105)
            //{
            //    vpiYI.Text = uart_result[1].ToString();
            //}
        }

        //发送按钮
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            String strSend = txtSend.Text;
            if (radio1.Checked == true)	//“HEX发送” 按钮 
            {
                //处理数字转换
                string sendBuf = strSend;
                string sendnoNull = sendBuf.Trim();
                string sendNOComma = sendnoNull.Replace(',', ' ');    //去掉英文逗号
                string sendNOComma1 = sendNOComma.Replace('，', ' '); //去掉中文逗号
                string strSendNoComma2 = sendNOComma1.Replace("0x", "");   //去掉0x
                strSendNoComma2.Replace("0X", "");   //去掉0X
                string[] strArray = strSendNoComma2.Split(' ');

                int byteBufferLength = strArray.Length;
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "")
                    {
                        byteBufferLength--;
                    }
                }
                // int temp = 0;
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

                    try    //防止输错，使其只能输入一个字节的字符
                    {
                        byteBuffer[ii] = Convert.ToByte(decNum);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                        tmSend.Enabled = false;
                        return;
                    }

                    ii++;
                }
                sp1.Write(byteBuffer, 0, byteBuffer.Length);
            }
            else		//以字符串形式发送时 
            {
                sp1.WriteLine(txtSend.Text);    //写入数据
            }
        }

        //开关按钮
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            //serialPort1.IsOpen
            if (!sp1.IsOpen)
            {
                try
                {
                    ////设置串口号
                    //string serialName = cbSerial.SelectedItem.ToString();
                    //sp2.PortName = serialName;

                    ////设置各“串口设置”
                    //string strBaudRate = cbBaudRate.Text;
                    //string strDateBits = cbDataBits.Text;
                    //string strStopBits = cbStop.Text;
                    //Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    //Int32 iDateBits = Convert.ToInt32(strDateBits);

                    //sp2.BaudRate = iBaudRate;       //波特率
                    //sp2.DataBits = iDateBits;       //数据位
                    //switch (cbStop.Text)            //停止位
                    //{
                    //    case "1":
                    //        sp2.StopBits = StopBits.One;
                    //        break;
                    //    case "1.5":
                    //        sp2.StopBits = StopBits.OnePointFive;
                    //        break;
                    //    case "2":
                    //        sp2.StopBits = StopBits.Two;
                    //        break;
                    //    default:
                    //        MessageBox.Show("Error：参数不正确!", "Error");
                    //        break;
                    //}
                    //switch (cbParity.Text)             //校验位
                    //{
                    //    case "无":
                    //        sp2.Parity = Parity.None;
                    //        break;
                    //    case "奇校验":
                    //        sp2.Parity = Parity.Odd;
                    //        break;
                    //    case "偶校验":
                    //        sp2.Parity = Parity.Even;
                    //        break;
                    //    default:
                    //        MessageBox.Show("Error：参数不正确!", "Error");
                    //        break;
                    //}

                    if (sp1.IsOpen == true)//如果打开状态，则先关闭一下
                    {
                        sp1.Close();
                    }
                    //sp2.PortName = Common.serialName;
                    //sp2.BaudRate = 57600;
                    //sp2.DataBits = 8;
                    //sp2.StopBits = StopBits.One;
                    //sp2.Parity = Parity.None;
                    //sp2.Open();
                    //状态栏设置
                    tsSpNum.Text = "串口号：" + sp1.PortName + "|";
                    tsBaudRate.Text = "波特率：" + sp1.BaudRate + "|";
                    tsDataBits.Text = "数据位：" + sp1.DataBits + "|";
                    tsStopBits.Text = "停止位：" + sp1.StopBits + "|";
                    tsParity.Text = "校验位：" + sp1.Parity + "|";

                    //设置必要控件不可用
                    cbSerial.Enabled = false;
                    cbBaudRate.Enabled = false;
                    cbDataBits.Enabled = false;
                    cbStop.Enabled = false;
                    cbParity.Enabled = false;

                    //sp2.Open();     //打开串口
                    //btnSwitch.Text = "关闭串口";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    tmSend.Enabled = false;
                    return;
                }
            }
            else
            {
                //状态栏设置
                tsSpNum.Text = "串口号：未指定|";
                tsBaudRate.Text = "波特率：未指定|";
                tsDataBits.Text = "数据位：未指定|";
                tsStopBits.Text = "停止位：未指定|";
                tsParity.Text = "校验位：未指定|";
                //恢复控件功能
                //设置必要控件不可用
                cbSerial.Enabled = true;
                cbBaudRate.Enabled = true;
                cbDataBits.Enabled = true;
                cbStop.Enabled = true;
                cbParity.Enabled = true;

                sp1.Close();                    //关闭串口
                btnSwitch.Text = "打开串口";
                tmSend.Enabled = false;         //关闭计时器
            }
            sp1.PortName = Common.serialName;
            sp1.BaudRate = 57600;
            sp1.DataBits = 8;
            sp1.StopBits = StopBits.One;
            sp1.Parity = Parity.None;
            sp1.Open();
        }

        //清空按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReceive.Text = "";       //清空文本
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
            sp1.Close();
        }

        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radio1.Checked== true)
            {
                //正则匹配
                string patten = "[0-9a-fA-F]|\b|0x|0X| "; //“\b”：退格键
                Regex r = new Regex(patten);
                Match m = r.Match(e.KeyChar.ToString());

                if (m.Success )//&&(txtSend.Text.LastIndexOf(" ") != txtSend.Text.Length-1))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }//end of radio1
            else
            {
                e.Handled = false;
            }
        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        //定时器
        private void tmSend_Tick(object sender, EventArgs e)
        {
            //转换时间间隔
            string strSecond = txtSecond.Text;
            try
            {
                int isecond = int.Parse(strSecond) * 1000;//Interval以微秒为单位
                tmSend.Interval = isecond;
                if (tmSend.Enabled == true)
                {
                    btnSend.PerformClick();
                }
            }
            catch (System.Exception ex)
            {
                tmSend.Enabled = false;
                MessageBox.Show("错误的定时输入！", "Error");
            }
            
        }

        private void txtSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
            string patten = "[0-9]|\b"; //“\b”：退格键
            Regex r = new Regex(patten);
            Match m = r.Match(e.KeyChar.ToString());

            if (m.Success)
            {
                e.Handled = false;   //没操作“过”，系统会处理事件    
            }
            else
            {
                e.Handled = true;
            }
        }

        private void readVpi_Click(object sender, EventArgs e)
        {
            tmSend.Enabled = false;
            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            string[] strArray = { "69", "0", "0", "0", "0", "0", "0" };

            int byteBufferLength = strArray.Length;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] == "")
                {
                    byteBufferLength--;
                }
            }
            // int temp = 0;
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
                    decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 ,十六进制转十进制
                }

                try    //防止输错，使其只能输入一个字节的字符
                {
                    byteBuffer[ii] = Convert.ToByte(decNum);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                    tmSend.Enabled = false;
                    return;
                }

                ii++;
            }
            sp1.Write(byteBuffer, 0, byteBuffer.Length);
        }

        private void ReadStatusbtn_Click(object sender, EventArgs e)
        {
            if(!sp1.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            string[] strArray = { "69", "0", "0", "0", "0", "0", "0" };

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
                    decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 ,十六进制转十进制
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
            FormParameter.UART_CMD = 105;
        }

        private void Resetbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            string[] strArray = { "6D", "0", "0", "0", "0", "0", "0" };

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
                    decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 ,十六进制转十进制
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
            FormParameter.UART_CMD = 109;
            txtReceive.Text += "Reset Command has been sended. \r\n";
        }

        private void ReadPolarbtn_Click(object sender, EventArgs e)
        {
            if (!sp1.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            string[] strArray = { "68", "0", "0", "0", "0", "0", "0" };

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
                    decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 ,十六进制转十进制
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
            FormParameter.UART_CMD = 104;
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.Select(txtReceive.Text.Length, 0);
            txtReceive.ScrollToCaret();
        }
    }
}
