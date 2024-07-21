using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Model
{
    [Table("RefreshToken")]
    public class RefreshToken
    {
        [Key]
        public Guid id {get; set;}
        public string idUser { get; set; }
        [ForeignKey("idUser")]
        public User user { get; set;}
        public string Token { get; set; } = string.Empty;
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public string idJwt { get; set; }
        public DateTime ThoiGianTao { get; set; } = DateTime.Now;
        public DateTime ThoiGianHetHan { get; set; }
    }
}
