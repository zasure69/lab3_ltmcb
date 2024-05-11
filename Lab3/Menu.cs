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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai1 b = new Bai1();
            b.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai2 b = new Bai2();
            b.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bai3 b = new Bai3();
            b.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bai4 b = new Bai4();
            b.ShowDialog();
        }
    }
}
