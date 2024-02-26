using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.UserManagement
{
    [Table("M_Jabatan")]
    public class Jabatan 
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
