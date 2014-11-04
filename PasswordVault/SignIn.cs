using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordVaultNS
{
    public partial class frmSignIn : Form
    {
        private string username;
        private string password;
        private int numAttempts = 0;

        public List<string> Roles { get; set; }
        public bool isEnabled { get; set; }

        public frmSignIn()
        {
            InitializeComponent();
        }

        
        
        // Default Constructor
        public void User()
        {
            username = string.Empty;
            password = string.Empty;

            Roles = new List<string>();
            isEnabled = false;
        }

        public void clearText()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnCreateAnAccount_Click(object sender, EventArgs e)
        {
            frmCreateAccount frmCA = new frmCreateAccount();
            frmCA.ShowDialog();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string _username = "";
            string _password = "";

            _username = txtUsername.Text;
            _password = txtPassword.Text;

            if (_username == "user" && _password == "pass")
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The username or password is incorrect.", "Error");
                clearText();
                numAttempts++;
            }
            clearText();
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            frmForgotPassword frmPF = new frmForgotPassword();
            frmPF.ShowDialog();
        }
    }
}
