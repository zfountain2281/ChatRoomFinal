using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        //member variables
        Dictionary<int, ISubscriber> users;
        TcpListener server;
        Queue<Message> messages;
        ILoggable log;

        //constructor
        public Server()
        {
            messages = new Queue<Message>();
            users = new Dictionary<int, ISubscriber>();
            log = new TextLogger();
            string computerIPAddress = GetIPAddress();
            Console.WriteLine("Local Computer IP Address: " + computerIPAddress);
            Console.WriteLine();
            server = new TcpListener(IPAddress.Parse(computerIPAddress), 9999);
            server.Start();
        }



        string GetIPAddress()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipaddress = Dns.GetHostAddresses(hostName);
            string computerIPAddress = "127.0.0.1";
            foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
            {
                computerIPAddress = ip4.ToString();
            }
            return computerIPAddress;
        }
        public void Run()
        {
            while (true)
            {
                Parallel.Invoke(
                    //This thread is always listening for new clients (users)
                    async () =>
                    {
                        await AcceptUser();
                    },
                    //This thread is always listening for new messages
                    async () =>
                    {
                        await GetAllMessages();
                    },
                    //This thread is always sending new messages
                    async () =>
                    {
                        await SendAllMessages();
                    },
                    async () =>
                    {
                        await CheckIfConnected();
                    }

                );
            }
        }

        Task CheckIfConnected()
        {
            return Task.Run(() =>
            {
                Object userListLock = new Object();
                lock (userListLock)
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        Client currentUser = (Client)users.ElementAt(i).Value;
                        if (!currentUser.CheckIfConnected())
                        {
                            int userKey = users.ElementAt(i).Key;
                            users.Remove(userKey);
                        }
                    }
                }
            });
        }

        Task SendAllMessages()
        {
            return Task.Run(() =>
            {
                Object messageLock = new Object();
                lock (messageLock)
                {
                    if (messages.Count > 0)
                    {
                        for (int i = 0; i < users.Count; i++)
                        {
                            for (int j = 0; j < messages.Count; j++)
                            {
                                users.ElementAt(i).Value.Send(messages.ElementAt(j));
                            }
                        }
                        messages.Clear();
                    }
                }
            });
        }

        Task SendUserMessage(Client user, Message message)
        {
            return Task.Run(() =>
            {
                Object messageLock = new Object();
                lock (messageLock)
                {
                    if (user.CheckIfConnected())
                    {
                        user.Send(message);
                    }
                }
            });
        }

        Task GetAllMessages()
        {
            return Task.Run(() =>
            {
                Object messageLock = new Object();
                lock (messageLock)
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        Parallel.Invoke(
                            async () =>
                            {
                                await GetUserMessage(users.ElementAt(i).Value);
                            }
                        );
                    }
                }
            });
        }

        Task GetUserMessage(ISubscriber user)
        {
            return Task.Run(() =>
            {
                Object messageLock = new Object();
                lock (messageLock)
                {
                    if (user.CheckIfConnected())
                    {
                        Message message = user.Recieve();
                        Console.WriteLine(message.Body);
                        log.Save(message);
                        messages.Enqueue(message);
                    }
                }
            });
        }

        Task AcceptUser()
        {
            return Task.Run(() =>
            {
                Object userListLock = new Object();
                lock (userListLock)
                {
                    TcpClient clientSocket = default(TcpClient);
                    clientSocket = server.AcceptTcpClient();
                    Console.WriteLine("Connected");
                    NetworkStream stream = clientSocket.GetStream();
                    Client user = new Client(stream, clientSocket);
                    user.displayName = user.ReceiveDisplayName();
                    users.Add(user.UserId, user);
                    Message notification = new Message(user, "I've joined the chat!");
                    log.Save(notification);
                    for (int i = 0; i < users.Count; i++)
                    {
                        users.ElementAt(i).Value.Send(notification);
                    }
                }
            });
        }

    }
}
