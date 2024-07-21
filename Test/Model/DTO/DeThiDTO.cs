using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model.DTO
{
    public class DeThiDTO
    {
        public string TenBaiThi { get; set; }
        public string hinhThuc { get; set; }
        public string maMonHoc { get; set; }
        public DateTime gio { get; set; }
        public DateTime phut { get; set; }
    }
}
