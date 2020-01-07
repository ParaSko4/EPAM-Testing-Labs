using Framework.Logging;
using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Framework.Pages
{
    public class HotelPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        private const string SITE_URL = "https://www.momondo.by/oteli";
        private const int TIME_WAIT = 10;

        public HotelPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIME_WAIT));
        }

        private IWebElement button_Guests
        {
            get {  return driver.FindElement(By.XPath(".//form//div//div//button[@aria-label='Укажите кол-во гостей и номеров' and @data-expandto='']")); }
        }

        private IWebElement buttonIncrement_Rooms
        {
            get 
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//button[@aria-label='Добавить номер' and @title='Добавить номер']")));
                return driver.FindElement(By.XPath(".//button[@aria-label='Добавить номер' and @title='Добавить номер']")); 
            }
        }

        private IWebElement button_Search
        {
            get { return driver.FindElement(By.XPath(".//button[@aria-label='Найти отели']")); }
        }
        
        private IWebElement toggle_Notification
        {
            get 
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//input[@type='checkbox']")));
                return wait.Until(drv => drv.FindElement(By.XPath(".//input[@type='checkbox']"))); 
            }
        }

        private IWebElement div_Input
        {
            get { return driver.FindElement(By.XPath(".//div[@data-placeholder='Введите город, аэропорт, адрес или место']")); }
        }

        private IWebElement input_Value
        {
            get { return driver.FindElement(By.XPath(".//input[@aria-label='Место назначения']")); }
        }

        private IWebElement input_Accept_First_Value
        {
            get 
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class='Common-Widgets-Text-InputModal-smarty-content visible']//ul//li[@class='city']")));
                return driver.FindElement(By.XPath(".//div[@class='Common-Widgets-Text-InputModal-smarty-content visible']//ul//li[@class='city']")); 
            }
        }
        private IWebElement button_Reset
        {
            get 
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class='reset']")));
                return driver.FindElement(By.XPath(".//div[@class='reset']")); 
            }
        }

        public string get_HotelAdvice
        {
            get { return driver.FindElement(By.XPath("//a[contains(text(),'Поиск 8 и более номеров на HotelPlanner.com')]")).Text; }
        }

        public string get_ButtonMailDisabledInfo
        {
            get { return driver.FindElement(By.XPath(".//div[@class='driveByForm']//button")).GetAttribute("disabled"); }
        }

        public string get_EmptyValueMessage
        {
            get { return driver.FindElement(By.XPath(".//ul[@class='errorMessages']//li")).Text; }
        }

        public string get_SelectedStar
        {
            get { return wait.Until(drv => drv.FindElement(By.XPath(".//div[@class='star-card card-any selected']//div//div")).Text); }
        }

        public HotelPage OpenHotelPage()
        {
            driver.Url = SITE_URL;
            Logger.Log.Info(": open hotel page");
            return this;
        }

        public HotelPage PressToggleNotification()
        {
            toggle_Notification.Click();
            Logger.Log.Info(": press toggle notification");
            return this;
        }

        public HotelPage PressGuests()
        {
            button_Guests.Click();
            Logger.Log.Info(": press guests");
            return this;
        }

        public HotelPage IncreaseNumberRooms(int max_clicks)
        {
            for (int i = 0; i < max_clicks; i++)
            {
                buttonIncrement_Rooms.Click();
            }
            Logger.Log.Info(": increase number rooms");
            return this;
        }

        public HotelPage InputArrivalCityValue(FlightsModel value)
        {
            div_Input.Click();
            input_Value.SendKeys(value.Arrival_City);
            input_Accept_First_Value.Click();
            Logger.Log.Info(": input arrival city value");
            return this;
        }

        public HotelPage PressSearch()
        {
            button_Search.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class='reset']")));
            Logger.Log.Info(": press search");
            return this;
        }

        public HotelPage PressReset()
        {
            button_Reset.Click();
            Logger.Log.Info(": press reset");
            return this;
        }
    }
}
