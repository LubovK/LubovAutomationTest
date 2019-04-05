using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Twitter.Common
{
    /// <summary>
    /// Base class for setting/deleting configurationsbefore/after easch test
    /// </summary>
    [TestClass]
    public class BaseClass : MapFactories
    {
        /// <summary>
        /// Set before each test starts  by default
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            //Start ChromeDriver
            Driver.Initialize();
            
            //Navigate to url
            Navigate.GoToUrl();

            //Each test will have step1
            Console.WriteLine("Step1. Check that Twitter Home page is loaded");
            HomePage.IsPageLoaded();

        }
        /// <summary>
        /// Do a cleanup after each test by default
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            Driver.CloseAndQuit();
        }


    }
}
