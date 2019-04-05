using System;

namespace Twitter.Common
{
    /// <summary>
    /// Navigate to Twitter by URL
    /// </summary>
    static class Navigate
    {
        private static string Url = "https://twitter.com/";

        /// <summary>
        /// Navigate to Twitter
        /// </summary>
        public static void GoToUrl()
        {
            try
            {
                Driver.Navigate(Url);
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to navigate to {Url}. Error: {ex}");
            }
        }
    }
}
