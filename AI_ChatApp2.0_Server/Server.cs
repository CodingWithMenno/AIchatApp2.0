using AI_ChatApp2._0_Server.Mbot;
using SharedClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AI_ChatApp2._0_Server
{
    class Server
    {
        private TcpListener Listener;
        public MBotHandler BotHandler;
        private List<ServerClient> Clients;


        static void Main(string[] args)
        {
            Server server = new Server();
            Console.ReadLine();
        }

        public Server()
        {
            StartupServer();
            Console.WriteLine("Server init done");
        }

        private void StartupServer()
        {
            try
            {
                this.Clients = new List<ServerClient>();

                int Port = 42069;
                IPAddress IPAdress = IPAddress.Parse("192.168.112.4");

                this.Listener = new TcpListener(IPAddress.Any, Port);
                this.Listener.Start();

                this.Listener.BeginAcceptTcpClient(new AsyncCallback(onClientAccepted), null);

                this.BotHandler = new MBotHandler(this);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong while setting up the server: {e.Message} ");
                System.Environment.Exit(0);
            }
        }

        private void onClientAccepted(IAsyncResult ar)
        {
            TcpClient client = this.Listener.EndAcceptTcpClient(ar);
            Console.WriteLine($"A new client connected to the server: {client.Client.RemoteEndPoint}");

            this.Listener.BeginAcceptTcpClient(new AsyncCallback(onClientAccepted), null);
            this.Clients.Add(new ServerClient(this, client));
        }

        public void Broadcast(Sentence message, Sentence.Type type)
        {
            foreach (var Client in this.Clients)
            {
                Client.SendMessage(new Sentence()
                {
                    Sender = message.Sender,
                    Data = message.Data,
                    MessageType = type
                }); ;
            }
        }

        public void SendToUser(string sender, string message)
        {
            foreach (var client in this.Clients.Where(c => sender == c.Name))
            {
                client.SendMessage(new Sentence()
                {
                    Sender = "Server",
                    Data = message,
                    MessageType = Sentence.Type.SERVER_MESSAGE
                });
            }
        }

        public void SendToUser(Sentence sentence)
        {
            foreach (var client in this.Clients.Where(c => sentence.Sender == c.Name))
            {
                client.SendMessage(sentence);
            }
        }

        public void SendClientList()
        {
            string usersString = "";
            this.Clients.ForEach(e => usersString += e.Name + "\n");

            foreach (var Client in this.Clients)
            {
                Client.SendMessage(new Sentence()
                {
                    Sender = "Server",
                    Data = usersString,
                    MessageType = Sentence.Type.USERSMESSAGE
                }); ;
            }
        }

        public void SendServerMessage(string message)
        {
            foreach (var Client in this.Clients)
            {
                Client.SendMessage(new Sentence()
                {
                    Sender = "Server",
                    Data = message,
                    MessageType = Sentence.Type.SERVER_MESSAGE
                }); ;
            }
        }

        public bool SendDisconnectRequest(string receiver, string message)
        {
            foreach (var client in this.Clients.Where(c => receiver == c.Name))
            {
                client.SendMessage(new Sentence()
                {
                    Sender = "Server",
                    Data = message,
                    MessageType = Sentence.Type.DISCONNECT_REQUEST
                });
                return true;
            }
            return false;
        }

        public void Disconnect(ServerClient client)
        {
            //TODO verbeteren
            this.Clients.Remove(client);
            SendClientList();
            SendServerMessage($"<{client.Name}> disconnected from the server.");
            Console.WriteLine("A client disconnected from the server");
        }
    }
}
