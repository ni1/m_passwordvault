using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordVaultNS;

namespace PasswordVaultTests
{
    [TestClass]
    public class PasswordVaultTests
    {
        [TestMethod]
        public void ValidUserName()
        {
            // arrange
            string username = "user";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "", "");

            // act
            bool actual = userAccount.ValidateUserName(username);

            // assert
            Assert.AreEqual(expected, actual, "Username matches");
        }

        [TestMethod]
        public void InvalidUserName()
        {
            // arrange
            string username = "invalid_user";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "", "");

            // act
            bool actual = userAccount.ValidateUserName(username);

            // assert
            Assert.AreNotEqual(expected, actual, "Username does not match");
        }

        [TestMethod]
        public void InvalidWhiteSpaceUserName()
        {
            // arrange
            string username = "     ";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "", "");

            // act
            bool actual = userAccount.ValidateComplexUserName(username);

            // assert
            Assert.AreNotEqual(expected, actual, "Username contains all whitespace");
        }

        [TestMethod]
        public void ValidCaseSensitiveUserName()
        {
            // arrange
            string username = "UsEr";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("USER", "PASS", "", "");

            // act
            bool actual = userAccount.ValidateUserName(username.ToUpper());

            // assert
            Assert.AreEqual(expected, actual, "Username matches and is not case sensitive");
        }

        [TestMethod]
        public void FailedCaseSensitiveUserName()
        {
            // arrange
            string username = "UsEr";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("USER", "PASS", "", "");

            // act
            bool actual = userAccount.ValidateUserName(username);

            // assert
            Assert.AreNotEqual(expected, actual, "Username does not match due to case sensitve");
        }

        [TestMethod]
        public void ValidPassword()
        {
            // arrange
            string password = "pass";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "", "");

            // act
            bool actual = userAccount.ValidatePassword(password);

            // assert
            Assert.AreEqual(expected, actual, "Password is correct");
        }

        [TestMethod]
        public void FailedCaseSensitivePassword()
        {
            // arrange
            string password = "PASS";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "", "");

            // act
            bool actual = userAccount.ValidatePassword(password);

            // assert
            Assert.AreNotEqual(expected, actual, "Password is not correct due to case sensitive");
        }

        [TestMethod]
        public void FailedLengthValidPassword()
        {
            // arrange
            string password = "pass     ";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "", "");

            // act
            bool actual = userAccount.ValidatePassword(password);

            // assert
            Assert.AreNotEqual(expected, actual, "Password is not correct due to whitespace");
        }

        [TestMethod]
        public void ValidComplexityPassword()
        {
            // arrange
            string password = "Passw0rd1";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "Passw0rd1", "", "");

            // act
            bool actual = userAccount.ValidateComplexPassword(password);

            // assert
            Assert.AreEqual(expected, actual, "Password is not complexe enough");
        }

        [TestMethod]
        public void FailedLengthComplexityPassword()
        {
            // arrange
            string password = "Pass";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "Pass", "", "");

            // act
            bool actual = userAccount.ValidateComplexPassword(password);

            // assert
            Assert.AreNotEqual(expected, actual, "Password need to be at least 8 characters");

        }

        [TestMethod]
        public void FailedUpperCaseComplexityPassword()
        {
            // arrange
            string password = "password1";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "password1", "", "");

            // act
            bool actual = userAccount.ValidateComplexPassword(password);

            // assert
            Assert.AreNotEqual(expected, actual, "Password need at least one upper case");
        }


        [TestMethod]
        public void FailedNumberComplexityPassword()
        {
            // arrange
            string password = "Password";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "Password", "", "");

            // act
            bool actual = userAccount.ValidateComplexPassword(password);

            // assert
            Assert.AreNotEqual(expected, actual, "Password need at least one number");
        }


        [TestMethod]
        public void ValidUserAndPassword()
        {
            // arrange
            string username = "user";
            string password = "password";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "password", "", "");

            // act
            bool actual = userAccount.ValidateUserNameAndPassword(username, password);

            // assert
            Assert.AreEqual(expected, actual, "Username and Password is correct");
        }

        [TestMethod]
        public void InvalidUserAndPassword()
        {
            // arrange
            string username = "user";
            string password = "bad_password";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "password", "", "");

            // act
            bool actual = userAccount.ValidateUserNameAndPassword(username, password);

            // assert
            Assert.AreNotEqual(expected, actual, "Username or Password is incorrect");
        }


        [TestMethod]
        public void ValidEmailAddress()
        {
            // arrange
            string email = "wei@sacredheart.edu";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "wei@sacredheart.edu", "");

            // act
            bool actual = userAccount.ValidateEmailAddress(email);

            // assert
            Assert.AreEqual(expected, actual, "Password matches criteria for pattern match");
        }

        [TestMethod]
        public void FailedRequirementEmail1()
        {
            // arrange
            string email = "asdjkhkjsa8d69";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "asdjkhkjsa8d69", "");

            // act
            bool actual = userAccount.ValidateEmailAddress(email);

            // assert
            Assert.AreNotEqual(expected, actual, "Password do not match criteria for pattern match");
        }

        [TestMethod]
        public void FailedRequirementEmail2()
        {
            // arrange
            string email = "wei[at]sacredheart[dot]edu";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "wei[at]sacredheart[dot]edu", "");

            // act
            bool actual = userAccount.ValidateEmailAddress(email);

            // assert
            Assert.AreNotEqual(expected, actual, "Password do not match criteria for pattern match");
        }

        [TestMethod]
        public void FailedRequirementEmail3()
        {
            // arrange
            string email = "wei@sacredheart[dot]edu";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "wei@sacredheart[dot]edu", "");

            // act
            bool actual = userAccount.ValidateEmailAddress(email);

            // assert
            Assert.AreNotEqual(expected, actual, "Password do not match criteria for pattern match");
        }

        [TestMethod]
        public void FailedRequirementEmail4()
        {
            // arrange
            string email = "wei[at]sacredheart.edu";      //includes white space
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "wei[at]sacredheart.edu", "");

            // act
            bool actual = userAccount.ValidateEmailAddress(email);

            // assert
            Assert.AreNotEqual(expected, actual, "Password do not match criteria for pattern match");
        }

       
        [TestMethod]
        public void ValidPasswordHint()
        {
            // arrange
            string passwordHint = "123";     
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "email", "123");

            // act
            bool actual = userAccount.ValidatePasswordHint(passwordHint);

            // assert
            Assert.AreEqual(expected, actual, "Password Hint is working");
        }


        [TestMethod]
        public void InvalidEmptyPasswordHint()
        {
            // arrange
            string passwordHint = "";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "email", "");

            // act
            bool actual = userAccount.ValidateComplexPasswordHint(passwordHint);

            // assert
            Assert.AreNotEqual(expected, actual, "Password hint did not match");
        }

        [TestMethod]
        public void InvalidWhiteSpacePasswordHint()
        {
            // arrange
            string passwordHint = "   ";
            bool expected = true;
            PasswordVault userAccount = new PasswordVault("user", "pass", "email", "   ");

            // act
            bool actual = userAccount.ValidateComplexPasswordHint(passwordHint);

            // assert
            Assert.AreNotEqual(expected, actual, "Password hint has white space");
        }
    }
}
