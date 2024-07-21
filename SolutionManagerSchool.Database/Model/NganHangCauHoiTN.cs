using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("NganHangCauHoi")]
    public class NganHangCauHoiTN
    {
        [Key]
        public string Id { get; set; }
        public string mon { get; set; }
        public string doKho { get; set; }
        public string nguoiSoHuu { get; set; }
        public DateTime suaDoiLanCuoi { get; set; }
       
       // public virtual CauHoiTN CauHoiTN { get; set; }
    }
}
