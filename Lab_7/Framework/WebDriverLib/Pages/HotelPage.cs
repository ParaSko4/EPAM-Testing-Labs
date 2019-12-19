using OpenQA.Selenium;

namespace Framework.Pages
{
    public class HotelPage
    {
        private readonly IWebDriver driver;

        public HotelPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement button_Hotel
        {
            get { return driver.FindElement(By.ClassName("js-vertical-hotels")); }
        }

        private IWebElement button_roomsGuests
        {
            get {  return driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[3]/div[1]/div[1]/div/div[1]/div[2]/section[2]/div/div[2]/div[1]/form/div[1]/div/div/div[4]/div/button/div/div[1]/div/div")); }
        }

        private IWebElement button_plusRooms
        {
            get { return driver.FindElement(By.XPath("/html/body/div[8]/div/div[1]/div[2]/div/div[2]/div/div/div[3]/button/span")); }
        }

        public string get_messageHotelAdvice
        {
            get { return driver.FindElement(By.XPath("/html/body/div[8]/div/div[3]/a")).Text; }
        }

        public void OpenHotelPage()
        {
            button_Hotel.Click();
        }

        public void IncreaseNumberRooms()
        {
            button_roomsGuests.Click();

            for (int i = 0, max_Clicks = 8; i < max_Clicks; i++)
            {
                button_plusRooms.Click();
            }
        }
    }
}
