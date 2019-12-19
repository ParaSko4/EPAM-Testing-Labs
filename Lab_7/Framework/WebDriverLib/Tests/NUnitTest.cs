using NUnit.Framework;
using OpenQA.Selenium;
using Framework.Pages;
using Framework.Driver;

namespace Framework
{
    [TestFixture]
    public class FirefoxRequests
    {
        public IWebDriver driver;
        private const string SITE_URL = "https://www.momondo.by";

        [SetUp]
        public void OpenBrouser()
        {
            driver = DriverSingleton.GetDriver();
            driver.Url = SITE_URL;
        }

        [Test]
        public void RequestValidation()
        {
            FlightsPage flights = new FlightsPage(driver);

            string text_Input = "Стамбул";

            flights.InputFromValue(text_Input);
            flights.InputToValue(text_Input);
            flights.PressSearch();

            Assert.AreEqual(flights.get_messageError, "Пожалуйста, задайте конкретные аэропорты отправления (Откуда) и прибытия (Куда).");
        }

        [Test]
        public void HotelRecommendation()
        {
            HotelPage hotel = new HotelPage(driver);
            hotel.OpenHotelPage();
            hotel.IncreaseNumberRooms();

            Assert.AreEqual(hotel.get_messageHotelAdvice, "Поиск 8 и более номеров на HotelPlanner.com");
        }

        //[TearDown]
        //public void CloseBrouser()
        //{
        //    DriverSingleton.CloseDriver();
        //}
    }
}