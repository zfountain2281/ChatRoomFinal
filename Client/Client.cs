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
        public string serverIPAddress = "";
        string displayName;
        int port = 9999;




        public Client(int port, string displayName, string serverIPAddress)
        {
            //while (serverIPAddress.Length < 13)
            //{
            //    Console.WriteLine("Please enter the IP Address for the Server Computer");
            //    serverIPAddress = UI.GetInput();
            //}
            
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
        public Task Receive()
        {
            return Task.Run(() =>
            {
                Object messageLock = new Object();
                lock (messageLock)
                {
                    if (clientSocket.Connected)
                    {
                        byte[] recievedMessage = new byte[256];
                        UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
                    }
                }
            });
        }

        public Task Run()
        {
            while (true)
            {

                Parallel.Invoke(
                //This thread is always allowing the client to send new messages
                //async () =>
                //{
                //    await Send(typedMessage);
                //},
                //This thread is always listening for new messages
                async () =>
                {
                    await Receive();
                });
              
                }
        }
    }
}

