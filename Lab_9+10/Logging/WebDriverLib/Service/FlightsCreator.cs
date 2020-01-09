using Framework.Models;

namespace Framework.Service
{
    public class FlightsCreator
    {
        public static FlightsModel WithAllProperties()
        {
            return new FlightsModel(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"));
        }
        public static FlightsModel OnlyDepartureCity()
        {
            return new FlightsModel(TestDataReader.GetData("DepartureCity"), "");
        }
        public static FlightsModel OnlyArrivalCity()
        {
            return new FlightsModel("", TestDataReader.GetData("ArrivalCity"));
        }
        public static FlightsModel Empty()
        {
            return new FlightsModel("", "");
        }
    }
}
