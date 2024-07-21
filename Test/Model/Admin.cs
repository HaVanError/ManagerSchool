using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("QuanTriAdmin")]
    public class Admin
    {
        [Key]
        public string IDAdmin { get; set; }
        public string maTK { get; set; }
        [ForeignKey("maTK")]
        public User user { get; set; }
    }
}
