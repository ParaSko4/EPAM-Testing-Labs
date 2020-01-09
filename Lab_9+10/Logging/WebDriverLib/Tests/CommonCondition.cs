using Framework.Driver;
using Framework.Logging;
using log4net;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace WebDriverLib.Tests
{
    public class CommonCondition
    {
        public IWebDriver driver;
        public static ILog log = LogManager.GetLogger("logger");

        [SetUp]
        public void OpenBrouser()
        {
            Logger.InitLogger();
            driver = DriverSingleton.GetDriver();
            Logger.Log.Info(": driver was opened");
        }

        [TearDown]
        public void CloseBrouser()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenshot_Name = DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png";
                Logger.Log.Error($": test failed, taking screenshot, name [{screenshot_Name}]");
                string screenshots_Folder = AppDomain.CurrentDomain.BaseDirectory + @"\Logging\Errors\";
                Directory.CreateDirectory(screenshots_Folder);
                ((ITakesScreenshot)driver).GetScreenshot()
                                          .SaveAsFile(screenshots_Folder + screenshot_Name);
            }

            DriverSingleton.CloseDriver();
            Logger.Log.Info(": driver was closed");
        }
    }
}
