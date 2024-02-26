using LoghanAPI.Models.Transactions;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.Application
{
    [Table("M_KategoriLaporan")]
    public class KategoriLaporan
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
