using System;
using Twitter.Common;
using Twitter.Data;

namespace Twitter.Flow
{
    /// <summary>
    /// Login flow
    /// </summary>
    public class LoginFlow : MapFactories
    {
        ///Login to Twitter with valid credentials
        ///Check that twitter feed is present
        public void SuccessfulLogin(LoginData loginData)
        {
            // 1. Insert Username
            // 2. Insert Password
            // 3. Click Login Button
            PerformLogin(loginData);

            //4. Check that twitter feed is present - player is logged in
            Console.WriteLine("Check that twitter feed is present");
            bool isLoaded = Feed.IsLoaded();
            Console.WriteLine($"Feed {(isLoaded ? "is" : "is NOT")} loaded");
            if (!isLoaded)
                throw new Exception($"Feed is NOT loaded");
        }

        /// <summary>
        /// Perform login:
        /// 1. Insert Username
        /// 2. Insert Password
        /// 3. Click Login Button
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void PerformLogin(LoginData loginData)
        {
            HomePage.InsertUsername(loginData.Username);
            HomePage.InsertPassword(loginData.Password);
            HomePage.ClickLoginButton();
        }
    }
}
