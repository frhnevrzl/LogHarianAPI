using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.UserManagement
{
    [Table("M_Role")]
    public class Role
    {
        public Guid Id { get; set; }
        public string Nama { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
    }
}
