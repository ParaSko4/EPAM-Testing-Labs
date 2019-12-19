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
            driver.Url = SITE_URL;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_WAIT));
        }

        private IWebElement obscures
        {
            get { return driver.FindElement(By.XPath(".//div[@class='keel-container']")); }
        }

        private IWebElement button_close_icon
        {
            get { return driver.FindElement(By.XPath("//button[@aria-label='' and @tabindex='-1']")); }
        }

        private IWebElement div_DepartureCity
        {
            get { return driver.FindElement(By.XPath(".//div[@aria-label='Откуда' and @data-placeholder='Откуда?']")); }
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

        private IWebElement button_Travelers
        {
            get { return driver.FindElement(By.XPath(".//button[@data-expandto='']")); }
        }

        private IWebElement buttonIncrement_Adults
        {
            get { return driver.FindElement(By.XPath("(.//button[@title='Еще'])[6]")); }
        }

        private IWebElement buttonIncrement_Childs
        {
            get { return driver.FindElement(By.XPath("(.//button[@title='Еще'])[10]")); }
        }

        private IWebElement buttonIncrement_Teen
        {
            get { return driver.FindElement(By.XPath("(.//button[@title='Еще'])[7]")); }
        }

        private IWebElement button_Search
        {
            get { return driver.FindElement(By.XPath("//button[@aria-label='Найти билеты']")); }
        }

        private IWebElement round_Trip
        {
            get { return driver.FindElement(By.XPath(".//div[@data-value='roundtrip']")); }
        }

        private IWebElement round_TripOneWay
        {
            get { return driver.FindElement(By.XPath(".//ul[@aria-label='Выберите тип поиска:']//li[@data-value='oneway']")); }
        }

        public string get_Error
        {
            get { return driver.FindElement(By.XPath("//ul[@class='errorMessages']")).Text; }
        }

        public string get_AdultsWarning
        {
            get { return driver.FindElement(By.XPath("(.//div[@aria-live='assertive']//strong)[2]")).Text; }
        }

        public string get_ChildWarning
        {
            get { return driver.FindElement(By.XPath("(.//div[@aria-live='assertive']//strong)[2]")).Text; }
        }

        public string get_ChildAdvise
        {
            get 
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@data-code='infant']//div")));
                return wait.Until(drv => drv.FindElement(By.XPath(".//div[@data-code='infant']//div")).Text); 
            }
        }

        public string get_MaxTravelersWarning
        {
            get { return driver.FindElement(By.XPath("(.//div[@aria-live='assertive']//strong)[2]")).Text; }
        }

        public bool get_InfoPlaceIsDisabled
        {
            get { return driver.FindElement(By.XPath("//div[@data-placeholder='Обратно']")).Displayed; }
        }

        public FlightsPage NullFocus()
        {
            obscures.Click();
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

        public FlightsPage trip()
        {
            button_Search.Click();
            return this;
        }

        public FlightsPage PressRoundTrip()
        {
            round_Trip.Click();
            return this;
        }

        public FlightsPage PressRoundTripOneWay()
        {
            round_TripOneWay.Click();
            return this;
        }

        public FlightsPage PressTravelers()
        {
            button_Travelers.Click();
            return this;
        }

        public FlightsPage PressTravelersAdultsIncrements(int max_clicks)
        {
            for (int i = 0; i < max_clicks; i++)
            {
                buttonIncrement_Adults.Click();
            }
            return this;
        }
        
        public FlightsPage PressTravelersChildIncrement()
        {
            buttonIncrement_Childs.Click();
            return this;
        }

        public FlightsPage PressTravelersTeenIncrements(int max_clicks)
        {
            for (int i = 0; i < max_clicks; i++)
            {
                buttonIncrement_Teen.Click();
            }
            return this;
        }

        public FlightsPage PressSearch()
        {
            button_Search.Click();
            return this;
        }
    }
}