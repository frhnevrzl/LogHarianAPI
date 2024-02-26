using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.Main
{
    [Table("M_Kelompoks")]
    public class Kelompok
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
