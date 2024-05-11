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
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TCPServer_Bai3 tCPServer_Bai3 = new TCPServer_Bai3();
            tCPServer_Bai3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCPClient_Bai3 tCPClient_Bai3 = new TCPClient_Bai3();
            tCPClient_Bai3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
