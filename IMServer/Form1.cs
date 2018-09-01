using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMServer
{
    public partial class Form1 : Form
    {
        UserAccount userAccount;
        private TcpListener listener = null;
        List<TCPClientState> clientList = new List<TCPClientState>();
        public delegate void appendTextDelegate(String str);
        public int flag = 1;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(UserAccount account)
        {
            userAccount = account;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnStartLinsten_Click(object sender, EventArgs e)
        {
            String serverIP = this.tbServerIP.Text;
            IPEndPoint iPEndPoint = null;
            IPAddress iPAddress = null;
            int port;
            try
            {
                port = Int32.Parse(this.tbPort.Text);
                iPAddress = IPAddress.Parse(serverIP);
                iPEndPoint = new IPEndPoint(iPAddress, port);
                listener = new TcpListener(iPEndPoint);
                tbLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss 开始监听本地9000端口，等待连接！\n"));
                listener.Start();
                listener.BeginAcceptTcpClient(new AsyncCallback(acceptClientCallback), listener);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void acceptClientCallback(IAsyncResult ar)
        {
            TcpListener lstn = (TcpListener)ar.AsyncState;
            if (lstn != null)
            {
                TcpClient client = lstn.EndAcceptTcpClient(ar);
                this.Invoke((EventHandler)delegate{
                    tbLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss "+client.Client.RemoteEndPoint+"加入连接！\n"));
                });
                byte[] buffer = new byte[client.ReceiveBufferSize];
                TCPClientState state = new TCPClientState(client, buffer);
                clientList.Add(state);
                NetworkStream stream = state.NetworkStream;
                stream.BeginRead(state.Buffer, 0, state.Buffer.Length, HandleDataReceived, state);
                listener.BeginAcceptTcpClient(new AsyncCallback(acceptClientCallback), ar.AsyncState);
            }
        }

        private void HandleDataReceived(IAsyncResult ar)
        {
            TCPClientState state = (TCPClientState)ar.AsyncState;
            NetworkStream stream = state.NetworkStream;
            if (state != null)
            {
                int recv = 0;
                try
                {
                    recv = stream.EndRead(ar);
                    byte[] buff = new byte[recv];
                    Buffer.BlockCopy(state.Buffer, 0, buff, 0, recv);
                    String str = Encoding.UTF8.GetString(buff);
                    string instruction = str.Substring(0, 3);
                    string content = str.Substring(3);
                    switch (instruction)
                    {
                        case "@1@":
                            string[] addInfo = content.Split(',');
                            string userName = addInfo[0];
                            string password = addInfo[1];
                            break;
                        case "@2@":
                            this.Invoke(new MethodInvoker(() => {
                                this.tbChatContent.AppendText(state.clientName + " 发来：" + content + "\n");
                            }));
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {
                    recv = 0;
                    stream.Close();
                    state.TcpClient.Close();
                    clientList.Remove(state);
                    this.Invoke(new MethodInvoker(() => {
                        this.cbClientList.Items.Clear();
                        foreach (TCPClientState s in clientList)
                        {
                            this.cbClientList.Items.Add(s.clientName);
                        }
                    }));
                    return;
                    //MessageBox.Show(ex.Message); 
                }

                try
                {
                    stream.BeginRead(state.Buffer, 0, state.Buffer.Length, HandleDataReceived, state);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void appendTextInvoke(string str)
        {
            appendTextDelegate myDelegate = new appendTextDelegate(appendTextInvoke);
            if (this.tbChatContent.InvokeRequired)
            {
                this.tbChatContent.Invoke(myDelegate, str);
            }
            else
            {
                //InvokedRequired is false, so call the control directly
                this.tbChatContent.AppendText(str);
            }
        }

        private void appendTextToCombox(String str)
        {
            appendTextDelegate myDelegate = new appendTextDelegate(appendTextToCombox);
            if (this.cbClientList.InvokeRequired)
            {
                this.cbClientList.Invoke(myDelegate, str);
            }
            else
            {
                this.cbClientList.Items.Add(str);
            }
        }

        public void Send(TcpClient client, byte[] data)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            if (data == null)
                throw new ArgumentNullException("data");
            client.GetStream().BeginWrite(data, 0, data.Length, SendDataEnd, client);
        }

        private void SendDataEnd(IAsyncResult ar)
        {
            ((TcpClient)ar.AsyncState).GetStream().EndWrite(ar);
        }

        private void lbPort_Click(object sender, EventArgs e)
        {

        }

        private void btnStopListen_Click(object sender, EventArgs e)
        {
            if (this.listener != null)
            {
                listener.Stop();
                MessageBox.Show("已停止监听！");
            }
            else
            {
                MessageBox.Show("服务未开启");
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            String nowClientName = this.cbClientList.Text;
            if (String.IsNullOrEmpty(nowClientName))
            {
                MessageBox.Show("请先选择发送对象！");
            }
            else
            {
                TCPClientState nowClientState = null;
                foreach (TCPClientState s in clientList)
                {
                    if (s.clientName.Equals(nowClientName))
                    {
                        nowClientState = s;
                        Console.WriteLine("即将发送给："+s.clientName);
                        break;
                    }
                }
                    
                byte[] bytes;
                String msg = this.tbSendData.Text;
                try
                {
                    bytes = Encoding.UTF8.GetBytes(msg);
                    Send(nowClientState.TcpClient, bytes);
                    tbChatContent.AppendText("发→"+ nowClientState.clientName + "：" + msg + "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbClientList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

    class TCPClientState
    {
        /// <summary>
        /// 与客户端相关的TcpClient
        /// </summary>
        public TcpClient TcpClient { get; private set; }

        /// <summary>
        /// 获取缓冲区
        /// </summary>
        public byte[] Buffer { get; private set; }

        public string clientName { get; set; }

        public int userId { get; set; }

        /// <summary>
        /// 获取网络流
        /// </summary>
        public NetworkStream NetworkStream
        {
            get { return TcpClient.GetStream(); }
        }

        public TCPClientState(TcpClient tcpClient, byte[] buffer)
        {
            if (tcpClient == null)
                throw new ArgumentNullException("tcpClient");
            if (buffer == null)
                throw new ArgumentNullException("buffer");

            this.TcpClient = tcpClient;
            this.Buffer = buffer;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            //关闭数据的接受和发送
            TcpClient.Close();
            Buffer = null;
        }
    }

}
