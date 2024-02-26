using LoghanAPI.Models.Masters.Main;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.UserManagement
{
    [Table("M_UserRole")]
    public class UserRole
    {
        public User User { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
