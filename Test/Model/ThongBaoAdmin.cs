using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("ThongBaoAdmin")]
    public class ThongBaoAdmin
    {
        [Key]
        public int maTBaoAdmin { get; set; }
        public string tieuDe { get; set; }
        

    }
}
