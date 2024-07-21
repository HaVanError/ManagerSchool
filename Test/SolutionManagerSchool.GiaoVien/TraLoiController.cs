using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraLoiController : ControllerBase
    {
        private readonly ITraLoi traLoi;
        private readonly Database db;
        public TraLoiController(ITraLoi traLoi, Database db)
        {
            this.traLoi = traLoi;
            this.db = db;   
        }
        [HttpPost("TraLoi")]
        [Authorize(Roles ="GiaoVien,HocSinh")]
        public IActionResult TraLoi(string noiDung,int maCauHoi)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                return Ok(traLoi.TraLoiCauHoi(check.Name, noiDung, maCauHoi));
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpDelete("XoaTraLoi")]
        [Authorize(Roles = "GiaoVien,HocSinh")]
        public IActionResult DeLete(int id)
        {
            try
            {
              
                return Ok(traLoi.Delete(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("CapNhatLai")]
        [Authorize(Roles = "GiaoVien,HocSinh")]
        public IActionResult Update(int id ,TraLoiDTO x)
        {
            try
            {
                
                return Ok(traLoi.Update(id, x));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
