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
            if (textBoxSendChat.Text != "" && textBoxSendChat.Text != "$DISCONNECT" && textBoxUsersBox.Text != "")
            {
                this.client.SendData(textBoxSendChat.Text);
                textBoxSendChat.Text = "";
            }
        }

        private void InitClient(string UserName)
        {
            this.client = new Client(UserName, "localhost");
            client.Connect();
            this.client.DataHandler.OnChatReceived += Client_OnChatReceived;
            this.client.DataHandler.OnClientListReceived += DataHandler_OnClientListReceived;
            this.client.DataHandler.OnMessageBoxShow += OnMessageBox_Show;
        }

        private void DataHandler_OnClientListReceived(string clientList)
        {
            this.Invoke((Action)delegate
            {
                string[] clients = clientList.Split("\n");

                textBoxUsersBox.Text = "";
                foreach (string client in clients)
                {
                    textBoxUsersBox.Text += client + "\r\n";
                }
            });
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

        public void OnMessageBox_Show(string message, MessageBoxButtons buttons)
        {
            DialogResult res = MessageBox.Show(message, "EXIT", buttons, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.client.DataHandler.Disconnect();
            this.client.DataHandler.OnChatReceived -= Client_OnChatReceived;
            this.client.DataHandler.OnClientListReceived -= DataHandler_OnClientListReceived;
            this.client.DataHandler.OnMessageBoxShow -= OnMessageBox_Show;
        }
    }
}
