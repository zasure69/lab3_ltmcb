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
    public partial class Bai4 : Form
    {
        public Bai4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server_Bai4 server_Bai4 = new Server_Bai4();
            server_Bai4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chat_Client_Bai4 chat_client = new Chat_Client_Bai4();
            chat_client.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
