
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("TaiKhoan")]
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public bool gioTinh { get;set; }
        public string hinhAnh { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public int maQuyen { get; set; }
        [ForeignKey(nameof(maQuyen))]
        public virtual Role Role { get; set; }
        //public string Token { get; set; } = string.Empty;
        ////    public string idJwt { get; set; }
        //public DateTime ThoiGianTao { get; set; } = DateTime.Now;
        //public DateTime ThoiGianHetHan { get; set; }

    }  
}
