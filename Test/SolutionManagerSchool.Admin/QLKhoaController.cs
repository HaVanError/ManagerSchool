using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLKhoaController : ControllerBase
    {
        private readonly IKhoa khoa;
        public QLKhoaController(IKhoa khoa)
        {
            this.khoa = khoa;
        }
        [HttpPost("ThemKhoa")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(KhoaDTO x)
        {
            try
            {
                return Ok(khoa.Add(x));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("DanhSachKhoa")]
        public IActionResult getAll(int page=1)
        {
            try
            {
                return Ok(khoa.GetAll(page));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("CapNhatKhoa")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(string id,string TenKhoa)
        {
            try
            {
              
                return Ok(khoa.update(id, TenKhoa));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Xoa Khoa")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            try
            {  
                return Ok(khoa.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
