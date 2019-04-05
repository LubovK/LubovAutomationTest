using Twitter.Common;
using OpenQA.Selenium;

namespace Twitter.Maps
{
    /// <summary>
    /// Customer Settings page
    /// </summary>
    public class SettingsMap : Driver
    {
        private readonly By settingsButtonElement = By.XPath("//*[@id='user-dropdown']/a[@href='/settings']");
        private readonly By settingsDropdownElement = By.XPath("//*[@aria-labelledby='user-dropdown-toggle']");
        private readonly By logoutElement = By.Id("signout-button");


        /// <summary>
        /// click on 'Settings' button
        /// </summary>
        public void ClickSettings()
        {
            Click(settingsButtonElement, "Settings button from Header");
        }

        /// <summary>
        /// Chack that Dropdown window is opened
        /// </summary>
        public void IsDropdownOpened()
        {
            CheckElementIsLoaded(settingsDropdownElement, "Settings dropdown");
        }

        /// <summary>
        /// click on 'Logout' button
        /// </summary>
        public void ClickLogout()
        {
            Click(logoutElement, "Logout");
        }
    }
}
