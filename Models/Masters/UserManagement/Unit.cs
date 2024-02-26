using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoghanAPI.Models.Masters.Main
{
    [Table("M_Units")]
    public class Unit
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public Kelompok? Kelompok { get; set; }
        public int KelompokId { get; set; }
    }
}
