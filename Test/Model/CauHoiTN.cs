using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("CauHoiTN")]
    public class CauHoiTN
    {
        [Key]
        public int maCauHoiTN { get; set; }
        public string tieuDeCauHoi { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string dapAnChinhXac { get; set; }
        [ForeignKey("IdNganHangCauHoi")]
        public string IdNganHangCauHoi { get; set; }
        

    }
}
