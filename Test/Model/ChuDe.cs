using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("ChuDe")]
    public class ChuDe
    {
        [Key]
        public int Id { get; set; }
        public string maMonHoc { get; set; }
        [ForeignKey(nameof(maMonHoc))]
        public virtual MonHoc MonHoc { get; set; }
        public string tieuDe { get; set; }
        public string NoiDung { get; set; }
    }
}
