using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("BaiGiang")]
    public class BaiGiang
    {
        [Key]
        public int maBaiGiang { get; set; }
        public string tenBaiGiang { get;set; }
        public int kichThuc { get; set; }
        public DateTime NgayUpload { get; set; }
        public bool TrangThai { get; set; }
        public string ghiChu { get; set; }
        public byte[] Content { get; set; }
        public string UpdateByMember { get; set; }
        public int maChuDe { get; set; }
        public string hinhThuc { get; set; }
        public string maMonHoc { get; set; }
        [ForeignKey(nameof(maMonHoc))]
        public virtual MonHoc MonHoc { get; set; }
    }
}
