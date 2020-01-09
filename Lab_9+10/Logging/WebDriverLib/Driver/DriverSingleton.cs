using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Framework.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        FirefoxOptions options = new FirefoxOptions();
                        options.BrowserExecutableLocation = ("C:\\Program Files\\Firefox Developer Edition\\firefox.exe");
                        driver = new FirefoxDriver(options);
                        break;
                }
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}