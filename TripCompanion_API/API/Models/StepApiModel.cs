namespace API.Models
{
    public class StepApiModel
    {
        public int IdStep { get; set; }
        public string Name { get; set; }
        public int? Budget { get; set; }
        public double? Time { get; set; }
        public string? Comments { get; set; }
        //FK
        public int IdTrip { get; set; }
    }
}
