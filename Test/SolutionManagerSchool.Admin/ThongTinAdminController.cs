using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinAdminController : ControllerBase
    {
        private readonly Database db;
        public ThongTinAdminController(Database db)
        {
            this.db = db;
        }
        [HttpGet("ThongTinAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThongTin()
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

           
                var kiemtra = db.Admins.SingleOrDefault(x => x.maTK == check.Id);
                var gt = "";
                if(kiemtra.user.gioTinh == true)
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
                              join Admin in db.Admins on User.Id equals Admin.maTK
                              select new ChiTietThongTinAdmin
                              {
                                  maAdmin = Admin.IDAdmin,
                                  gioTinh = gt,
                                  vaitro = User.Role.Name,
                                  Email = User.Email,
                                  ten = User.Name,
                                  soDienThoai = User.SDT,
                                  diaChi = User.DiaChi,
                                  hinhAnh = User.hinhAnh,
                              }).Where(x => x.Email == check.Email);
                    return Ok(qr);
                }
          
            return BadRequest();


        }
    }
}
