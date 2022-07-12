namespace API.Models
{
    public class ConnectedUser
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        // public string Password { get; set; } // A voir, pas utile selon moi.
        public string Token { get; set; }
    }
}
