using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Harmony
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, int cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x040;
        private const int MOUSEEVENTF_WHEEL = 0x0800;

        public Form1()
        {
            InitializeComponent();
        }

        public string GetLocalIPAddressBAK()
        {
            try
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    return "E1";
                }

                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                return host
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
            }
            catch(Exception ex)
            {
                return "E2";
            }
        }

        public string GetLocalIPAddress()
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    return endPoint.Address.ToString();
                }
            }catch(Exception ex)
            {
                return GetLocalIPAddressBAK();
            }
        }

        int screenWidth = -1;
        int screenHeight = -1;
        string localIP = "";
        List<Button> buttons318and2028 = new List<Button>();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            //this.TransparencyKey = Color.Turquoise;
            //this.BackColor = Color.Turquoise;
            ocBC = this.BackColor;
            screenWidth = SystemInformation.VirtualScreen.Width-1;
            screenHeight = SystemInformation.VirtualScreen.Height-1;
            localIP = GetLocalIPAddress();
            label1.Text = "Your IP: "+localIP;
            buttons318and2028.Add(button3);
            buttons318and2028.Add(button4);
            buttons318and2028.Add(button5);
            buttons318and2028.Add(button6);
            buttons318and2028.Add(button7);
            buttons318and2028.Add(button8);
            buttons318and2028.Add(button9);
            buttons318and2028.Add(button10);
            buttons318and2028.Add(button11);
            buttons318and2028.Add(button12);
            buttons318and2028.Add(button13);
            buttons318and2028.Add(button14);
            buttons318and2028.Add(button15);
            buttons318and2028.Add(button16);
            buttons318and2028.Add(button17);
            buttons318and2028.Add(button18);
            buttons318and2028.Add(button20);
            buttons318and2028.Add(button21);
            buttons318and2028.Add(button22);
            buttons318and2028.Add(button23);
            buttons318and2028.Add(button24);
            buttons318and2028.Add(button25);
            buttons318and2028.Add(button26);
            buttons318and2028.Add(button27);
            buttons318and2028.Add(button28);
            for (int i = 0; i < buttons318and2028.Count; i++)
            {
                buttons318and2028[i].Enabled = false;
                buttons318and2028[i].Visible = false;
                buttons318and2028[i].Text = "[EMPTY]";
            }
            listBox1.Enabled = false;
            listBox1.Visible = false;
            label1.Enabled = false;
            label1.Visible = false;
            textBox1.Enabled = false;
            textBox1.Visible = false;
            button19.Enabled = false;
            button19.Visible = false;
            label2.Visible = false;
            label2.Enabled = false;
            //SendKeys.SendWait("D1");
            //button1.Enabled = false;
            //button2.Enabled = false;
            //label1.Visible = true;

            //timer1.Start();
        }

        private bool firstTimeADD = true;
        private List<string> ipList = new List<string>();

        private void enableSomeButtons()
        {
            for (int i = 0; i < buttons318and2028.Count; i++)
            {
                int temp = i;
                //buttons318and2028[i].Enabled = false;
                if (buttons318and2028[temp].Text != "[EMPTY]")
                {
                    if ((temp % 5 != 0) && buttons318and2028[temp - 1].Text == "[EMPTY]")
                    {
                        this.buttons318and2028[temp-1].BeginInvoke((MethodInvoker)delegate ()
                        {
                            buttons318and2028[temp-1].Enabled = true;
                        });
                    }
                    if ((temp % 5 != 4) && buttons318and2028[temp + 1].Text == "[EMPTY]")
                    {
                        this.buttons318and2028[temp + 1].BeginInvoke((MethodInvoker)delegate ()
                        {
                            buttons318and2028[temp + 1].Enabled = true;
                        });
                    }
                    if ((temp >= 5) && buttons318and2028[temp - 5].Text == "[EMPTY]")
                    {
                        this.buttons318and2028[temp - 5].BeginInvoke((MethodInvoker)delegate ()
                        {
                            buttons318and2028[temp - 5].Enabled = true;
                        });
                    }
                    if ((temp <= 19) && buttons318and2028[temp + 5].Text == "[EMPTY]")
                    {
                        this.buttons318and2028[temp + 5].BeginInvoke((MethodInvoker)delegate ()
                        {
                            buttons318and2028[temp + 5].Enabled = true;
                        });
                    }
                }
            }
        }


        public void addNewPC(string s, string ip)
        {
            if (firstTimeADD)
            {
                for (int i = 0; i < buttons318and2028.Count; i++)
                {
                    int temp = i;
                    this.buttons318and2028[temp].BeginInvoke((MethodInvoker)delegate ()
                    {
                        buttons318and2028[temp].Enabled = true;
                        buttons318and2028[temp].Click += new EventHandler(Button_ADDPC);
                        buttons318and2028[temp].Visible = true;
                    });
                }
            }
            else
            {
                enableSomeButtons();
            }
            this.listBox1.BeginInvoke((MethodInvoker)delegate ()
            {
                listBox1.Items.Add(s);
            });
            ipList.Add(ip);
            if (firstTimeADD)
            {
                MessageBox.Show("Check the list on the right for computers that still need to be assigned.\n\nClick an [EMPTY] Location to assign the pc there.");
                firstTimeADD = false;
            }
        }

        private void stopDrawingServerStuff(bool b)
        {
            b = !b;
            for (int i = 0; i < buttons318and2028.Count; i++)
            {
                int temp = i;
                this.buttons318and2028[temp].BeginInvoke((MethodInvoker)delegate ()
                {
                    buttons318and2028[temp].Visible = b;
                });
            }
            this.listBox1.BeginInvoke((MethodInvoker)delegate ()
            {
                listBox1.Enabled = b;
                listBox1.Visible = b;
            });
            this.label1.BeginInvoke((MethodInvoker)delegate ()
            {
                label1.Enabled = b;
                label1.Visible = b;
            });
        }

        private bool isServer = false;
        private bool isActivePC = false;
        private PC currentPC;
        private Color ocBC;
        private Size ocSZ;
        private Point ocLC;
        public void server_BecomeInactive()
        {
            //isActiveServer = false;
            isActivePC = false;

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                this.TransparencyKey = Color.Turquoise;
                this.BackColor = Color.Turquoise;
                ocSZ = this.Size;
                this.Size = new Size(screenWidth + 1, screenHeight + 1);
                ocLC = this.Location;
                this.Location = new Point(0, 0);
                this.Deactivate += new EventHandler(Form1_Deactivate);
                this.Resize += new EventHandler(Form1_Resize);
                this.Move += new EventHandler(Form1_Move);
                this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
                //this.KeyPress += new KeyPressEventHandler(GetKeys);
                this.TopMost = true;
                this.KeyDown += new KeyEventHandler(GetKeysDown);
                this.KeyUp += new KeyEventHandler(GetKeysUp);
                this.MouseDown += new MouseEventHandler(GetMouseDown);
                this.MouseUp += new MouseEventHandler(GetMouseUp);
                this.MouseWheel += new MouseEventHandler(GetMouseWheel);
            });

            stopDrawingServerStuff(true);
        }

        private bool mouseLeft = false;
        private bool mouseMiddle = false;
        private bool mouseRight = false;
        private void GetMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                mouseLeft = true;
                sendMessage("m|1d");
            }
            else if (e.Button == MouseButtons.Middle)
            {
                mouseMiddle = true;
                sendMessage("m|3d");
            }
            else if (e.Button == MouseButtons.Right)
            {
                mouseRight = true;
                sendMessage("m|2d");
            }
        }

        int mWheelAmount = 0;
        private void GetMouseWheel(object sender, MouseEventArgs e)
        {
            mWheelAmount += e.Delta;
        }

        private void GetMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mouseLeft)
            {
                mouseLeft = false;
                sendMessage("m|1u");
            }
            else if (e.Button == MouseButtons.Middle && mouseMiddle)
            {
                mouseMiddle = false;
                sendMessage("m|3u");
            }
            else if (e.Button == MouseButtons.Right && mouseRight)
            {
                mouseRight = false;
                sendMessage("m|2u");
            }
        }


        private bool holdShift = false; //SHIFTKEY
        private bool holdControl = false; //
        private bool holdAlt = false;
        private bool isCaps = false;
        //private bool isSpecialCaps = false;
        private void GetKeysDown(object sender, KeyEventArgs e)
        {
            if (isServer && !isActivePC)
            {
                string keyPress = (e.KeyCode + "");
                if (keyPress.Length > 1)
                {
                    keyPress = keyPress.ToUpper();
                    if (keyPress == "SHIFTKEY")
                    {
                        holdShift = true;
                        return;
                    }
                    else if (keyPress == "CONTROLKEY")
                    {
                        holdControl = true;
                        return;
                    }
                    else if (keyPress == "MENU")
                    {
                        holdAlt = true;
                        return;
                    }
                    else if (keyPress == "BACK")
                    {
                        keyPress = "BACKSPACE";
                    }
                    else if (keyPress == "RETURN")
                    {
                        keyPress = "ENTER";
                    }
                    else if (keyPress == "CAPITAL")
                    {
                        keyPress = "CAPSLOCK";
                        isCaps = !isCaps;
                    }
                    else if (keyPress == "PAGEUP")
                    {
                        keyPress = "PGUP";
                    }
                    else if (keyPress == "NEXT")
                    {
                        keyPress = "PGDN";
                    }
                    else if (keyPress == "SCROLL")
                    {
                        keyPress = "SCROLLLOCK";
                    }
                    else if (keyPress == "PAUSE")
                    {
                        keyPress = "BREAK";
                    }
                    else if (keyPress == "D0" || keyPress == "D1" || keyPress == "D2" || keyPress == "D3" || keyPress == "D4" || keyPress == "D5" || keyPress == "D6" || keyPress == "D7" || keyPress == "D8" || keyPress == "D9")
                    {
                        keyPress = keyPress.Substring(1);
                    }
                    else if (keyPress == "NUMPAD0" || keyPress == "NUMPAD1" || keyPress == "NUMPAD2" || keyPress == "NUMPAD3" || keyPress == "NUMPAD4" || keyPress == "NUMPAD5" || keyPress == "NUMPAD6" || keyPress == "NUMPAD7" || keyPress == "NUMPAD8" || keyPress == "NUMPAD9")
                    {
                        keyPress = keyPress.Substring(6);
                    }
                    else if (keyPress == "SPACE")
                    {
                        keyPress = " ";
                    }
                    else if (keyPress == "OEMCOMMA")
                    {
                        if (holdShift)
                        {
                            keyPress = "<";
                        }
                        else
                        {
                            keyPress = ",";
                        }
                    }
                    else if (keyPress == "OEM1")
                    {
                        if (holdShift)
                        {
                            keyPress = ":";
                        }
                        else
                        {
                            keyPress = ";";
                        }
                    }
                    else if (keyPress == "OEM7")
                    {
                        if (holdShift)
                        {
                            keyPress = "\"";
                        }
                        else
                        {
                            keyPress = "'";
                        }
                    }
                    else if (keyPress == "OEMPERIOD")
                    {
                        if (holdShift)
                        {
                            keyPress = ">";
                        }
                        else
                        {
                            keyPress = ".";
                        }
                    }
                    else if (keyPress == "DECIMAL")
                    {
                        keyPress = ".";
                    }
                    else if (keyPress == "OEMQUESTION")
                    {
                        if (holdShift)
                        {
                            keyPress = "?";
                        }
                        else
                        {
                            keyPress = "/";
                        }
                    }
                    else if (keyPress == "OEMOPENBRACKETS")
                    {
                        if (holdShift)
                        {
                            keyPress = "{";
                        }
                        else
                        {
                            keyPress = "[";
                        }
                    }
                    else if (keyPress == "OEM6")
                    {
                        if (holdShift)
                        {
                            keyPress = "}";
                        }
                        else
                        {
                            keyPress = "]";
                        }
                    }
                    else if (keyPress == "OEM5")
                    {
                        if (holdShift)
                        {
                            keyPress = "|";
                        }
                        else
                        {
                            keyPress = "\\";
                        }
                    }
                    else if (keyPress == "OEMMINUS")
                    {
                        if (holdShift)
                        {
                            keyPress = "_";
                        }
                        else
                        {
                            keyPress = "-";
                        }
                    }
                    else if (keyPress == "OEMPLUS")
                    {
                        if (holdShift)
                        {
                            keyPress = "+";
                        }
                        else
                        {
                            keyPress = "=";
                        }
                    }
                    else if (keyPress == "OEMTILDE")
                    {
                        if (holdShift)
                        {
                            keyPress = "~";
                        }
                        else
                        {
                            keyPress = "`";
                        }
                    }

                    if (keyPress.Length > 1)
                    {
                        keyPress = "{" + keyPress + "}";
                    }
                }
                if(keyPress.Length==1)
                {
                    if (!isCaps)
                    {
                        keyPress = keyPress.ToLower();
                    }
                    if (keyPress == "+")
                    {
                        keyPress = "{+}";
                    }
                    else if (keyPress == "^")
                    {
                        keyPress = "{^}";
                    }
                    else if (keyPress == "%")
                    {
                        keyPress = "{%}";
                    }
                    else if (keyPress == "~")
                    {
                        keyPress = "{~}";
                    }
                    else if (keyPress == "(")
                    {
                        keyPress = "{(}";
                    }
                    else if (keyPress == ")")
                    {
                        keyPress = "{)}";
                    }
                    else if (keyPress == "{")
                    {
                        keyPress = "{{}";
                    }
                    else if (keyPress == "}")
                    {
                        keyPress = "{}}";
                    }
                }
                keyPress = (holdShift ? "+" : "") + (holdControl ? "^" : "") + (holdAlt ? "%" : "") + keyPress;
                sendMessage("k|" + keyPress);
                e.SuppressKeyPress = true;
            }
            //label1.Text = (e.KeyCode + "") + "|" + keyPress;
        }

        private void GetKeysUp(object sender, KeyEventArgs e)
        {
            if (isServer && !isActivePC)
            {
                string keyPress = (e.KeyCode + "").ToUpper();
                if (keyPress == "SHIFTKEY")
                {
                    holdShift = false;
                }
                else if (keyPress == "CONTROLKEY")
                {
                    holdControl = false;
                }
                else if (keyPress == "MENU")
                {
                    holdAlt = false;
                }
                e.SuppressKeyPress = true;
                //e.SuppressKeyPress = true;
            }
        }

        public void server_BecomeMain()
        {
            //isActiveServer = true;
            isActivePC = true;
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                this.Deactivate -= new EventHandler(Form1_Deactivate);
                this.Resize -= new EventHandler(Form1_Resize);
                this.Move -= new EventHandler(Form1_Move);
                this.FormClosing -= new FormClosingEventHandler(Form1_FormClosing);
                this.KeyDown -= new KeyEventHandler(GetKeysDown);
                this.KeyUp -= new KeyEventHandler(GetKeysUp);
                this.MouseDown -= new MouseEventHandler(GetMouseDown);
                this.MouseUp -= new MouseEventHandler(GetMouseUp);
                this.MouseWheel -= new MouseEventHandler(GetMouseWheel);
                this.TopMost = false;
                this.BackColor = ocBC;
                this.Size = ocSZ;
                this.Location = ocLC;
            });

            stopDrawingServerStuff(false);
        }

        public void connectionItter()
        {
            for(int i = 0; i < pcList.Count; i++)
            {
                for(int j = 0; j < pcList.Count; j++)
                {
                    if (j != i)
                    {
                        if((pcList[i].buttonid % 5 != 0) && pcList[i].buttonid == (pcList[j].buttonid - 1))
                        {
                            //MessageBox.Show(pcList[i].id+" is right of "+pcList[j].id);
                            pcList[j].left = pcList[i];
                            pcList[i].right = pcList[j];
                        }
                        else if ((pcList[i].buttonid % 5 != 4) && pcList[i].buttonid == (pcList[j].buttonid + 1))
                        {
                            //MessageBox.Show(pcList[i].id + " is left of " + pcList[j].id);
                            pcList[i].left = pcList[j];
                            pcList[j].right = pcList[i];
                        }
                        else if ((pcList[i].buttonid >= 5) && pcList[i].buttonid == (pcList[j].buttonid - 5))
                        {
                            //MessageBox.Show(pcList[i].id + " is below " + pcList[j].id);
                            pcList[i].down = pcList[j];
                            pcList[j].up = pcList[i];
                        }
                        else if ((pcList[i].buttonid <= 19) && pcList[i].buttonid == (pcList[j].buttonid + 5))
                        {
                            //MessageBox.Show(pcList[i].id + " is above " + pcList[j].id);
                            pcList[i].up = pcList[j];
                            pcList[j].down = pcList[i];
                        }
                    }
                }
            }
        }

        private bool firstClick = true;
        private List<PC> pcList = new List<PC>();
        private IPEndPoint currentPCEP = null;
        private void Button_ADDPC(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 2)
            {
                Button b = (Button)sender;
                b.Text = (string)listBox1.Items[2];
                b.Enabled = false;
                //send message?
                if (ipList[0] != "0")
                {
                    sendMessageOneTime("ok", ipList[0]);
                }
                pcList.Add(new PC(listBox1.Items[2].ToString(), ipList[0]));
                if (currentPC == null)
                {
                    currentPC = pcList[pcList.Count - 1];
                }
                ipList.RemoveAt(0);
                listBox1.Items.RemoveAt(2);
                for (int i = 0; i < buttons318and2028.Count; i++)
                {
                    buttons318and2028[i].Enabled = false;
                    if (buttons318and2028[i].Name == b.Name)
                    {
                        b.Text += " | " + i;
                        pcList[pcList.Count - 1].buttonid = i;
                    }
                }
                connectionItter();
                if (listBox1.Items.Count > 2)
                {
                    enableSomeButtons();
                }
                else if(firstClick)
                {
                    firstClick = false;
                    timer1.Start();
                }
            }
            //for (int i = 0; i < buttons318and2028.Count; i++)
            //{
            //    buttons318and2028[i].Click -= (ss, ee) => Button_ADDPC(sender, e, s);
            //}
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.Location.X != 0 || this.Location.Y != 0)
            {
                this.Location = new Point(0, 0);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Form1.ModifierKeys == Keys.Alt || Form1.ModifierKeys == Keys.F4)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            if (this.Size.Width != (screenWidth + 1) || this.Size.Height != (screenHeight + 1))
            {
                this.Size = new Size(screenWidth + 1, screenHeight + 1);
            }
        }

        private void Form1_Deactivate(Object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(screenWidth + 1, screenHeight + 1);
            this.Location = new Point(0, 0);
        }

        byte[] data;
        private void sendMessage(string msg)
        {
            data = Encoding.UTF8.GetBytes(msg);
            udpClient.Send(data, data.Length, currentPCEP);
        }

        private void sendMessageOneTime(string msg, string ip)
        {
            IPEndPoint otherPC = new IPEndPoint(IPAddress.Parse(ip), applicationPort);
            data = Encoding.UTF8.GetBytes(msg);
            udpClient.Send(data, data.Length, otherPC);
        }

        private bool switchPC(int i)
        {
            if (isServer)
            {
                xMoved = 0;
                yMoved = 0;
                string currentIP = currentPC.ip;
                bool didSwitch = false;
                if (i == 1 && currentPC.up!=null)
                {
                    didSwitch = true;
                    currentPC = currentPC.up;
                }
                else if (i == 2 && currentPC.right != null)
                {
                    didSwitch = true;
                    currentPC = currentPC.right;
                }
                else if (i == 3 && currentPC.down != null)
                {
                    didSwitch = true;
                    currentPC = currentPC.down;
                }
                else if (i == 4 && currentPC.left != null)
                {
                    didSwitch = true;
                    currentPC = currentPC.left;
                }
                if (didSwitch)
                {
                    if (currentIP != "0")
                    {
                        sendMessage("t|");
                    }
                    if (currentPC.ip == "0")
                    {
                        server_BecomeMain();
                    }
                    else
                    {
                        if (isActivePC == true)
                        {
                            server_BecomeInactive();
                        }
                        currentPCEP = new IPEndPoint(IPAddress.Parse(currentPC.ip), applicationPort);
                        int relPos = 0;
                        if(i==3 || i == 1)
                        {
                            relPos = (int)((((float)Cursor.Position.X) / (screenWidth))*100);
                        }
                        else
                        {
                            relPos = (int)((((float)Cursor.Position.Y) / (screenHeight)) * 100);
                        }
                        sendMessage("s|" + i+"|"+ relPos);//to do todo add stuff

                    }
                }
                return didSwitch;
            }
            return false;
        }

       



        private void button1_Click(object sender, EventArgs e)
        {
            isServer = true;
            isActivePC = true;
            udpClient = new UdpClient(applicationPort);
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;

            //this.KeyDown

            for (int i = 0; i < buttons318and2028.Count; i++)
            {
                buttons318and2028[i].Enabled = false;
                buttons318and2028[i].Visible = true;
            }
            label1.Enabled = true;
            label1.Visible = true;

            listBox1.Enabled = true;
            listBox1.Visible = true;

            listBox1.Items.Add("Queue");
            listBox1.Items.Add("----------");
            startUDPListener();
            addNewPC("This PC","0");

            //var udpListener = new Thread(() =>
            //{
            //
            //});
            //udpListener.IsBackground = true;
            //udpListener.Start();
            //start listen for connection request
            //enable button 3 to 18
        }

        Thread udpListener = null;
        FormWindowState preState;
        private void startUDPListener()
        {
            if(udpListener != null)
            {
                udpListener.Abort();
            }
            udpListener = new Thread(() =>
            {
                IPEndPoint receivingEP = new IPEndPoint(IPAddress.Any, applicationPort);
                while (true)
                {
                    byte[] receivedBytes = udpClient.Receive(ref receivingEP);
                    string clientMessage = Encoding.UTF8.GetString(receivedBytes);
                    if (clientMessage.Substring(0, 2) == "j|")
                    {
                        addNewPC(clientMessage.Substring(2, clientMessage.Length-2), receivingEP.Address.ToString());
                    }
                    else if (clientMessage.Substring(0, 2) == "s|")
                    {
                        //start tick and settings
                        if (isServer == false)
                        {
                            //this.label2.BeginInvoke((MethodInvoker)delegate ()
                            //{
                            //    label2.Text = clientMessage;
                            //});
                            string[] sep = clientMessage.Split('|');
                            if (sep[1] == "1")
                            {
                                Cursor.Position = new Point(((int)((float.Parse(sep[2])/100)*screenWidth)), screenHeight-50);
                                //relPos = (int)((((float)Cursor.Position.Y) / (screenHeight)) * 100);
                            }
                            else if (sep[1] == "3")
                            {
                                Cursor.Position = new Point(((int)((float.Parse(sep[2]) / 100) * screenWidth)), 50);
                            }
                            else if(sep[1]=="2")
                            {
                                Cursor.Position = new Point(50, ((int)((float.Parse(sep[2]) / 100) * screenHeight)));
                            }
                            else if (sep[1] == "1")
                            {
                                Cursor.Position = new Point(screenWidth-50, ((int)((float.Parse(sep[2]) / 100) * screenHeight)));
                            }

                            this.BeginInvoke((MethodInvoker)delegate ()
                            {
                                preState = this.WindowState;
                                this.WindowState = FormWindowState.Minimized;
                                timer1.Enabled = true;
                                timer1.Start();
                            });
                        }
                    }
                    else if (clientMessage.Substring(0, 2) == "t|")
                    {
                        //terminate tick and settings
                        if (isServer == false)
                        {
                            this.BeginInvoke((MethodInvoker)delegate ()
                            {
                                if (Cursor.Position.X < 50)
                                {
                                    Cursor.Position = new Point(50, Cursor.Position.Y);
                                }
                                else if (Cursor.Position.X > (screenWidth - 50))
                                {
                                    Cursor.Position = new Point((screenWidth - 50), Cursor.Position.Y);
                                }
                                if (Cursor.Position.Y < 50)
                                {
                                    Cursor.Position = new Point(Cursor.Position.X, 50);
                                }
                                else if (Cursor.Position.Y > (screenHeight - 50))
                                {
                                    Cursor.Position = new Point(Cursor.Position.X, (screenHeight - 50));
                                }
                                this.WindowState = preState;
                                timer1.Stop();
                            });
                        }
                    }
                    else if (clientMessage.Substring(0, 2) == "m|")
                    {
                        string mCommand = clientMessage.Substring(2);
                        if (mCommand == "1d")
                        {
                            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                        else if (mCommand == "2d")
                        {
                            mouse_event(MOUSEEVENTF_RIGHTDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                        else if (mCommand == "3d")
                        {
                            mouse_event(MOUSEEVENTF_MIDDLEDOWN, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                        else if (mCommand == "1u")
                        {
                            mouse_event(MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                        else if (mCommand == "2u")
                        {
                            mouse_event(MOUSEEVENTF_RIGHTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                        else if (mCommand == "3u")
                        {
                            mouse_event(MOUSEEVENTF_MIDDLEUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
                        }
                        else
                        {
                            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, int.Parse(mCommand), 0);
                        }
                    }
                    else if(clientMessage.Substring(0,2) == "p|")
                    {
                        string[] sep = clientMessage.Split('|');
                        Cursor.Position = new Point(Cursor.Position.X+int.Parse(sep[1]), Cursor.Position.Y + int.Parse(sep[2]));
                    }
                    else if (clientMessage.Substring(0, 2) == "k|")
                    {
                        keys.Add(clientMessage.Substring(2));
                        this.label2.BeginInvoke((MethodInvoker)delegate ()
                        {
                            label2.Text=clientMessage.Substring(2);
                        });
                    }
                    else if (clientMessage.Substring(0, 2) == "w|")
                    {
                        if (isServer)
                        {
                            switchPC(int.Parse(clientMessage.Substring(2)));
                        }
                    }

                }
            });
            udpListener.IsBackground = true;
            udpListener.Start();
        }

        private int xPrev = 0;
        private int xMoved = 0;
        //private int xTotal = 0;

        private int yPrev = 0;
        private int yMoved = 0;
        //private int yTotal = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int xFast = Cursor.Position.X;
            int yFast = Cursor.Position.Y;

            xMoved = xFast - xPrev;
            //xTotal += xMoved;
            xPrev = xFast;

            yMoved = yFast - yPrev;
            //yTotal += yMoved;
            yPrev = yFast;

            //label1.Text = xTotal + ", " + yTotal;
            if (!isActivePC && isServer)
            {
                xPrev = screenWidth / 2;
                yPrev = screenHeight / 2;
                Cursor.Position = new Point(screenWidth / 2, screenHeight / 2);
                if (!(xMoved == 0 && yMoved == 0))
                {
                    sendMessage("p|" + xMoved + "|" + yMoved);
                }
                if (mWheelAmount != 0)
                {
                    sendMessage("m|" + mWheelAmount);
                    mWheelAmount = 0;
                }
                //label2.Text = "Sent";

            }

            if (!isServer)
            {
                if (keys.Count > 0)
                {
                    try
                    {
                        SendKeys.Send(keys[0]);
                        keys.RemoveAt(0);
                    }
                    catch (Exception ex)
                    {
                        keys[0] = keys[0].Replace("{", "");
                        keys[0] = keys[0].Replace("}", "");
                        SendKeys.Send(keys[0]);
                        keys.RemoveAt(0);
                    }

                }
            }

            //label2.Text = "Dif: (" + xMoved +", "+yMoved+")\nTotal: (" + xTotal+", "+yTotal+") ML"+(Control.MouseButtons == MouseButtons.Left)+"MR"+ (Control.MouseButtons == MouseButtons.Right)+"MM"+ (Control.MouseButtons == MouseButtons.Middle);
            if (xFast <= 0)
            {
                if (isServer)
                {
                    if (switchPC(4))
                    {
                        Cursor.Position = new Point(screenWidth / 2, yFast);
                    }
                }
                else
                {
                    sendMessage("w|4");
                }
                //Cursor.Hide();
                xPrev = screenWidth / 2;

            }
            else if (xFast >= screenWidth)
            {
                if (isServer)
                {
                    if (switchPC(2))
                    {
                        Cursor.Position = new Point(screenWidth / 2, yFast);
                    }
                }
                else
                {
                    sendMessage("w|2");
                }
                //MessageBox.Show(currentPC.right.id);
                xPrev = screenWidth / 2;
                
            }
            else if (yFast <= 0)
            {
                if (isServer)
                {
                    if (switchPC(1))
                    {
                        Cursor.Position = new Point(xFast, screenHeight / 2);
                    }
                }
                else
                {
                    sendMessage("w|1");
                }
                //MessageBox.Show(currentPC.up.id);
                yPrev = screenHeight / 2;
                //Cursor.Position = new Point(xFast, screenHeight / 2);
            }
            else if (yFast >= screenHeight)
            {
                if (isServer)
                {
                    if (switchPC(3))
                    {
                        Cursor.Position = new Point(xFast, screenHeight / 2);
                    }
                }
                else
                {
                    sendMessage("w|3");
                }
                //MessageBox.Show(currentPC.down.id);
                yPrev = screenHeight / 2;
                //Cursor.Position = new Point(xFast, screenHeight / 2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isServer = false;
            isActivePC = false;
            udpClient = new UdpClient(applicationPort);
            button1.Enabled = false;
            //button1.Visible = false;
            button2.Enabled = false;
            //button2.Visible = false;

            textBox1.Enabled = true;
            textBox1.Visible = true;

            label2.Enabled = true;
            label2.Visible = true;

            button19.Enabled = true;
            button19.Visible = true;
            //enable ip thing
            //add a connect button?
        }

        int applicationPort = 25002;
        UdpClient udpClient = null;
        string serverIP = "";
        private void button19_Click(object sender, EventArgs e)
        {
            //udpClient = new UdpClient(applicationPort);
            sendMessageOneTime("j|" + Environment.MachineName + "/" + Environment.UserName, textBox1.Text);
            serverIP = textBox1.Text;

            IPEndPoint otherPC = new IPEndPoint(IPAddress.Any, applicationPort);
            byte[] receivedBytes = udpClient.Receive(ref otherPC);
            if (otherPC.Address.ToString()==serverIP)
            {
                currentPCEP = new IPEndPoint(IPAddress.Parse(textBox1.Text), applicationPort);
                button19.Enabled = false;
                textBox1.Enabled = false;
                //timer2.Start();
                startUDPListener();
            }
        }

        List<string> keys = new List<string>();

    }

    public class PC
    {
        public string id = "";
        public string ip = "";
        public int buttonid=-1;

        public PC up;
        public PC down;
        public PC left;
        public PC right;

        public PC() {}

        public PC(string d, string p)
        {
            id = d;
            ip = p;
            buttonid = -1;
        }


    }
}
