using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.Main
{
    [Table("M_StatusPegawai")]
    public class StatusPegawai
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
