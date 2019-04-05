using System;
using Twitter.Common;
using Twitter.Data;
using Twitter.Flow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twitter.Tests
{
    /// <summary>
    /// Test class for Login/logout tests
    /// </summary>
    [TestClass]
    public class Login : BaseClass
    {
        ///*Given* I have a twitter account
        ///*When* I login in using my correct username and password
        ///* Then* I see my twitter feed
        [TestMethod]
        public void SuccessfulLogin()
        {
            Console.WriteLine("Step2. Login to Twitter with valid credentials");
            LoginFlow.SuccessfulLogin(LoginData.GetValidCredentials());
        }

        ///*Given* I have a twitter account
        ///*When* I login in using my correct username but incorrect password
        ///* Then* I am not logged in
        [TestMethod]
        public void IncorrectLogin()
        {
            Console.WriteLine("Step2. Login to Twitter with invalid credentials");
            LoginFlow.PerformLogin(LoginData.GetInvalidCredentials());

            Console.WriteLine("Step3. Check that player don't see Feed -> player is not Logged in ");
            bool isLoaded = Feed.IsLoaded();
            Console.WriteLine($"Feed {(isLoaded ? "is" : "is NOT")} loaded");
            if (isLoaded)
                throw new Exception($"Feed is loaded -> player is Logged In, but shouldn't be");

            Console.WriteLine("Step4. Check that player is redirected to Login page");
            LoginPage.IsPageLoaded();

            Console.WriteLine("Step5. Check that player sees Alert message");
            LoginPage.IsAlertMessageLoaded();
            string alertText = LoginPage.GetMessageText();
            Console.WriteLine($"Alert message text: '{alertText}'");

        }

        ///*Given* I'm logged in to twitter
        ///*When* I log out
        ///*Then* the tweet appears on my profile ??? Not clear verification so I skipped it
        [TestMethod]
        public void Logout()
        {
            Console.WriteLine("Step2. Login to Twitter with valid credentials");
            LoginFlow.SuccessfulLogin(LoginData.GetValidCredentials());

            Console.WriteLine("Step3. Log out from Twitter");
            Settings.ClickSettings();
            Settings.IsDropdownOpened();
            Settings.ClickLogout();

            Console.WriteLine("Step4. Check that Twitter Home page is loaded");
            HomePage.IsPageLoaded();
        }

        #region Properties

        LoginFlow LoginFlow => _loginFlow ?? (_loginFlow = new LoginFlow());
        private LoginFlow _loginFlow;
        #endregion


    }
}
