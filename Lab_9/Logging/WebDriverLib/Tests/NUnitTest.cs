using NUnit.Framework;
using Framework.Pages;
using Framework.Service;
using WebDriverLib.Tests;
using Framework.Logging;

namespace Framework
{
    [TestFixture]
    public class TestRequests : CommonCondition
    {
        private const int MAX_CLICKS_ROOMS = 8;
        private const int MAX_CLICKS_TRAVELERS_ADULTS = 9;
        private const int MAX_CLICKS_TRAVELERS_TEENS = 8;

        [Test]
        public void RequestValidation()
        {
            Logger.Log.Info("TEST START: Request Validation");
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
            Logger.Log.Info("TEST START: Travelers Adults Warning");
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressTravelers()
                                                         .PressTravelersAdultsIncrements(MAX_CLICKS_TRAVELERS_ADULTS);
            Assert.AreEqual(flights.get_AdultsWarning, "Поиск поддерживает не более 9 взрослых");
        }

        [Test]
        public void TravelersChildsWarning()
        {
            Logger.Log.Info("TEST START: Travelers Childs Warning");
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressTravelers()
                                                         .PressTravelersChildIncrement()
                                                         .PressTravelersChildIncrement();
            Assert.AreEqual(flights.get_ChildWarning, "Детей без места не может быть больше, чем взрослых");
        }

        [Test]
        public void FlightsSearchChildsAdvise()
        {
            Logger.Log.Info("TEST START: Flights Search Childs Advise");
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
            Logger.Log.Info("TEST START: Max Travelers Warning");
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressTravelers()
                                                         .PressTravelersAdultsIncrements(MAX_CLICKS_TRAVELERS_ADULTS)
                                                         .PressTravelersTeenIncrements(MAX_CLICKS_TRAVELERS_TEENS);
            Assert.AreEqual(flights.get_MaxTravelersWarning, "Поиск поддерживает не более 16 пассажиров");
        }

        [Test]
        public void WorkingDisavledPlace()
        {
            Logger.Log.Info("TEST START: Working Disavled Place");
            FlightsPage flights = new FlightsPage(driver).OpenFlightsPage()
                                                         .PressRoundTrip()
                                                         .PressRoundTripOneWay();
            Assert.AreEqual(flights.get_InfoPlaceIsDisabled, false);
        }

        [Test]
        public void HotelNotification()
        {
            Logger.Log.Info("TEST START: Hotel Notification");
            HotelPage hotel = new HotelPage(driver).OpenHotelPage()
                                                   .InputArrivalCityValue(FlightsCreator.OnlyArrivalCity())
                                                   .PressSearch()
                                                   .PressToggleNotification();
            Assert.AreEqual(hotel.get_ButtonMailDisabledInfo, "disabled");
        }

        [Test]
        public void HotelEmptyValue()
        {
            Logger.Log.Info("TEST START: Hotel Empty Value");
            HotelPage hotel = new HotelPage(driver).OpenHotelPage()
                                                   .PressSearch();
            Assert.AreEqual(hotel.get_EmptyValueMessage, "Укажите город, название отеля или достопримечательность.");
        }

        [Test]
        public void HotelResetStar()
        {
            Logger.Log.Info("TEST START: Hotel Reset Star");
            HotelPage hotel = new HotelPage(driver).OpenHotelPage()
                                                   .InputArrivalCityValue(FlightsCreator.OnlyArrivalCity())
                                                   .PressSearch()
                                                   .PressReset();
            Assert.AreEqual(hotel.get_SelectedStar, "0+");
        }

        [Test]
        public void HotelRecommendation()
        {
            Logger.Log.Info("TEST START: Hotel Recommendation");
            HotelPage hotel = new HotelPage(driver).OpenHotelPage()
                                                   .PressGuests()
                                                   .IncreaseNumberRooms(MAX_CLICKS_ROOMS);
            Assert.AreEqual(hotel.get_HotelAdvice, "Поиск 8 и более номеров на HotelPlanner.com");
        }
    }
}