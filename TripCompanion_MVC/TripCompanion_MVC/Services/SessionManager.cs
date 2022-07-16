namespace TripCompanion_MVC.Services
{
    public class SessionManager
    {

        public readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public string? Token
        {
            get { return _session.GetString(nameof(Token)); }
            set { _session.SetString(nameof(Token), value); }
        }

        public string? Role
        {
            get { return _session.GetString(nameof(Role)); }
            set { _session.SetString(nameof(Role), value); }
        }

        public int? IdUser
        {
            get { return _session.GetInt32(nameof(IdUser)); }
            set { _session.SetInt32(nameof(IdUser), value.Value); }
        }

        public void clear() // Nettoyage des variables de sessions. // En Test
        {
            _session.Clear();
        }
    }
}
