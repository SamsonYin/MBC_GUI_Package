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

namespace SerialPortConnection
{
    public partial class Form2 : Form
    {
        private Button btnSwitch;
        private ComboBox cbSerial;
        private Label label1;

        SerialPort sp1 = new SerialPort();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 预置波特率
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
            //sp1.BaudRate = 57600;

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
                int MBCVersion;
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
                        string strRcv = null;
                        //int decNum = 0;//存储十进制
                        for (int i = 0; i < receivedData.Length; i++) //窗体显示
                        {

                            strRcv += receivedData[i].ToString("X2");  //16进制显示
                        }
                    //txtReceive.Text += strRcv + "\r\n";
                    MBCVersion = receivedData[1];
                        if (receivedData[0] == 170)
                        {
                            MessageBox.Show("打开DPIQ控制窗口", "xxx");
                         }
                        else
                        {
                            MessageBox.Show("控制器连接失败，请重试！", "错误代码0x10");
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "出错提示");
                        //txtSend.Text = "";
                    }
                //}
            }
            else
            {
                MessageBox.Show("请打开某个串口", "错误提示");
            }
        }

        //串口开关按钮
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            //serialPort1.IsOpen
            if (!sp1.IsOpen)
            {
                try
                {
                    //设置串口号
                    string serialName = cbSerial.SelectedItem.ToString();
                    sp1.PortName = serialName;

                    //设置各“串口设置”
                    //string strBaudRate = cbBaudRate.Text;
                    //string strDateBits = cbDataBits.Text;
                    //string strStopBits = cbStop.Text;
                    //Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    //Int32 iDateBits = Convert.ToInt32(strDateBits);

                    //sp1.BaudRate = iBaudRate;       //波特率
                    //sp1.DataBits = iDateBits;       //数据位
                    //switch (cbStop.Text)            //停止位
                    //{
                    //    case "1":
                    //        sp1.StopBits = StopBits.One;
                    //        break;
                    //    case "1.5":
                    //        sp1.StopBits = StopBits.OnePointFive;
                    //        break;
                    //    case "2":
                    //        sp1.StopBits = StopBits.Two;
                    //        break;
                    //    default:
                    //        MessageBox.Show("Error：参数不正确!", "Error");
                    //        break;
                    //}
                    //switch (cbParity.Text)             //校验位
                    //{
                    //    case "无":
                    //        sp1.Parity = Parity.None;
                    //        break;
                    //    case "奇校验":
                    //        sp1.Parity = Parity.Odd;
                    //        break;
                    //    case "偶校验":
                    //        sp1.Parity = Parity.Even;
                    //        break;
                    //    default:
                    //        MessageBox.Show("Error：参数不正确!", "Error");
                    //        break;
                    //}

                    sp1.BaudRate = 57600;
                    sp1.DataBits = 8;
                    sp1.StopBits = StopBits.One;
                    sp1.Parity = Parity.None;

                    if (sp1.IsOpen == true)//如果打开状态，则先关闭一下
                    {
                        sp1.Close();
                    }
                    //状态栏设置
                    //tsSpNum.Text = "串口号：" + sp1.PortName + "|";
                    //tsBaudRate.Text = "波特率：" + sp1.BaudRate + "|";
                    //tsDataBits.Text = "数据位：" + sp1.DataBits + "|";
                    //tsStopBits.Text = "停止位：" + sp1.StopBits + "|";
                    //tsParity.Text = "校验位：" + sp1.Parity + "|";

                    //设置必要控件不可用
                    //cbSerial.Enabled = false;
                    //cbBaudRate.Enabled = false;
                    //cbDataBits.Enabled = false;
                    //cbStop.Enabled = false;
                    //cbParity.Enabled = false;

                    sp1.Open();     //打开串口
                    btnSwitch.Text = "关闭串口";

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

                        try    //防止输错，使其只能输入一个字节的字符
                        {
                            byteBuffer[ii] = Convert.ToByte(decNum);
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                            //tmSend.Enabled = false;
                            return;
                        }

                        ii++;
                    }
                    sp1.Write(byteBuffer, 0, byteBuffer.Length);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    //tmSend.Enabled = false;
                    return;
                }
            }
            else
            {
                //状态栏设置
                //tsSpNum.Text = "串口号：未指定|";
                //tsBaudRate.Text = "波特率：未指定|";
                //tsDataBits.Text = "数据位：未指定|";
                //tsStopBits.Text = "停止位：未指定|";
                //tsParity.Text = "校验位：未指定|";
                //恢复控件功能
                //设置必要控件不可用
                //cbSerial.Enabled = true;
                //cbBaudRate.Enabled = true;
                //cbDataBits.Enabled = true;
                //cbStop.Enabled = true;
                //cbParity.Enabled = true;

                sp1.Close();                    //关闭串口
                btnSwitch.Text = "打开串口";
                //tmSend.Enabled = false;         //关闭计时器
            }
        }

        //关闭时事件
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp1.Close();
        }

        private void InitializeComponent()
        {
            this.btnSwitch = new System.Windows.Forms.Button();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(370, 129);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(113, 31);
            this.btnSwitch.TabIndex = 10;
            this.btnSwitch.Text = "打开串口";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // cbSerial
            // 
            this.cbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Location = new System.Drawing.Point(262, 132);
            this.cbSerial.Margin = new System.Windows.Forms.Padding(5);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(91, 26);
            this.cbSerial.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(162, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "串口：";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(846, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSerial);
            this.Controls.Add(this.btnSwitch);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上位机测试软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
