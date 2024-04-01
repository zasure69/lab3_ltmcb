using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class UDPClient_Bai1 : Form
    {
        public UDPClient_Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Tạo kết nối UDP
            UdpClient udpClient = new UdpClient();
            //Chuyển chuỗi Hello sang kiểu byte
            Byte[] sendBytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
            udpClient.Send(sendBytes, sendBytes.Length, tbHost.Text, Convert.ToInt32(tbPort.Text));
            richTextBox1.ResetText();
        }
    }
}
