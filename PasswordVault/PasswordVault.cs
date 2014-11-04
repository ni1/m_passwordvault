using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PasswordVaultNS
{
    public class PasswordVault
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private string _username;
        private string _password;
        private string _emailAddress;
        private string _passwordHint;
        private bool isEnabled = false;

        //private string[,] passwordDB = new string[,] {
        //                                            {"wei", "pass", "email", "hint"},
        //                                            {"tom", "pass", "email", "hint"}
        //                                        };
        //passwordDB[0, 0] = "wei";
        //passwordDB[0, 1] = "2";
        //passwordDB[0, 2] = "3";
        //passwordDB[0, 3] = "4";
        //passwordDB[1, 0] = "tom";
        //passwordDB[2, 1] = "2";
        //passwordDB[3, 2] = "3";
        //passwordDB[4, 3] = "4";
        //private int count = 2;

        public PasswordVault()
        {
        }

        public PasswordVault(string username, string password, string emailAddress, string passwordHint)
        {
            _username = username;
            _password = password;
            _emailAddress = emailAddress;
            _passwordHint = passwordHint;
        }


        public bool ValidateUserName(string username)
        {
            bool isValidUser = false;
            
            if (_username == username)
            {
                isValidUser = true;
            }

            return isValidUser;
        }
        
        public bool ValidateComplexUserName(string username)
        {
            bool isAllowed = false;
            bool isWhiteSpace = true;

            isWhiteSpace = String.IsNullOrWhiteSpace(username);
            if (isWhiteSpace == false && username.Length > 2)
            {
                isAllowed = true;
            }

            return isAllowed;
        }

        public bool ValidatePassword(string password)
        {
            bool isAllowed = false;
            
            if (_password == password)
            {
                isAllowed = true;
            }

            return isAllowed;

        }

        public bool ValidateComplexPassword(string password)
        {
            bool isAllowed = false;

            // test for password complexity; at least 1 digit, 1 uppercase char, and 1 lowercase char
            if (password.Length >= 8 &&
                password.Count(c => char.IsDigit(c)) >= 1 &&
                password.Count(c => char.IsUpper(c)) >= 1 &&
                password.Count(c => char.IsLower(c)) >= 1)
            {
                isAllowed = true;
            }

            return isAllowed;
        }


        public bool ValidateEmailAddress(string email)
        {
            //source: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx/
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public bool ValidateUserNameAndPassword(string username, string password)
        {
            bool isAllowedAccess = false;

            if (_username == username && _password == password)
            {
                isAllowedAccess = true;
            }
            
            return isAllowedAccess;
            
        }

        public bool ValidatePasswordHint(string passwordHint)
        {
            bool isAllowed = false;

            if (_passwordHint == passwordHint)
            {
                isAllowed = true;
            }

            return isAllowed;
        }

        public bool ValidateComplexPasswordHint(string passwordHint)
        {
            bool isAllowed = false;
            bool isWhiteSpace = true;
            isWhiteSpace = String.IsNullOrWhiteSpace(passwordHint);

            if (isWhiteSpace == false && passwordHint.Length > 0)
            {
                isAllowed = true;
            }

            return isAllowed;
        }


        public void AddNewUser(string username, string password, string email, string passwordHint)
        {
            //passwordDB[count, 0] = username;
            //passwordDB[count, 1] = password;
            //passwordDB[count, 2] = email;
            //passwordDB[count, 3] = passwordHint;
            //count++;

        }

        public void NewAccount()
        {
            
        }

        public void ExistingAccount()
        {
            
        }


        [STAThread]
        public static void Main()
        {
            /// Running the Form1 application
            /// 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSignIn());
            

            PasswordVault pv = new PasswordVault();
            //pv.passwordDB[0, 0] = "wei";
            //pv.passwordDB[0, 1] = "2";
            //pv.passwordDB[0, 2] = "3";
            //pv.passwordDB[0, 3] = "4";
            //pv.passwordDB[1, 0] = "tom";
            //pv.passwordDB[2, 1] = "2";
            //pv.passwordDB[3, 2] = "3";
            //pv.passwordDB[4, 3] = "4";

            //pv.CheckLogin("user", "pass");
            
        }
    }
}
