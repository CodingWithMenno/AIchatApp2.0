using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AI_ChatApp2._0
{
    public partial class GUI : Form
    {

        private Client client;

        public GUI(string UserName)
        {
            InitializeComponent();
            InitClient(UserName);

            //TODO ASk for username


        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //Send data to server
            SendChat();
        }

        private void SendChat()
        {
            if (textBoxSendChat.Text != "")
            {
                this.client.SendData(textBoxSendChat.Text);
                textBoxSendChat.Text = "";
            }
        }

        private void InitClient(string UserName)
        {
            this.client = new Client(UserName, "localhost");
            client.Connect();
            //if (client.Connect())
            //{
            //    Code for startup of program
            //}
            this.client.DataHandler.OnChatReceived += Client_OnChatReceived;
        }

        private void Client_OnChatReceived(string message)
        {
            this.Invoke((Action)delegate
            {
                textBoxMessages.Text += message;
                textBoxMessages.SelectionStart = textBoxMessages.Text.Length;
                textBoxMessages.ScrollToCaret();
            });
        }

        private void TextBoxSendChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendChat();
            }
        }
    }
}
