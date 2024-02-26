namespace LoghanAPI.ViewModels.Masters
{
    public class UnitVM
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int KelompokId { get; set; }
    }
    public class MasterVM
    {
        public Guid? Id { get; set; }
        public string Nama { get; set; }
    }
}
