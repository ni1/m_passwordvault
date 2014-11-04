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
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            string passwordHint = txtPasswordHint.Text;
            bool answer1, answer2, answer3, answer4 = false;
            PasswordVault pv = new PasswordVault();

            answer1 = pv.ValidateComplexUserName(username);
            answer2 = pv.ValidateComplexPassword(password);
            answer3 = pv.ValidateEmailAddress(email);
            answer4 = pv.ValidateComplexPasswordHint(passwordHint);


            if (answer1 && answer2 && answer3 && answer4)
            {
                MessageBox.Show("Your account has been created.", "Notifcation");
            }
            else
            {
                MessageBox.Show("There is a error with the information you provided.", "Error");
            }
            
        }
    }
}
