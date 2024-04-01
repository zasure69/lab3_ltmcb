using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Bai2 : Form
    {
        private delegate void SafeCallDelegate(string text);
        public Bai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(startSafeThread));
            serverThread.Start();
        }

        void startSafeThread ()
        {
            int bytesReceived = 1;
            //khởi tạo mảng byte nhận dữ liệu
            byte[] recv = new byte[bytesReceived];
            //tạo socket bên gửi
            Socket clientSocket;

            //Tạo socket bên nhận
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            //Gán socket lắng nghe tới địa chỉ IP của máy và port 8080
            listenerSocket.Bind(ipepServer);
            button1.Enabled = false;
            //bắt đầu lắng nghe .Socket.Listen(int backlog)
            //với backlog: là độ dài tối đa của hàng đợi 
            listenerSocket.Listen(-1);
            //đồng ý kết nối
            clientSocket = listenerSocket.Accept();
            //nhận dữ liệu
            InforMessages("New client connected");
            while (clientSocket.Connected)
            {
                string mess = "";
                do
                {
                    bytesReceived = clientSocket.Receive(recv);
                    mess += Encoding.UTF8.GetString(recv);
                } while (mess[mess.Length - 1] != '\n');
                InforMessages(mess);
                listenerSocket.Close();
            }
        }

        private void InforMessages(string mess)
        {
            if (listView1.InvokeRequired)
            {
                var d = new SafeCallDelegate(InforMessages);
                listView1.Invoke(d, new object[] { mess });
            }
            else
            {
                listView1.Items.Add(new ListViewItem(mess));
            }
        }
    }
}
