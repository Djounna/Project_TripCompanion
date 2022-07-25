namespace TripCompanion_MVC.Models.ApiResults
{
    public class GeoapifyResult
    {
        public class Result
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }


        public Result[] results { get; set; }

    }
}
