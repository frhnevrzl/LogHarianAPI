namespace LoghanAPI.ViewModels.Masters
{
    public class LaporanVM
    {
        public int? Id { get; set; }
        public string Keterangan { get; set; }
        public int KategoriLaporanId { get; set; }
        public int ApplicationId { get; set; }
        public string CreaterId { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }

    public class LogApprovalVM
    {
        public string? Keterangan { get; set; }
        public int LaporanHarianId { get; set; }
        public string? ApproverNPP{ get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int StatusLaporanId { get; set; }
    }

    public class GetDataLaporan
    {
        public int Id { get; set; }
        public string Nomor { get; set; }
        public string Keterangan { get; set; }
        public string SubmitDate { get; set; }
        public string NamaAplikasi { get; set; }
        public string KategoriLaporan { get; set; }
        public string LastStatus { get; set; }
        public string Maker { get; set; }
    }
}
