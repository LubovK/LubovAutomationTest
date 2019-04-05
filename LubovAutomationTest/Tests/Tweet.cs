using System;
using Twitter.Common;
using Twitter.Data;
using Twitter.Flow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Twitter.Tests
{
    /// <summary>
    /// Test class for tweets tests
    /// </summary>
    [TestClass]
    public class Tweet : BaseClass
    {
        ///*Given* I'm logged in to twitter
        ///*When* posting a tweet
        ///* Then* the tweet appears on my profile
        [TestMethod]
        public void SendTweet()
        {
            string tweet = "New tweet " + DateTime.Now.ToString("MMddyyyyhhmmss");

            Console.WriteLine("Step2. Login to Twitter with valid credentials");
            LoginFlow.SuccessfulLogin(LoginData.GetValidCredentials());

            Console.WriteLine("Step3. Posting a tweet");
            Feed.TypeNewTweet(tweet);
            Feed.SendTweet();

            Console.WriteLine("Step4. Check that the tweet appears on my profile");
            bool isTweetAppeared = Feed.IsTweetAppeared(tweet);
            Console.WriteLine($"Tweet '{tweet}' {(isTweetAppeared ? "appeared" : "did NOT appeared")}");
            if (!isTweetAppeared)
                throw new Exception($"Tweet '{tweet}' did NOT appeared in Feed");

        }

        #region Properties
        LoginFlow LoginFlow => _loginFlow ?? (_loginFlow = new LoginFlow());
        private LoginFlow _loginFlow;
        #endregion
    }
}
