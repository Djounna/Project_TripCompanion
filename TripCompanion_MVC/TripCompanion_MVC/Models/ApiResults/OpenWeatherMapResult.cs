namespace TripCompanion_MVC.Models.ApiResults
{
    public class OpenWeatherMapResult
    {
        public class Main
        {
            public double Temp { get; set; }
            public double Humidity { get; set; }

        }

        public Main main { get; set; }

    }
}
