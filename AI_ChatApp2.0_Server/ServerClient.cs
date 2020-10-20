using Newtonsoft.Json;
using SharedClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace AI_ChatApp2._0_Server
{
    public class ServerClient
    {
        private Server Server;
        private TcpClient TCPClient;
        private NetworkStream Stream;
        private byte[] Buffer = new byte[4];
        public string Name;

        public ServerClient(Server server, TcpClient tcpClient)
        {
            this.Server = server;
            this.TCPClient = tcpClient;

            this.Stream = this.TCPClient.GetStream();
            this.Stream.BeginRead(this.Buffer, 0, this.Buffer.Length, new AsyncCallback(OnIntRead), null);
        }

        public void OnIntRead(IAsyncResult ar) //Nog implementeren met ons protocol
        {
            try
            {
                int receivedBytes = this.Stream.EndRead(ar);
                int receivedLength = BitConverter.ToInt32(this.Buffer, 0);

                this.Buffer = new byte[receivedLength];
                this.Stream.BeginRead(this.Buffer, 0, this.Buffer.Length, new AsyncCallback(OnMessageRead), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public void OnMessageRead(IAsyncResult ar) //Nog implementeren met ons protocol
        {
            try
            {
                int receivedBytes = this.Stream.EndRead(ar);
                string receivedText = Encoding.ASCII.GetString(this.Buffer, 0, receivedBytes);


                this.Buffer = new byte[4];
                this.Stream.BeginRead(this.Buffer, 0, this.Buffer.Length, new AsyncCallback(OnIntRead), null);

                handleData(DecryptData(receivedText));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public void SendMessage(Sentence message)
        {
            Console.WriteLine(message.toString());
            //Converts message to Json
            Tuple<int, byte[]> tuple = EncryptData(message);

            //Sends length of message to client
            Stream.Write(BitConverter.GetBytes(tuple.Item1), 0, BitConverter.GetBytes(tuple.Item1).Length);

            //Sends message to client
            Stream.Write(tuple.Item2, 0, tuple.Item2.Length);
            Console.WriteLine("SENDING DONE");
        }

        private void Disconnect()
        {
            Console.WriteLine("DISCONNECT");
            //TODO disconnect stream and clients
            this.TCPClient.Close();
            this.Server.Disconnect(this);
        }

        private Tuple<int, byte[]> EncryptData(Sentence message)
        {
            byte[] data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(message));
            return Tuple.Create(data.Length, data);
        }

        private Sentence DecryptData(string message)
        {
            return JsonConvert.DeserializeObject<Sentence>(message);
        }

        private void handleData(Sentence data)
        {
            Console.WriteLine(data.toString());

            switch (data.getMessageType())
            {
                case Sentence.Type.BOT1_REQUEST:
                    {
                        this.Server.SendToUser(new Sentence()
                        {
                            Sender = data.getSender(),
                            Data = data.getData(),
                            MessageType = Sentence.Type.SERVER_MESSAGE
                            
                        });
                        this.Server.BotHandler.HandleMessage(data);
                        break;
                    }
                case Sentence.Type.CHAT_MESSAGE:
                    {
                        Console.WriteLine("Chat message received");
                        if (this.Server.BotHandler.CheckInputBL(data))
                        {
                            this.Server.Broadcast(data, Sentence.Type.SERVER_MESSAGE);
                        }
                        else
                        {
                            SendMessage(new Sentence()
                            {
                                Sender = "Server",
                                Data = "$DISCONNECT",
                                MessageType = Sentence.Type.DISCONNECT_REQUEST
                            });
                        }
                        break;
                    }
                case Sentence.Type.DISCONNECT:
                    {
                        Disconnect();
                        break;
                    }
                case Sentence.Type.USERSMESSAGE:
                    {
                        this.Name = data.getData();
                        this.Server.SendClientList();
                        this.Server.SendServerMessage($"<{data.getData()}> connected to the server.");
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
