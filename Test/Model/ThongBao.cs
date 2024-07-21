using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("ThongBao")]
    public class ThongBao
    {
        [Key]
        public int maThongBao { get; set; }
        public string tieuDeThongBao { get; set; }
        public string TenNguoiThongBao { get; set; }
        
        
        
    }
}
