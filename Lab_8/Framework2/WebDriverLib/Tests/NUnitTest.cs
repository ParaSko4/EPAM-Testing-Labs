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
        private const int MAX_CLICKS_TRAVELERS_ADULTS = 9;
        private const int MAX_CLICKS_TRAVELERS_TEENS = 8;

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
        public void TravelersAdultsWarning()
        {
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressTravelers()
                                                         .PressTravelersAdultsIncrements(MAX_CLICKS_TRAVELERS_ADULTS);
            Assert.AreEqual(flights.get_AdultsWarning, "Поиск поддерживает не более 9 взрослых");
        }

        [Test]
        public void TravelersChildsWarning()
        {
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressTravelers()
                                                         .PressTravelersChildIncrement()
                                                         .PressTravelersChildIncrement();
            Assert.AreEqual(flights.get_ChildWarning, "Детей без места не может быть больше, чем взрослых");
        }

        [Test]
        public void FlightsSearchChildsAdvise()
        {
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressTravelers()
                                                         .PressTravelersChildIncrement()
                                                         .PressRoundTrip()
                                                         .InputArrivalCityValue(FlightsCreator.OnlyArrivalCity())
                                                         .AcceptFirstValuOnTravelList()
                                                         .PressSearch();
            Assert.AreEqual(flights.get_ChildAdvise, "Некоторые авиакомпании взимают плату за младенцев без места. Мы показываем общую цену за всех пассажиров.");
        }

        [Test]
        public void MaxTravelersWarning()
        {
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressTravelers()
                                                         .PressTravelersAdultsIncrements(MAX_CLICKS_TRAVELERS_ADULTS)
                                                         .PressTravelersTeenIncrements(MAX_CLICKS_TRAVELERS_TEENS);
            Assert.AreEqual(flights.get_MaxTravelersWarning, "Поиск поддерживает не более 16 пассажиров");
        }

        [Test]
        public void WorkingDisavledPlace()
        {
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressRoundTrip()
                                                         .PressRoundTripOneWay();
            Assert.AreEqual(flights.get_InfoPlaceIsDisabled, false);
        }

        [Test]
        public void HotelNotification()
        {
            HotelPage hotel = new HotelPage(driver).OpenHotelPage()
                                                   .InputArrivalCityValue(FlightsCreator.OnlyArrivalCity())
                                                   .PressSearch()
                                                   .PressToggleNotification();
            Assert.AreEqual(hotel.get_ButtonMailDisabledInfo, "disabled");
        }

        [Test]
        public void HotelEmptyValue()
        {
            HotelPage hotel = new HotelPage(driver).OpenHotelPage()
                                                   .PressSearch();
            Assert.AreEqual(hotel.get_EmptyValueMessage, "Укажите город, название отеля или достопримечательность.");
        }

        [Test]
        public void HotelResetStar()
        {
            HotelPage hotel = new HotelPage(driver).OpenHotelPage()
                                                   .InputArrivalCityValue(FlightsCreator.OnlyArrivalCity())
                                                   .PressSearch()
                                                   .PressReset();
            Assert.AreEqual(hotel.get_SelectedStar, "0+");
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