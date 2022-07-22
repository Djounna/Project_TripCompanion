using System.ComponentModel.DataAnnotations;

namespace TripCompanion_MVC.Models
{
    public class Step
    {
        public int IdStep { get; set; }
        [Display(Name="Nom"), Required, MinLength(4),MaxLength(20)]
        public string Name { get; set; }
        [Display(Name="Budget"),Range(1,int.MaxValue)]
        public int? Budget { get; set; }
        [Display(Name="Temps")]
        public double? Time { get; set; }
        [Display(Name="Commentaires")]
        public string? Comments { get; set; }
        //FK
        public int IdTrip { get; set; }
    }

    public class StepForm // Post Form
    {
        [Display(Name = "Nom"), Required, MinLength(4), MaxLength(20)]
        public string Name { get; set; }
        [Display(Name = "Budget"), Range(1, int.MaxValue)]
        public int? Budget { get; set; }
        [Display(Name = "Temps")]
        public double? Time { get; set; }
        [Display(Name = "Commentaires")]
        public string? Comments { get; set; }
        //FK
        public int IdTrip { get; set; }
    }
}
