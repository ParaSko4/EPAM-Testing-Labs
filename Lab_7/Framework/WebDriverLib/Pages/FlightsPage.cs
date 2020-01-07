using System;
using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Pages
{
    public class FlightsPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private const string SITE_URL = "https://www.momondo.by";
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

        private IWebElement input_DepartureCity
        {
            get { return driver.FindElement(By.XPath(".//input[@aria-label='Откуда' and @placeholder='Откуда?' and @aria-hidden='false']")); }
        }

        private IWebElement div_ArrivalCity
        {
            get { return driver.FindElement(By.XPath(".//div[@aria-label='Место назначения' and @data-placeholder='Куда?']")); }
        }
        
        private IWebElement input_ArrivalCity
        {
            get { return driver.FindElement(By.XPath("//input[@aria-hidden='false' and @name='destination']")); }
        }

        private IWebElement input_Accept_First_Value
        {
            get { return wait.Until(drv => drv.FindElement(By.XPath(".//div[@class='Common-Widgets-Text-InputModal-smarty-content visible']//ul//li[@class='ap aap']"))); }
        }

        private IWebElement button_Search
        {
            get { return driver.FindElement(By.XPath("//button[@aria-label='Найти билеты']")); }
        }

        public string get_Error
        {
            get { return driver.FindElement(By.XPath("//ul[@class='errorMessages']")).Text; }
        }

        public FlightsPage OpenFlightsPage()
        {
            driver.Url = SITE_URL;
            return this;
        }

        public FlightsPage InputDepartureCityValue(FlightsModel value)
        {
            button_close_icon.Click();
            input_DepartureCity.SendKeys(value.Departure_City);
            return this;
        }

        public FlightsPage InputArrivalCityValue(FlightsModel value)
        {
            div_ArrivalCity.Click();
            input_ArrivalCity.SendKeys(value.Arrival_City);
            return this;
        }

        public FlightsPage AcceptFirstValuOnTravelList()
        {
            input_Accept_First_Value.Click();
            return this;
        }

        public FlightsPage PressSearch()
        {
            button_Search.Click();
            return this;
        }
    }
}