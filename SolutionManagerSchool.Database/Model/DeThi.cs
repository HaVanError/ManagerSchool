using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("DeThi&KiemTra")]
    public class DeThi
    {
        [Key]
        public int Id { get; set; }
        public string TenBaiThi { get; set; }
        public string hinhThuc { get; set; }
        public string maMonHoc { get; set; }
        public string TenGiaoVien { get; set; }
        public string ThoiGiangThi { get; set; }
        public string TinhTrang { get; set; }
        public byte[] Content { get; set; }
    }
}
