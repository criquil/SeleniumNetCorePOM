namespace Utilities 
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    
    public class ReadProperties 
    {
        public string BrowserName;
        public bool Headless;
        public string Value;
        //public ReadProperties() 
        //{
        //    ReadAppConfigProperties();
        //}
        public ReadProperties(string section, string property)
        {
            ReadConfigProperties(section, property);
        }
        private void ReadAppConfigProperties() 
        {
            string getCurrentPath = Directory.GetCurrentDirectory();
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddIniFile("SeleniumConfig.ini")
                .Build();    
            BrowserName = configurationBuilder.GetSection("Browser:BrowserName").Value;
            Headless = Boolean.Parse(configurationBuilder.GetSection("Browser:Headless").Value);
        }
        private void ReadConfigProperties(string section, string property)
        {
            string getCurrentPath = Directory.GetCurrentDirectory();
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddIniFile("SeleniumConfig.ini")
                .Build();
           
            Value = configurationBuilder.GetSection(section + ":" + property).Value;
        }
    }
}
