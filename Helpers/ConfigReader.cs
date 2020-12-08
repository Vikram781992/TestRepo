using System.Configuration;

namespace TestProject
{
    public class ConfigReader
    {
        public  ConfigReader()
        {
            BaseURL = ConfigurationManager.AppSettings["URL"];
            Browsertype = ConfigurationManager.AppSettings["BrowserType"];
            UserName = ConfigurationManager.AppSettings["UserName"];
            Password = ConfigurationManager.AppSettings["Password"];
        }

        public string BaseURL { get; }
        public string Browsertype { get; }
        public string Password { get; }
        public string UserName { get; }
    }
}
