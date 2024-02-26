using LoghanAPI.Models.Logs;
using LoghanAPI.Models.Masters.Application;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Models.Masters.Status;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Transactions
{
    [Table("TRX_LaporanHarian")]
    public class LaporanHarian
    {
        public int Id { get; set; }
        public string Nomor { get; set; }
        public string Keterangan { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int Index { get; set; }
        public bool IsDelete { get; set; }

        //FK Sections
        public Application Application { get; set; }
        public int ApplicationId { get; set; }
        public KategoriLaporan KategoriLaporan { get; set; }
        public int KategoriLaporanId { get; set; }
        public StatusLaporan Status { get; set; }
        public int StatusId { get; set; }
        public User Creater { get; set; }
        public string CreaterId { get; set; }
    }
}
