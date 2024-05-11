using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Lab3
{
    public partial class Server_Bai4 : Form
    {
        private delegate void SafeCallDelegate(string text);
        private List<TcpClient> clientsList = new List<TcpClient>();
        TcpListener listener;
        int cnt = 1;
        public Server_Bai4()
        {
            InitializeComponent();
        }

        private async void listenBtn_Click(object sender, EventArgs e)
        {
            listenBtn.Enabled = false;
            await Task.Run(() => startListen());
            
        }

        void startListen()
        {
            try
            {
                
                listener = new TcpListener(IPAddress.Any, 8083);
                while (true)
                {
                    listener.Start();
                    Thread serverThread = new Thread(new ThreadStart(safeServerThread));
                    serverThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void safeServerThread()
        {
            while(true)
            {
                TcpClient client = listener.AcceptTcpClient();
                InforMessages("Client " + cnt.ToString() + " mới đã kết nối vào\n");
                
                Thread clientThread = new Thread(() => startSafeThread(client));
                clientThread.Start();
                cnt++;
            }
        }

        void startSafeThread(TcpClient client )
        {
            try
            {
                clientsList.Add(client);
                int index = cnt - 1;
                StreamReader reader = new StreamReader(client.GetStream());
                while (true)
                {
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        InforMessages(message);
                        BroadCast(message, client);
                    }
                    else
                    {
                        InforMessages("Client " + index.ToString() + " đã thoát");
                        break;
                    }

                }
                
                clientsList.Remove(client);
                reader.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BroadCast(string mess, TcpClient excludedClient)
        {
            foreach (TcpClient t in clientsList)
            {
                if (t != excludedClient)
                {
                    try
                    {
                        StreamWriter writer = new StreamWriter(t.GetStream());
                        writer.WriteLine(mess);
                        writer.Flush();
                    }
                    catch (Exception ex) 
                    { 
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void InforMessages(string mess)
        {
            if (listViewChatRoom.InvokeRequired)
            {
                var d = new SafeCallDelegate(InforMessages);
                listViewChatRoom.Invoke(d, new object[] { mess });
            }
            else
            {
                listViewChatRoom.Items.Add(new ListViewItem(mess));
            }
        }
    }
}
