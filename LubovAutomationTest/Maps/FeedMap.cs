using Twitter.Common;
using OpenQA.Selenium;

namespace Twitter.Maps
{
    public class FeedMap : Driver
    {
        private readonly By feedElement = By.ClassName("stream");
        private readonly By tweetFieldElement = By.Id("tweet-box-home-timeline");
        private readonly By tweetButtonElement =
            By.XPath("//*[@class='tweet-action EdgeButton EdgeButton--primary js-tweet-btn']");

        /// <summary>
        /// Chack that Feed is shown
        /// </summary>
        public bool IsLoaded()
        {
            return IsElementLoaded(feedElement);
        }


        /// <summary>
        /// Type New Tweet
        /// </summary>
        /// <param name="text"></param>
        public void TypeNewTweet(string text)
        {
            InsertValue(tweetFieldElement, text, "New Tweet");
        }

        /// <summary>
        /// click on 'Tweet' button
        /// </summary>
        public void SendTweet()
        {
            Click(tweetButtonElement, "Tweet button");
        }

        /// <summary>
        /// Check that a specific tweet is shown
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsTweetAppeared(string text)
        {
            return IsElementLoaded(By.XPath($"//*[@data-item-type='tweet']//*[contains(text(), '{text}')]"), 3);
        }
    }
}
