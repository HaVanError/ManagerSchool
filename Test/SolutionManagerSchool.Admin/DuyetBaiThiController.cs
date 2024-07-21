using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuyetBaiThiController : ControllerBase
    {
        private readonly IDeThi_KiemTra dt;
        public DuyetBaiThiController(IDeThi_KiemTra _dt)
        {
           dt = _dt;
        }
        [Authorize(Roles ="Admin")]
        [HttpPut]
        public IActionResult DuyetBaiThi(string trangThai, int id)
        {
            
            return Ok(dt.DuyetBai(id, trangThai));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("DanhSachDeThi")]
        public IActionResult GetAll(int page = 1)
        {
          
            return Ok(dt.getAllDTAdmin(page));
        }
    }
}
