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
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmailHint_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            PasswordVault pv = new PasswordVault();
            if (pv.ValidateEmailAddress(email))
            {
                MessageBox.Show("Your password hint has been sent.", "Notification");
                txtEmail.Text = "";
            }
            else
            {
                MessageBox.Show("The email entered is invalid.", "Error");
            }
        }
    }
}
