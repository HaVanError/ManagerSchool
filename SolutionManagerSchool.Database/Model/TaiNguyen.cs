using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("TaiNguyen")]
    public class TaiNguyen
    {
        [Key]
        public int IdTaiNguyen { get; set; }
        public string tenTaiNguyen { get; set; }
        public byte[] Content { get; set; }
        public DateTime NgayUpload { get; set; }
        public bool TrangThai { get; set; }
        public string ghiChu { get; set; }
        public int maChuDe { get; set; }
        public string hinhThuc { get; set; }
        public int maBaiGiang { get; set; }
        public string UpdateByMember { get; set; }
        public string maMonHoc { get; set; }
        

    }
}
