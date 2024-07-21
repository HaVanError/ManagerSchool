using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("Khoa")]
    public class Khoa
    {
        [Key]
        public string maKhoa { get; set; }
        public string tenKhoa { get;set; }
    }
}
