using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyetBaiGiangController : ControllerBase
    {
        private readonly IBaiGiang bg;
        
        public DuyetBaiGiangController(IBaiGiang bg)
        {
            this.bg = bg;
          
        }
        [HttpPost("DuyetBaiGiang")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>Duyet( bool trangThai,int id, string ghiChu)
        {
            try
            {
                var duyetBai=  bg.DuyetBai(trangThai, id,ghiChu);
                return Ok("Da duyet bai giang thanh cong");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("DanhSachBaiGiang")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getALL(int page = 1)
        {
            try
            {
                var ds = bg.GetALlAdmin(page);
                return Ok(ds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
