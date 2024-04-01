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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab3
{
    public partial class UDPServer_Bai1 : Form
    {
        private delegate void SafeCallDelegate(string text);
        private Thread thread = null;
        public UDPServer_Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(serverThread));
            thread.Start();
            button1.Enabled = false;
        }
        public void serverThread()
        {
            int port = Convert.ToInt32(tbPort.Text);
            UdpClient udpClient = new UdpClient(port);
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.UTF8.GetString(receiveBytes);
                string mess = RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString();
                InforMessages(mess);
            }
        }
        private void InforMessages (string mess)
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
