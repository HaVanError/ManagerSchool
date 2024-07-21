using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("Quyen")]
    public class Role
    {
        [Key]
       public int Id { get; set; }
        public string Name { get; set; }
        public string moTa { get; set; }    
        public DateTime ngay { get; set; }  
    }
}
