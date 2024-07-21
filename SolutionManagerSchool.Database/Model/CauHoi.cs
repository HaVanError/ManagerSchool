using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("CauHoi")]
    public class CauHoi
    {
        [Key]
        public int maCauHoi { get; set; }
       
        [ForeignKey("TenBai")]
        public string TenBai { get; set; }
        public string noiDungCauHoi { get;set; }
        public string NguoiBinhLuan { get; set; }
        public DateTime ngay { get; set; }
        public bool thich { get; set; }
        public string Mon { get; set; }
        [ForeignKey(nameof(Mon))]
        public virtual MonHoc MonHoc { get; set; }    
    }
}
