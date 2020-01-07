namespace Framework.Models
{
    public class FlightsModel
    {
        public string Departure_City { get; set; }
        public string Arrival_City { get; set; }

        public FlightsModel(string departure_city, string arrival_city)
        {
            Departure_City = departure_city;
            Arrival_City = arrival_city;
        }
    }
}
