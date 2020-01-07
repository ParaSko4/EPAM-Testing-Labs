using NUnit.Framework;
using OpenQA.Selenium;
using Framework.Pages;
using Framework.Driver;
using Framework.Service;

namespace Framework
{
    [TestFixture]
    public class FirefoxRequests
    {
        public IWebDriver driver;
        private const int MAX_CLICKS_ROOMS = 8;

        [SetUp]
        public void OpenBrouser()
        {
            driver = DriverSingleton.GetDriver();
        }

        [Test]
        public void RequestValidation()
        {
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .InputDepartureCityValue(FlightsCreator.WithAllProperties())
                                                         .AcceptFirstValuOnTravelList()
                                                         .InputArrivalCityValue(FlightsCreator.WithAllProperties())
                                                         .AcceptFirstValuOnTravelList()
                                                         .PressSearch();
            Assert.AreEqual(flights.get_Error, "Пожалуйста, задайте конкретные аэропорты отправления (Откуда) и прибытия (Куда).");
        }

        [Test]
        public void HotelRecommendation()
        {
            HotelPage hotel = new HotelPage(driver).OpenHotelPage()
                                                   .PressGuests()
                                                   .IncreaseNumberRooms(MAX_CLICKS_ROOMS);
            Assert.AreEqual(hotel.get_HotelAdvice, "Поиск 8 и более номеров на HotelPlanner.com");
        }

        [TearDown]
        public void CloseBrouser()
        {
            DriverSingleton.CloseDriver();
        }
    }
}