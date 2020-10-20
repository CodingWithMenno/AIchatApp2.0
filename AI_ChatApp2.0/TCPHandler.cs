using Newtonsoft.Json;
using SharedClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AI_ChatApp2._0
{
    public delegate void ChatCallback(string message);
    public delegate void ClientListCallback(string clientList);
    public delegate void MessageBoxCallback(string message, MessageBoxButtons buttons);
    class TCPHandler
    {
        string Name;
        private TcpClient Client;
        private NetworkStream Stream;
        private string IPAddress;
        private int Port;

        private byte[] Buffer = new byte[4];

        public event ChatCallback OnChatReceived;
        public event ClientListCallback OnClientListReceived;
        public event MessageBoxCallback OnMessageBoxShow;

        public TCPHandler(string name, TcpClient client, string iPAddress, int port)
        {
            this.Name = name;
            this.Client = client;
            this.IPAddress = iPAddress;
            this.Port = port;

            this.Client.BeginConnect(this.IPAddress, this.Port, new AsyncCallback(Connect), null);
        }

        public void Connect(IAsyncResult ar)
        {
            try
            {
                this.Client.EndConnect(ar);

                this.Stream = this.Client.GetStream();

                SendData(this.Name);

                this.Stream.BeginRead(this.Buffer, 0, this.Buffer.Length, new AsyncCallback(OnIntRead), null);
            } catch (Exception)
            {
                OnMessageBoxShow?.Invoke("The server is not online, press \"OK\" to close the window.", MessageBoxButtons.OK);
            }
        }
        public void SendData(string message)
        {
            Tuple<int, byte[]> tuple;
            //Converts message to Json
            if (message.StartsWith("!"))
            {
                tuple = EncryptData(this.Name, message, Sentence.Type.BOT1_REQUEST);
            }
            else if (message == "$DISCONNECT")
            {
                tuple = EncryptData(this.Name, message, Sentence.Type.DISCONNECT);
            }
            else if (message == Name)
            {
                tuple = EncryptData(this.Name, message, Sentence.Type.USERSMESSAGE);
            }
            else
            {
                tuple = EncryptData(this.Name, message, Sentence.Type.CHAT_MESSAGE);
            }


            //Sends length of message to client
            Stream.Write(BitConverter.GetBytes(tuple.Item1), 0, BitConverter.GetBytes(tuple.Item1).Length);

            //Sends message to client
            Stream.Write(tuple.Item2, 0, tuple.Item2.Length);
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
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);

                Disconnect();
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
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                //TODO disconnct stream and clients
                Disconnect();
                return;
            }
        }

        public void Disconnect()
        {
            SendData("$DISCONNECT");
            this.Client.Close();
        }

        private Tuple<int, byte[]> EncryptData(string sender_, string message_, Sentence.Type type_)
        {
            Sentence sentence = new Sentence()
            {
                Sender = sender_,
                Data = message_,
                MessageType = type_
            };

            byte[] data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(sentence));
            return Tuple.Create(data.Length, data);
        }

        private Sentence DecryptData(string message)
        {
            return JsonConvert.DeserializeObject<Sentence>(message);
        }

        private void handleData(Sentence data)
        {
            try
            {
                switch (data.getMessageType())
                {
                    case Sentence.Type.SERVER_MESSAGE:
                        {
                            OnChatReceived?.Invoke($"{data.getSender()}: {data.getData()}\r\n");
                            break;
                        }
                    case Sentence.Type.USERSMESSAGE:
                        {
                            OnClientListReceived?.Invoke(data.Data);
                            Console.WriteLine("All clients: ");     
                            Console.WriteLine(data.Data);
                            break;
                        }
                    case Sentence.Type.DISCONNECT_REQUEST:
                        {
                            SendData("$DISCONNECT");
                            OnMessageBoxShow?.Invoke($"You got kicked!\nReason: {data.getData()}", MessageBoxButtons.OK);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
