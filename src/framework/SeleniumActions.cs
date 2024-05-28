namespace Framework
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using NUnit.Framework;
    using System;
    using Utilities;

    public class SeleniumActions
    {
        readonly IWebDriver _iWebDriver;
        WebDriverWait _webDriverWait;
        Actions _actions;
        
        private int ExplicitTimeOutInSeconds;
        private int ImplicitTimeOutInSeconds;
        private int PageLoadTimeOutInSeconds;

        public SeleniumActions(IWebDriver iWebDriver)
        {
            _iWebDriver = iWebDriver;
            ExplicitTimeOutInSeconds = int.Parse(new ReadProperties("TimeOuts", "ExplicitTimeOutInSeconds").Value);
            ImplicitTimeOutInSeconds = int.Parse(new ReadProperties("TimeOuts", "ImplicitTimeOutInSeconds").Value);
            PageLoadTimeOutInSeconds = int.Parse(new ReadProperties("TimeOuts", "PageLoadTimeOutInSeconds").Value);
            iWebDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(PageLoadTimeOutInSeconds));
            iWebDriver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(ImplicitTimeOutInSeconds));
            
        }

        public SeleniumActions OpenUrl(String url)
        {
            try
            {
                _iWebDriver.Navigate().GoToUrl(url);
            }
            catch (WebDriverException webDriverException)
            {
                Fail(webDriverException.Message);
            }
            return this;
        }

        public SeleniumActions HoverOnElement(LocatorObject locatorObject)
        {
            try
            {
                WaitForElementToBeDisplayed(locatorObject);
                _actions = new Actions(_iWebDriver);
                _actions.MoveToElement(_iWebDriver.FindElement(locatorObject.LocatorValue)).Perform();
            }
            catch (WebDriverException webDriverException)
            {
                Fail(webDriverException.Message);
            }
            return this;
        }

        public SeleniumActions HoverOnElementAndEnterText(LocatorObject locatorObject, String text)
        {
            try
            {
                WaitForElementToBeDisplayed(locatorObject);
                _actions = new Actions(_iWebDriver);
                _actions.MoveToElement(_iWebDriver.FindElement(locatorObject.LocatorValue))
                    .SendKeys(text)
                    .SendKeys(Keys.Enter)
                    .Perform();
            }
            catch (WebDriverException webDriverException)
            {
                Fail(webDriverException.Message);
            }
            return this;
        }

        public SeleniumActions Click(LocatorObject locatorObject)
        {
            try
            {
                WaitForElementToBeDisplayed(locatorObject);
                _iWebDriver.FindElement(locatorObject.LocatorValue).Click();
            }
            catch (WebDriverException webDriverException)
            {
                Fail(webDriverException.Message);
            }
            return this;
        }

        public SeleniumActions EntTextInTextBox(LocatorObject locatorObject, String text)
        {
            try
            {
                WaitForElementToBeDisplayed(locatorObject);
                _actions = new Actions(_iWebDriver);
                _actions.MoveToElement(_iWebDriver.FindElement(locatorObject.LocatorValue)).SendKeys(text).Perform();
            }
            catch (WebDriverException webDriverException)
            {
                Fail(webDriverException.Message);
            }
            return this;
        }

        public SeleniumActions WaitForElementToBeDisplayed(LocatorObject locatorObject)
        {
            try
            {
                _webDriverWait = new WebDriverWait(_iWebDriver, TimeSpan.FromSeconds(ExplicitTimeOutInSeconds));
                _webDriverWait.Until(iWebDriver => iWebDriver.FindElement(locatorObject.LocatorValue).Displayed);
            }
            catch (WebDriverException webDriverException)
            {
                Fail("Timed out waiting for page object - " + locatorObject.LocatorDescription + ". Locator value - " +
                     locatorObject.LocatorValue
                     + "\n" + webDriverException.Message);
            }
            return this;
        }

        public SeleniumActions VerifyTextPresentInElement(LocatorObject locatorObject, String textToVerify)
        {
            try
            {
                WaitForElementToBeDisplayed(locatorObject);
                String textFromElement = _iWebDriver.FindElement(locatorObject.LocatorValue).Text;
                if (!textFromElement.Contains(textToVerify))
                {
                    Fail("Text from element - '" + textFromElement + "' does not match expected text - '" +
                         textToVerify + "'");
                }
            }
            catch (WebDriverException webDriverException)
            {
                Fail(webDriverException.Message);
            }

            return this;
        }

        public void Fail(String failureMessage)
        {
            Assert.Fail(failureMessage);
        }
        public static bool Exists(LocatorObject locatorObject)
        {
            return locatorObject != null;
        }
    }
}
