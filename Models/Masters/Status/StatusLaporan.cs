using LoghanAPI.Models.Logs;
using LoghanAPI.Models.Transactions;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.Status
{
    [Table("M_StatusLaporan")]
    public class StatusLaporan
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
