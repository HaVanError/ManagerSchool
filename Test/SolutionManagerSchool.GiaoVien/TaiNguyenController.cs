using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.Model;
using Test.DatabaseContext;
using Microsoft.AspNetCore.Authorization;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiNguyenController : ControllerBase
    {
        private readonly ITaiNguyen tn;
        private readonly Database db;
        public TaiNguyenController(ITaiNguyen tn,Database db)
        {
            this.tn = tn;
            this.db = db;
        }
        [HttpPost("ThemTaiNguyen")]
        [Authorize(Roles ="GiaoVien")]
        public async Task<IActionResult> Add([FromForm] List<IFormFile> files, string maMonHoc, string tenTaiNguyen, int maChuDe,int maBaiGiang)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                var uploadResponse = await tn.Add(files, maMonHoc, tenTaiNguyen, check.Email, maChuDe, maBaiGiang);
                if (uploadResponse.ErrorMessage != "")
                    return BadRequest(new { error = uploadResponse.ErrorMessage });
                return Ok(uploadResponse);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete("XoaTaiNguyen")]
        [Authorize(Roles = "GiaoVien")]
        public  IActionResult Delete(string ten)
        {
            try
            {
                return Ok(tn.Delete(ten));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("DanhSachTaiNguyen")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult GetAll(int page = 1)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                return Ok(tn.GetAll(check.Name, page));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
