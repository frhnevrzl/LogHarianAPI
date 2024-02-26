using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Transactions
{
    [Table("TRX_AttachmentLaporan")]
    public class AttachmentLaporan
    {
        public int Id { get; set; }
        public string PathFile { get; set; }

        //FK Sections
        public LaporanHarian LaporanHarian { get; set; }
        public int LaporanHarianId { get; set; }
    }
}
