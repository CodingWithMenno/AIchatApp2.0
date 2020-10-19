using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AI_ChatApp2._0
{
    class Client
    {
        public TCPHandler DataHandler;
        private string Name;
        private TcpClient Client_;
        private NetworkStream Stream;
        public bool IsConnected => this.Client_ != null && this.Client_.Connected;
        private string IPAddress;
        private int Port;



        public Client(string name, string ipAddress)
        {
            this.Name = name;

            //Checks if the ipAddress is valid, if not throws exception
            if (!System.Net.IPAddress.TryParse(ipAddress, out IPAddress temp)) new ArgumentException($"IP address is invalid", nameof(ipAddress));

            this.IPAddress = ipAddress;
            this.Port = 42069;
        }

        /**
         * Method for setup of the TCPClient, if the client is connected returns true, else returns false
         */
        public bool Connect()
        {
            bool result = false;

            try
            {
                if (!this.IsConnected)
                {
                    this.Client_ = new TcpClient();
                    this.DataHandler = new TCPHandler(this.Name, this.Client_, this.IPAddress, this.Port);
                }

                result = this.IsConnected;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Client => {ex.GetType().Name}: {ex.Message}");
                result = false;
            }

            return result;
        }

        public void SendData(string message)
        {
            if (this.IsConnected)
                this.DataHandler.SendData(message);
        }

        public void Disconnect()
        {
            
        }
    }
}
