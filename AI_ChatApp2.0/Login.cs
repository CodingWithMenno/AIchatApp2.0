using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                GUI gui = new GUI(textBoxUserName.Text);
                gui.Show();
                this.Hide();
                Form.ActiveForm.Text = $"{textBoxUserName.Text}'s Client";
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
