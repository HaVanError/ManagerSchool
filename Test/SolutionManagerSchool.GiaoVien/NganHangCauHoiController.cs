using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NganHangCauHoiController : ControllerBase
    {
        private readonly INganHangCauHoi nh;
        public readonly Database db; 
        public NganHangCauHoiController(INganHangCauHoi nh, Database db)
        {
            this.nh = nh;
            this.db = db;
        }
        [HttpPost("ThemNganHangCauHoi")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Add(string id,string mon , string doKho, [FromBody]List<CauHoiTN> s)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                return Ok(nh.Add(id, mon, doKho, check.Name, s));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("XemDSNganHangCH")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult GetllAll(int page = 1)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                return Ok(nh.GetALL(check.Name, page));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
           
        }
        [HttpDelete("Xoa")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Delete (string id)
        {
            try
            {
                
                return Ok(nh.delete(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("CapNhat")]
        [Authorize(Roles = "GiaoVien")]
        public async Task<IActionResult> Capnhat(int id, [FromBody] CauHoiTNViewModel s)
        {
            try
            {
              
                return Ok(nh.Update(id, s));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
