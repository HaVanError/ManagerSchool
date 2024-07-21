using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("GiaoVien")]
    public class GiaoVien 
    {
        [Key]
        public string maGiaoVien { get; set; }
        public string maTK { get; set; } 
        [ForeignKey("maTK")]
        public virtual User user { get; set; }
        public string maKhoa { get; set; }
        [ForeignKey("maKhoa")]
        public virtual Khoa Khoa { get; set; }
    }
}
