using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("DuyetBai")]
    public class DuyetBaiGiang
    {
        [Key]
        public int ID{ get; set; }
        public  string LoiNhan { get; set; }
        public int maBaiGiang { get; set; }
        [ForeignKey(nameof(maBaiGiang))]
        public  virtual  BaiGiang BaiGiang { get; set; }
    }
}
