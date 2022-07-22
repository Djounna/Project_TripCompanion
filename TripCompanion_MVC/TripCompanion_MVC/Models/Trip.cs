using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TripCompanion_MVC.Models
{
    public class Trip
    {
        public int IdTrip { get; set; }
        [Display(Name="Nom")]
        [Required,MinLength(4),MaxLength(20)]
        public string Name { get; set; }
        [Display(Name="Date de début")]
        [Required]
        public DateTime StartingDate { get; set; }
        [Display(Name="Date de fin")]
        [Required]
        public DateTime EndingDate { get; set; }
        [Display(Name = "Budget")]
        [Range(1,int.MaxValue)]
        public int? Budget { get; set; }
        [Display(Name = "Commentaires")]
        public string? Comments { get; set; }
        //FK
        public int IdUser { get; set; }
    }

    public class TripForm // For Post Form
    {
        [Display(Name = "Nom")]
        [Required,MinLength(4), MaxLength(20)]
        public string Name { get; set; }
        [Display(Name = "Date de début")]
        [Required]
        public DateTime StartingDate { get; set; }
        [Display(Name = "Date de fin")]
        [Required]
        public DateTime EndingDate { get; set; }
        [Display(Name = "Budget")]
        [Range(1, int.MaxValue)]
        public int? Budget { get; set; }
        [Display(Name = "Commentaires")]
        public string? Comments { get; set; }
        //FK
        public int IdUser { get; set; }
    }
}
