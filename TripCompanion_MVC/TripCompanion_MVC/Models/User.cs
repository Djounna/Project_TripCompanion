namespace TripCompanion_MVC.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserForm // Post Form
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class ConnectedUser // For Session purposes
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; } // "user" by default
    }

    public class UserLogin // Login Form
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
