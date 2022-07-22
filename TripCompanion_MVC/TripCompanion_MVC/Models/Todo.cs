using System.ComponentModel.DataAnnotations;

namespace TripCompanion_MVC.Models
{
    public class Todo
    {
        public int IdTodo { get; set; }
        [Display(Name="Nom")]
        [Required,MinLength(4),MaxLength(20)]
        public string Name { get; set; }
        [Display(Name="Fait")]
        [Required]
        public bool Done { get; set; }
        [Display(Name="Statut")]
        [Required]
        public string Status { get; set; }
        [Display(Name = "Type")]        
        public string? Type { get; set; }
        [Display(Name = "Priorité")]
        public string? Priority { get; set; }
        [Display(Name = "Date")]
        public DateTime? Calendar { get; set; }
        [Display(Name = "Lieu")]
        public string? Location { get; set; }
        [Display(Name = "Temps prévu")]
        public double? PlannedTime { get; set; }
        [Display(Name = "Budget prévu")]
        public int? PlannedBudget { get; set; }
        [Display(Name = "Temps réel")]
        public double? RealTime { get; set; }
        [Display(Name = "Budget réel")]
        public int? RealBudget { get; set; }
        [Display(Name = "Commentaires")]
        public string? Comments { get; set; }
        // FK
        public int IdStep { get; set; }
        public int? IdMainTodo { get; set; }
    }

    public class TodoForm // Post Form
    {
        [Display(Name = "Nom")]
        [Required, MinLength(4), MaxLength(20)]
        public string Name { get; set; }
        [Display(Name = "Fait")]
        [Required]
        public bool Done { get; set; }
        [Display(Name = "Statut")]
        [Required]
        public string Status { get; set; }
        [Display(Name = "Type")]
        public string? Type { get; set; }
        [Display(Name = "Priorité")]
        public string? Priority { get; set; }
        [Display(Name = "Date")]
        public DateTime? Calendar { get; set; }
        [Display(Name = "Lieu")]
        public string? Location { get; set; }
        [Display(Name = "Temps prévu")]
        public double? PlannedTime { get; set; }
        [Display(Name = "Budget prévu")]
        public int? PlannedBudget { get; set; }
        [Display(Name = "Temps réel")]
        public double? RealTime { get; set; }
        [Display(Name = "Budget réel")]
        public int? RealBudget { get; set; }
        [Display(Name = "Commentaires")]
        public string? Comments { get; set; }
        // FK
        public int IdStep { get; set; }
        public int? IdMainTodo { get; set; }
    } 
}
