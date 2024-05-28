namespace Framework 
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;

    public class BrowserFactory
    {
        private const string Firefox = "firefox";
        private const string Chrome = "chrome";
        private const string Edge = "edge";
        

        IWebDriver _iWebDriver;

        private IWebDriver IWebDriver
        {
            get => _iWebDriver; set => _iWebDriver = value; 
        }

        public IWebDriver InitializeBrowser(string browser)
        {
            switch (browser) 
            {

                case Firefox: 
                {
                    IWebDriver = new FirefoxDriver(new BrowserOptions().FirefoxDriverService, new BrowserOptions().FirefoxOptions);
                    break;
                }

                case Chrome:
                {
                    IWebDriver = new ChromeDriver(new BrowserOptions().ChromeOptions); 
                    break;
                }

                default: 
                {
                    throw new Exception($"Browser value specified - '{browser}' does not match the supported browsers in this project");
                }
            }
            IWebDriver.Manage().Window.Maximize(); 
            return IWebDriver;
        }

        public static void CloseBrowser(IWebDriver iWebDriver) => iWebDriver.Quit();
    }
}
