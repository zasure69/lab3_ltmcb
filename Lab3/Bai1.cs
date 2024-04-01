using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UDPServer_Bai1 udpServer = new UDPServer_Bai1();
            udpServer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UDPClient_Bai1 udpClient = new UDPClient_Bai1();
            udpClient.Show();
        }
    }
}
