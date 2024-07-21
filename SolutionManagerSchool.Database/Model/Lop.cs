using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("Lop")]
    public class Lop
    {
        [Key]
        public string maLop { get; set; }
        public string tenLop { get;set; }
        //public string maKhoa { get; set; }
        //[ForeignKey("maKhoa")]
        //public virtual Khoa Khoa { get; set; }

    }
}
