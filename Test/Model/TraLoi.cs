using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("CauTraLoi")]
    public class TraLoi
    {
        [Key]
        public int maTl { get; set; }
        public string tenNguoiTraLoi { get; set; }
        public DateTime ngay { get; set; }
        public string NoiDung { get; set; }
        public int maCauHoi { get; set; }
        [ForeignKey("maCauHoi")]
        public virtual CauHoi CauHoi { get; set; }
    }
}
