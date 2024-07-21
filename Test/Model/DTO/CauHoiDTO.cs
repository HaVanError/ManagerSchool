using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model.DTO
{
    public class CauHoiDTO
    {
        public string TenBai { get; set; }
        public string noiDungCauHoi { get; set; }
        public string nguoiBinhLuan { get; set; }
        public bool thich { get; set; }
        public DateTime ngay { get; set; }
        public string Mon { get; set; }
    }
}
