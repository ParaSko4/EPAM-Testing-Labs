using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

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

        public string get_HotelAdvice
        {
            get { return driver.FindElement(By.XPath("//a[contains(text(),'Поиск 8 и более номеров на HotelPlanner.com')]")).Text; }
        }

        public HotelPage OpenHotelPage()
        {
            driver.Url = SITE_URL;
            return this;
        }

        public HotelPage PressGuests()
        {
            button_Guests.Click();
            return this;
        }

        public HotelPage IncreaseNumberRooms(int max_clicks)
        {
            for (int i = 0; i < max_clicks; i++)
            {
                buttonIncrement_Rooms.Click();
            }
            return this;
        }
    }
}