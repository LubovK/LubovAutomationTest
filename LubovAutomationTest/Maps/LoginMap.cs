using Twitter.Common;
using OpenQA.Selenium;

namespace Twitter.Maps
{
    public class LoginMap : Driver
    {
        private readonly By alertMessageElement = By.ClassName("alert-messages");
        private readonly By loginPageElement = By.ClassName("signin-wrapper");

        /// <summary>
        /// Chack that Login page is shown
        /// </summary>
        public void IsPageLoaded()
        {
            CheckElementIsLoaded(alertMessageElement, "Login page");
        } 

        /// <summary>
        /// Chack that Alert message is shown
        /// </summary>
        public void IsAlertMessageLoaded()
        {
            CheckElementIsLoaded(alertMessageElement, "Alert message");
        }

        /// <summary>
        /// Get alert message text
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            return GetText(alertMessageElement, "Alert message");
        }
    }
}
