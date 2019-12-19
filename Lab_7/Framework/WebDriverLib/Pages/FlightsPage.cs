using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Pages
{
    public class FlightsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private const int TIME_WAIT = 10;

        public FlightsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_WAIT));
        }

        private IWebElement button_close_icon
        {
            get { return driver.FindElement(By.XPath("//button[@aria-label='' and @tabindex='-1']")); }
        }

        private IWebElement div_From
        {
            get { return driver.FindElement(By.XPath(".//div[@aria-label='Откуда' and @data-placeholder='Откуда?']")); }
        }

        private IWebElement input_From
        {
            get { return driver.FindElement(By.XPath(".//input[@aria-label='Откуда' and @placeholder='Откуда?' and @aria-hidden='false']")); }
        }

        private IWebElement input_From_Accept
        {
            get { return wait.Until(drv => (drv.FindElement(By.XPath(".//li[@data-short-name='Стамбул (IST)']")))); }
        }

        private IWebElement div_To
        {
            get { return driver.FindElement(By.XPath(".//div[@aria-label='Место назначения' and @data-placeholder='Куда?']")); }
        }
        
        private IWebElement input_To
        {
            get { return driver.FindElement(By.XPath("//input[@aria-hidden='false' and @name='destination']")); }
        }

        private IWebElement input_To_Accept
        {
            get { return wait.Until(drv => (drv.FindElement(By.XPath("(//li[@tabindex='0' and @data-short-name='Стамбул (IST)'])[2]")))); }
        }

        private IWebElement button_Search
        {
            get { return driver.FindElement(By.XPath("//button[@aria-label='Найти билеты']")); }
        }

        public string get_messageError
        {
            get { return driver.FindElement(By.XPath("//ul[@class='errorMessages']")).Text; }
        }

        public void InputFromValue(string value)
        {
            button_close_icon.Click();

            input_From.SendKeys(value);
            input_From_Accept.Click();
        }

        public void InputToValue(string value)
        {
            div_To.Click();
            input_To.SendKeys(value);
            input_To_Accept.Click();
        }

        public void PressSearch()
        {
            button_Search.Click();
        }
    }
}
