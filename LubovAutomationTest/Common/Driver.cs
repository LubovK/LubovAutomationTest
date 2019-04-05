using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Twitter.Common
{
    /// <summary>
    /// Incapsuate Selenium Driver methods
    /// </summary>
    public class Driver
    {
        private static IWebDriver WebDriver { get; set; }
        private static TimeSpan Default = TimeSpan.FromSeconds(15);

        /// <summary>
        /// 1. Remove the line in browser 'Chrom is being controlled by automated test software'
        /// 2. Start Chrome driver
        /// 3. Maximaze browser window
        /// 4. Set Implicit Wait
        /// </summary>
        public static void Initialize()
        {
            //remove the line in browser 'Chrom is being controlled by automated test software'
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");

            //initialize Chrome driver
            WebDriver = new ChromeDriver(chromeOptions);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = Default;
        }

        /// <summary>
        /// 1. Close browser
        /// 2. Quit from browser
        /// </summary>
        public static void CloseAndQuit()
        {
            Console.WriteLine("Close browser");
            try
            {
                WebDriver.Close();
                WebDriver.Quit();
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to close browser. Error: {ex}");
            }

        }

        /// <summary>
        /// Type url into browser command line
        /// </summary>
        /// <param name="url"></param>
        public static void Navigate(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
    
        /// <summary>
        /// Check that element is enabled on a page
        /// </summary>
        /// <param name="by"></param>
        /// <param name="elementName"></param>
        /// <param name="secondsToWait"></param>
        public void CheckElementIsLoaded(By by, string elementName)
        {
            bool isLoaded = IsElementLoaded(by);
            Console.WriteLine($"{elementName} '{(isLoaded ? "is" : "is NOT")}' loaded");
            if (!isLoaded)
                throw new Exception($"{elementName} is NOT loaded");
        }

        /// <summary>
        /// Is an element is loaded? 
        /// Return bool
        /// </summary>
        /// <param name="by"></param>
        /// <param name="secondsToWait"></param>
        /// <returns></returns>
        public bool IsElementLoaded(By by, int secondsToWait = 1)
        {
            //set a new 'implicit wait' for this method instead Default for the whole project
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
            try
            {
                return FindElement(by).Enabled;
            }
            catch
            {
                return false;
            }
            finally
            {
                //return 'implicit wait' to a Default value
                WebDriver.Manage().Timeouts().ImplicitWait = Default;
            }
        }

        /// <summary>
        /// Insert a Value to a text area
        /// </summary>
        /// <param name="by"></param>
        /// <param name="value"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static void InsertValue(By by, string value, string elementName)
        {
            Console.WriteLine($"Insert '{elementName}' = '{value}'");
            try
            {
                FindElement(by).SendKeys(value);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to insert '{elementName}' = '{value}' by locator: '{by}'. Error message: {ex}");
            }
        }

        /// <summary>
        /// Click on Element By (xpath, Name, Id, ...)
        /// </summary>
        /// <param name="by"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static void Click(By by, string elementName)
        {
            Console.WriteLine($"Click on '{elementName}'");
            try
            {
                FindElement(by).Click();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to click on '{elementName}' by locator: '{by}'. Error message: {ex}");
            }
        }

        /// <summary>
        /// Get Element text By (xpath, Name, Id, ...)
        /// </summary>
        /// <param name="by"></param>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public static string GetText(By by, string elementName)
        {
            Console.WriteLine($"Get '{elementName}' text");
            try
            {
                return FindElement(by).Text;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get '{elementName}' text by locator: '{by}'. Error message: {ex}");
            }
        }

        /// <summary>
        /// Find Element By (xpath, Name, Id, ...)
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        private static IWebElement FindElement(By by)
        {
            try
            {
                return WebDriver.FindElement(by);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to find element by: '{by}'. Error message: {ex}");
            }
        }


    }
}
