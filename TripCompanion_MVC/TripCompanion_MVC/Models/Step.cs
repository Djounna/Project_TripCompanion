namespace TripCompanion_MVC.Models
{
    public class Step
    {
        public int IdStep { get; set; }
        public string Name { get; set; }
        public int? Budget { get; set; }
        public double? Time { get; set; }
        public string? Comments { get; set; }
        //FK
        public int IdTrip { get; set; }
    }

    public class StepForm // Post Form
    {
        public string Name { get; set; }
        public int? Budget { get; set; }
        public double? Time { get; set; }
        public string? Comments { get; set; }
        //FK
        public int IdTrip { get; set; }
    }
}
