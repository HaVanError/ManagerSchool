using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyetTaiNguyenController : ControllerBase
    {
        private readonly ITaiNguyen tn; 
        public DuyetTaiNguyenController(ITaiNguyen tn)
        {
            this.tn = tn;
        }
        [HttpPut("DuyetTaiNguyen")]
        [Authorize(Roles ="Admin")]
        public IActionResult Duyet(bool trangThai,int id,string ghiChu)
        {
            try
            {
                var duyetBai = tn.DuyetTaiNguyen(trangThai, id, ghiChu);
                return Ok("Da duyet bai giang thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
