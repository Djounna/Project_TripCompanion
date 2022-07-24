namespace TripCompanion_MVC.Models.ApiResults
{
    public class GeoapifyResult
    {
        public Result[] results { get; set; }

        public class Result
        {
            public string lon { get; set; }
            public string lat { get; set; }
        }




    }
}
