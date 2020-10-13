using SharedClasses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace AI_ChatApp2._0_Server
{
    class Server
    {
        private TcpListener Listener;

        private List<ServerClient> Clients;


        static void Main(string[] args)
        {
            Server server = new Server();
        }

        public Server()
        {
            StartupServer();
            Console.WriteLine("Server init done");
            Console.ReadLine();
        }

        private void StartupServer()
        {
            try
            {
                this.Clients = new List<ServerClient>();

                int Port = 42069;
                //IPAddress IPAdress = IPAddress.Parse("localhost");

                this.Listener = new TcpListener(IPAddress.Any, Port);
                this.Listener.Start();

                this.Listener.BeginAcceptTcpClient(new AsyncCallback(onClientAccepted), null);
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

        public void Disconnect(ServerClient client)
        {
            //TODO verbeteren
            this.Clients.Remove(client);
            Broadcast(new Sentence()
            {
                Sender = "Server",
                Data = "Disconnect",
                MessageType = Sentence.Type.SERVER_MESSAGE
            }, Sentence.Type.SERVER_MESSAGE);
            Console.WriteLine("A client disconnected from the server");
            Console.WriteLine("IK ben hierin");
        }

        public void MessageToAI(Sentence message)
        {
            //Start a new thread to handle all the things of the AI
        }
    }
}
