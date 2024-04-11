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

namespace Lab3
{
    public partial class TCPClient_Bai3 : Form
    {
        TcpClient tcpClient;
        NetworkStream ns;
        public TCPClient_Bai3()
        {
            InitializeComponent();
        }

        private void TCPClient_Bai3_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
            //Tạo đối tượng TCPClient
            tcpClient = new TcpClient();

            //Kết nối đến server với 1 địa chỉ Ip và Port xác định
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);
            tcpClient.Connect(ipEndPoint);

            //Tạo luồng để đọc và ghi dữ liệu dựa trên NetworkStream
            ns = tcpClient.GetStream();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dùng phương thức Write để gửi dữ liệu đến Server
            Byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello\n");
            ns.Write(data, 0, data.Length);
        }

        private void TCPClient_Bai3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Byte[] data = System.Text.Encoding.UTF8.GetBytes("Quit");
            MessageBox.Show("quit");
            ns.Write(data, 0, data.Length);
            ns.Close();
            tcpClient.Close();
        }
    }
}
