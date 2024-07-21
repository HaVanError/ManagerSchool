using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("CauHoiTuLuan")]
    public class TuLuan
    {
        [Key]
        public int Id { get; set; }
        public string ThuTuCauHoi { get; set; }
        public string NoiDung { get; set; }

    }
}
