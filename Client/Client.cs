using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class Client
    {
        public TcpClient clientSocket;
        public NetworkStream stream;
        public List<string> temporaryMessageList;
        public string serverIPAddress = "";
        string displayName;
        
        




        public Client(int port, string displayName, string serverIPAddress)
        {
            //while (serverIPAddress.Length < 13)
            //{
            //    Console.WriteLine("Please enter the IP Address for the Server Computer");
            //    serverIPAddress = UI.GetInput();
            //}
            temporaryMessageList = new List<string>();
            this.displayName = displayName;
            this.serverIPAddress = serverIPAddress;
            clientSocket = new TcpClient();
            clientSocket.Connect(IPAddress.Parse(serverIPAddress), port);
            stream = clientSocket.GetStream();
            //UI.DisplayMessage("Connected! Enter your display name:");

            //string displayName = UI.GetInput();

            byte[] message = Encoding.ASCII.GetBytes(displayName);
            stream.Write(message, 0, message.Count());
        }
        public Task Send(string typedMessage)
        {
            return Task.Run(() =>
            {
                Object messageLock = new Object();
                lock (messageLock)
                {
                    if (clientSocket.Connected)
                    {

                        byte[] message = Encoding.ASCII.GetBytes(typedMessage);
                        stream.Write(message, 0, message.Count());
                    }
                }
            });
        }
        public Task Receive(ListBox listBox)
        {

            return Task.Run(() =>
            {
                Object messageLock = new Object();
                lock (messageLock)
                {
                    while(temporaryMessageList.Count < 10)
                    {
                        string message ="";
                        byte[] recievedMessage = new byte[256];
                        message = Encoding.ASCII.GetString(recievedMessage);
                        if (message.Count(char.IsLetter) >= 1)
                        {
                            temporaryMessageList.Add(message);
                            //if (listBox.InvokeRequired)
                            //{
                            //    listBox.Invoke(new MethodInvoker(delegate { listBox.Items.Add(message); }));
                            //}
                        }

                    }

                }

            });

        }

        public void Run(ListBox listbox)
        {
            //while (true)
            //{

            //Parallel.Invoke(


            //    //This thread is always listening for new messages
            //    async () =>
            //    {
            //        await Receive(listbox);
            //    }
            //);
            System.Threading.Thread newThread = new System.Threading.Thread(() =>Receive(listbox));
            newThread.Start();
            //while (true)
            //{
                
            //    Receive(listbox);
            //}
            //    async () =>
            //    {
            //        await Receive(listbox);
            //    }
            //);
            //}
        }
    }
}

