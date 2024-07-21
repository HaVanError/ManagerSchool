using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("MonHoc")]
    public class MonHoc
    {
        [Key]
        public string maMonHoc { get; set; }
        public string maGiaoVien { get; set; }
        [ForeignKey("maGiaoVien")]
        public virtual GiaoVien GiaoVien { get; set; }
        public string tenMonHoc { get; set; }
        public string moTa { get; set; }
        public DateTime NgayTao { get; set; }
        public string maLop { get; set; }
        [ForeignKey("maLop")]
        public Lop Lop { get; set; }
    }
}
