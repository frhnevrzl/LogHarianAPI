using LoghanAPI.ViewModels.Masters;

namespace LoghanAPI.ViewModels
{
    public class TokenGeneratorVM
    {
        public string Username { get; set; }
        public List<Guid> Roles { get; set; }
    }

    public class AuthVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
