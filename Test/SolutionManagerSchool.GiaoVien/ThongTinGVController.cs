using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinGVController : ControllerBase
    {
        private readonly Database db;
        public ThongTinGVController(Database db)
        {
            this.db = db;
        }
        [HttpGet("ThongTinGV")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult ThongTin()
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                var kiemtra = db.GiaoViens.FirstOrDefault(x => x.maTK == check.Id);
                var gt = "";
                if (kiemtra.user.gioTinh == true)
                {
                    gt = "Nam";
                }
                else
                {
                    gt = "Nữ";
                }
                if (kiemtra != null)
                {
                    var qr = (from User in db.Users
                              join GiaoVien in db.GiaoViens on User.Id equals GiaoVien.maTK
                              select new ChiTietThongTinGV
                              {
                                  maGv = GiaoVien.maGiaoVien,
                                  gioTinh = gt,
                                  Khoa = GiaoVien.Khoa.tenKhoa,
                                  Email = User.Email,
                                  ten = User.Name,
                                  diaChi = User.DiaChi,
                                  soDienThoai = User.SDT,
                                  hinhAnh = User.hinhAnh,
                              }).Where(x => x.Email == check.Email);
                    return Ok(qr);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
