using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("HocSinh")]
    public class HocSinh
    {
        [Key]
        public string maHocSinh { get; set; }
        public string maTK { get; set; }
        [ForeignKey("maTK")]
        public virtual User user { get; set; }
        public string maLop { get; set; }
        [ForeignKey("maLop")]
        public virtual Lop Lop { get; set; }
        public string maKhoa { get; set; }
        [ForeignKey("maKhoa")]
        public virtual Khoa Khoa { get; set; }
    }
}
