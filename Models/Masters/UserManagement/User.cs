using LoghanAPI.Models.Masters.UserManagement;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.Main
{
    [Table("M_Users")]
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Nama { get; set; }
        public string NPP { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? Ext { get; set; }
        public bool IsDeleted { get; set; }
        public Unit Unit { get; set; }
        public int? UnitId { get; set; }
        public StatusPegawai StatusPegawai { get; set; }
        public int? StatusPegawaiId { get; set; }
        public Jabatan Jabatan { get; set; }
        public int JabatanId { get; set; }

        public ICollection<UserRole> UserRole { get; set; }

    }
}
