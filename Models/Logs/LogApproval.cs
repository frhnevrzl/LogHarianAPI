using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Models.Masters.Status;
using LoghanAPI.Models.Transactions;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Logs
{
    [Table("LOG_ApprovalLaporan")]
    public class LogApproval
    {
        public int Id { get; set; }
        public DateTime ApproveDate { get; set; }
        public string? Keterangan { get; set; }

        //FK Sections
        public LaporanHarian LaporanHarian { get; set; }
        public int LaporanHarianId { get; set; }
        public string? ApproverNPP{ get; set; }
        public StatusLaporan StatusLaporan { get; set; }
        public int StatusLaporanId { get; set; }
    }
}
