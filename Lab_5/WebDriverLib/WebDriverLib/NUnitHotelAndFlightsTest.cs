using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebDriverLib
{
    [TestFixture]
    public class NUnitHotelAndFlightsTest
    {
        public IWebDriver driver;

        [SetUp]
        public void OpenBrouser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.momondo.by";
        }

        [Test]
        public void RequestValidation()
        {
            Assert.AreEqual(LogicRequestValidationTest(), "Пожалуйста, задайте конкретные аэропорты отправления (Откуда) и прибытия (Куда).");
        }

        [Test]
        public void HotelRecommendation()
        {
            Assert.AreEqual(LogicHotelRecommendationTest(), "Поиск 8 и более номеров на HotelPlanner.com");
        }

        [TearDown]
        public void CloseBrouser()
        {
            driver.Close();
        }

        private string LogicRequestValidationTest()
        {
            bool check_Page = false;

            IWebElement input_From = FindElement("div > input", "-origin");
            if (input_From == null)
            {
                check_Page = true;

                input_From = FindElement("div > input", "-origin-airport");
                FindElement("div", "-origin-airport-display").Click();
            }
            else
            {
                input_From.Click();
            }
            input_From.SendKeys("Стамбул");


            IWebElement input_To = null;
            if (check_Page == true)
            {
                driver.FindElement(By.CssSelector("Body")).Click();
                FindElement("div", "destination-airport-display").Click();

                input_To = FindElement("div > input", "destination-airport");
                input_To.Click();
                input_To.SendKeys("Стамбул");

                FindElement("div", "-origin-airport-display").Click();
                FindElement("div", "col-button-wrapper").FindElement(By.CssSelector("button")).Click();
            }
            else
            {
                input_To = FindElement("div > input", "destination");
                input_To.Click();
                input_To.SendKeys("Стамбул");

                FindElement("div > input", "-origin").Click();
                driver.FindElement(By.ClassName("buttonBlock")).FindElement(By.CssSelector("button")).Click();
            }

            return FindElement("ul", "messages").FindElement(By.XPath("li/ul/li")).Text;
        }

        private string LogicHotelRecommendationTest()
        {
            driver.FindElement(By.ClassName("js-vertical-hotels")).Click();
            driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[3]/div[1]/div[1]/div/div[1]/div[2]/section[2]/div/div[2]/div[1]/form/div[1]/div/div/div[4]/div/button/div/div[1]/div/div")).Click();

            IWebElement button_Plus = driver.FindElement(By.XPath("/html/body/div[8]/div/div[1]/div[2]/div/div[2]/div/div/div[3]/button/span"));
            for (int i = 0, max_Clicks = 8; i < max_Clicks; i++)
            {
                button_Plus.Click();
            }
            return driver.FindElement(By.XPath("/html/body/div[8]/div/div[3]/a")).Text;
        }

        private IWebElement FindElement(string attribute, string name)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector(attribute));
            Regex findByCharptName = new Regex($@"\w*{name}$");

            for (int i = 0; i < elements.Count; i++)
            {
                if (findByCharptName.Match(elements[i].GetAttribute("id")).Success && elements[i].Enabled)
                {
                    return elements[i];
                }
            }
            return null;
        }
    }
}