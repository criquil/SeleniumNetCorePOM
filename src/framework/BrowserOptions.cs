namespace Framework
{
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using Utilities;
    using System;

    public class BrowserOptions
    {
        string Headless = new ReadProperties("Browser", "Headless").Value;
        public FirefoxDriverService FirefoxDriverService
        {
            get
            {
                FirefoxDriverService firefoxDriverService =
                    FirefoxDriverService.CreateDefaultService(@".");
                return firefoxDriverService;
            }
        }
        public ChromeDriverService ChromeDriverService
        {
            get
            {
                ChromeDriverService chromeDriverService =
                    ChromeDriverService.CreateDefaultService(@".");
                return chromeDriverService;
            }
        }
        public EdgeDriverService EdgeDriverService
        {
            get
            {
                EdgeDriverService edgeDriverService =
                    EdgeDriverService.CreateDefaultService(@".");
                return edgeDriverService;
            }
        }

        public FirefoxOptions FirefoxOptions
        {
            get
            {
                FirefoxOptions firefoxOptions = new FirefoxOptions
                {
                    AcceptInsecureCertificates = true, LogLevel = FirefoxDriverLogLevel.Fatal
                };
                if (Boolean.Parse(Headless))
                    firefoxOptions.AddArgument("--headless");
                return firefoxOptions;
            }
        }
        public ChromeOptions ChromeOptions
        {
            get
            {
                ChromeOptions chromeOptions = new ChromeOptions
                {
                    AcceptInsecureCertificates = true
                };
                if (Boolean.Parse(Headless))
                    chromeOptions.AddArgument("--headless");
                return chromeOptions;
            }
        }
       
        public EdgeOptions EdgeOptions
        {
            get
            {
                EdgeOptions edgeOptions = new EdgeOptions
                {
                    AcceptInsecureCertificates = true,
                  
                };
                if (Boolean.Parse(Headless))
                    edgeOptions.AddArgument("--headless");
                return edgeOptions;
            }
        }
       
    }
}
