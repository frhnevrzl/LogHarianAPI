namespace LoghanAPI.ViewModels
{
    public class FilterVM
    {
        public FilterVM() { }
        public FilterVM(bool isFiltered, string byDate, int byKelompok, int byStatus)
        {
            this.isFiltered = isFiltered;
            this.byDate = byDate;
            this.byKelompok = byKelompok;
            this.byStatus = byStatus;   
        }
        public void SetValues(bool isFiltered, string byDate, int byKelompok, int byStatus)
        {
            this.isFiltered = isFiltered;
            this.byDate = byDate;
            this.byKelompok = byKelompok;
            this.byStatus = byStatus;
        }
        public FilterVM(bool isFiltered, int byKelompok, int byUnit)
        {
            this.isFiltered = isFiltered;
            this.byKelompok = byKelompok;
            this.byUnit = byUnit;
        }
        public void SetValues(bool isFiltered, int byKelompok, int byUnit)
        {
            this.isFiltered = isFiltered;
            this.byKelompok = byKelompok;
            this.byUnit = byUnit;
        }
        public FilterVM(bool isFiltered, string byDate, int byKelompok, int byStatus, int byUnit, string byUser)
        {
            this.isFiltered = isFiltered;
            this.byKelompok = byKelompok;
            this.byDate = byDate;
            this.byUnit = byUnit;
            this.byStatus = byStatus;
            this.byUser = byUser;
        }
        public void SetValues(bool isFiltered, string byDate, int byKelompok, int byStatus, int byUnit, string byUser)
        {
            this.isFiltered = isFiltered;
            this.byKelompok = byKelompok;
            this.byDate = byDate;
            this.byUnit = byUnit;
            this.byStatus = byStatus;
            this.byUser = byUser;
        }
        public bool isFiltered { get; set; }
        public string byDate { get; set; }
        public int byKelompok { get; set; }
        public int byUnit { get; set; }
        public int byStatus { get; set; }
        public string byUser { get; set; }
    }
    public class DokumenFilter
    {
        public bool isFiltered { get; set; }
        public int? ApplicationId { get; set; }
        public int? KategoriLaporanId { get; set; }
        public int? StatusId { get; set; }
        public string? Nomor { get; set; }
    }
}
