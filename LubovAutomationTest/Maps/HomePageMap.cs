using Twitter.Common;
using OpenQA.Selenium;

namespace Twitter.Maps
{
    /// <summary>
    /// Home page elements and methods
    /// </summary>
    public class HomePageMap : Driver
    {
        private readonly By pageElement = By.ClassName("StaticLoggedOutHomePage");
        private readonly By loginButtonElement = By.XPath("//input[@type = 'submit']");
        private readonly By usernameField = By.XPath("//*[@autocomplete = 'username']");
        private readonly By passwordField = By.XPath("//*[@autocomplete = 'current-password']");



        public void IsPageLoaded()
        {
            CheckElementIsLoaded(pageElement, "Login Twitter page");
        }

        /// <summary>
        /// click on 'Login' button
        /// </summary>
        public void ClickLoginButton()
        {
            Click(loginButtonElement, "Login button");
        }

        /// <summary>
        /// Insert value into Username field
        /// </summary>
        /// <param name="text"></param>
        public void InsertUsername(string text)
        {
            InsertValue(usernameField, text, "Username");
        }

        /// <summary>
        /// Insert value into Password field
        /// </summary>
        /// <param name="text"></param>
        public void InsertPassword(string text)
        {
            InsertValue(passwordField, text, "Password");
        }



    }
}
