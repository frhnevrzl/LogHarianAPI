namespace LoghanAPI.ViewModels.Masters
{
    public class UsersViewModel
    {
        public string Nama { get; set; }
        public string Email  { get; set; }
        public string NPP { get; set; }
        public string Password { get; set; }
        public string? Ext { get; set; }
        public int UnitId { get; set; }
        public int JabatanId { get; set; }
        public int StatusPegawaiId { get; set; }

        public List<RoleViewModel>? Roles { get; set; }
    }

    public class RoleViewModel
    {
        public Guid RoleId { get; set; }
    }
}
