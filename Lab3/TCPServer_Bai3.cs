﻿using System;
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
using System.Threading;

namespace Lab3
{
    public partial class TCPServer_Bai3 : Form
    {
        private delegate void SafeCallDelegate(string text);
        public TCPServer_Bai3()
        {
            InitializeComponent();
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            listenBtn.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(startSafeThread));
            serverThread.Start();
            /*var threadParameters = new System.Threading.ThreadStart(delegate { startSafeThread(); });
            var thread2 = new System.Threading.Thread(threadParameters);
            thread2.Start();*/
        }

        void startSafeThread()
        {
            int bytesReceived = 0;
            //khởi tạo mảng byte nhận dữ liệu
            byte[] recv = new byte[3];
            //tạo socket bên gửi
            Socket clientSocket;

            //Tạo socket bên nhận
            TcpListener listenerSocket = new TcpListener(8080);

            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            //Gán socket lắng nghe tới địa chỉ IP của máy và port 8080
            listenerSocket.Bind(ipepServer);
            /*if (listenBtn.InvokeRequired)
            {
                listenBtn.Invoke(new MethodInvoker(delegate
                {
                    listenBtn.Enabled = false;
                }));
            }
            else
            {*/
                listenBtn.Enabled = false;
            //}

            //bắt đầu lắng nghe .Socket.Listen(int backlog)
            //với backlog: là độ dài tối đa của hàng đợi 
            listenerSocket.Listen(-1);
            //đồng ý kết nối
            clientSocket = listenerSocket.Accept();
            //nhận dữ liệu
            //InforMessages("New client connected");
            listView1.Items.Add(new ListViewItem("New client connected!"));
            byte t = Convert.ToByte('\n');
            while (clientSocket.Connected)
            {
                
                string mess = "";
                byte[] recvRes = new byte[50];
                List<byte> res = new List<byte>();
                do
                {
                    
                    bytesReceived = clientSocket.Receive(recv);

                    for (int i = 0; i < recv.Length; i++)
                    {
                        res.Add(recv[i]);
                        if (recv[i] == t) { break; }
                    }
                    recvRes = res.ToArray();
                    mess = Encoding.UTF8.GetString(recvRes);
                } while (mess[mess.Length - 1] != '\n');
                //InforMessages(mess);
                if (mess == "Quit")
                {
                    listenerSocket.Close();
                    break;
                }
                listView1.Items.Add(new ListViewItem(mess));
                //listenerSocket.Close();
            }
            listenBtn.Enabled = true;
            
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
