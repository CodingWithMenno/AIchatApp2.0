using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_ChatApp2._0
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonToGUI_Click(object sender, EventArgs e)
        {
            LoginToGUI();
        }

        private void LoginToGUI()
        {
            if (textBoxUserName.Text != "")
            {
                if (textBoxIPAddress.Text != "")
                {
                    IPAddress ip;
                    bool ValidateIP = IPAddress.TryParse(textBoxIPAddress.Text, out ip);
                    if (ValidateIP)
                    {
                        GUI gui = new GUI(textBoxUserName.Text, textBoxIPAddress.Text);
                        gui.Show();
                        this.Hide();
                        Form.ActiveForm.Text = $"{textBoxUserName.Text}'s Client";
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("The given IPAddress was not a valid IPAddress! ", "Invalid IPAddress", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            textBoxIPAddress.Text = "";
                        }
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("You forget to put an username and/or IPAddress!", "Empty textBoxes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                    }
                }

            }
            else
            {
                DialogResult res = MessageBox.Show("You forget to put an username and/or IPAddress!", "Empty textBoxes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                }
            }
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                LoginToGUI();
            }
        }
    }
}
