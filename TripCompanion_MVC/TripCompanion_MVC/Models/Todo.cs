namespace TripCompanion_MVC.Models
{
    public class Todo
    {
        public int IdTodo { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        public string Status { get; set; }
        public string? Type { get; set; }
        public string? Priority { get; set; }
        public DateTime? Calendar { get; set; }
        public string? Location { get; set; }
        public double? PlannedTime { get; set; }
        public int? PlannedBudget { get; set; }
        public double? RealTime { get; set; }
        public int? RealBudget { get; set; }
        public string? Comments { get; set; }
        // FK
        public int IdStep { get; set; }
        public int? IdMainTodo { get; set; }
    }

    public class TodoForm // Post Form
    {
        public string Name { get; set; }
        public bool Done { get; set; }
        public string Status { get; set; }
        public string? Type { get; set; }
        public string? Priority { get; set; }
        public DateTime? Calendar { get; set; }
        public string? Location { get; set; }
        public double? PlannedTime { get; set; }
        public int? PlannedBudget { get; set; }
        public double? RealTime { get; set; }
        public int? RealBudget { get; set; }
        public string? Comments { get; set; }
        // FK
        public int IdStep { get; set; }
        public int? IdMainTodo { get; set; }
    } 
}
