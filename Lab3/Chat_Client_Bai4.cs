using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace Lab3
{
    public partial class Chat_Client_Bai4 : Form
    {
        public Chat_Client_Bai4()
        {
            InitializeComponent();
        }

        TcpClient tcpClient;
        Stream stream;
        bool read = true;
        Thread clientThread;
        private void Chat_Client_Bai4_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
            //Tạo đối tượng TCPClient
            tcpClient = new TcpClient();
            

            //Kết nối đến server với 1 địa chỉ Ip và Port xác định
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
            tcpClient.Connect(ipEndPoint);

            //Tạo luồng để đọc và ghi dữ liệu dựa trên NetworkStream
            stream = tcpClient.GetStream();
            clientThread = new Thread(new ThreadStart(Receive));
            clientThread.Start();
        }

        private void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] recvBytes = new byte[1024];
                    stream.Read(recvBytes, 0, recvBytes.Length);
                    string Data = Encoding.UTF8.GetString(recvBytes);
                    // Gọi hàm hiển thị thông điệp nhận được lên màn hình
                    InforMessages(Data);

                }
            }
            catch(Exception ex)
            {
                if (ex.ToString().Contains("WSACancelBlockingCall"))
                {
                    stream.Close();
                    clientThread.Abort();
                    tcpClient.Close();
                }
            }
            
        }

        private delegate void SafeCallDelegate(string text);
        private void InforMessages(string mess)
        {
            if (listViewChat.InvokeRequired)
            {
                var d = new SafeCallDelegate(InforMessages);
                listViewChat.Invoke(d, new object[] { mess });
            }
            else
            {
                listViewChat.Items.Add(new ListViewItem(mess));
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //Dùng phương thức Write để gửi dữ liệu đến Server
            string mess = tbName.Text + ": " + tbMessage.Text + "\n";
            byte[] data = Encoding.UTF8.GetBytes(mess);
            stream.Write(data, 0, data.Length);
            if (mess.ToLower().Contains("thoát"))
            { 
                tcpClient.Close();
                stream.Close();
                clientThread.Abort();
            }
            InforMessages(mess);
        }
    }
}
