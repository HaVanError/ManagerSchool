using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLMonHocController : ControllerBase
    {
        private readonly IMonHoc mon;
        public QLMonHocController(IMonHoc mon)
        {
            this.mon = mon;
        }
        [HttpPost("ThemMonHocVaPhanCong")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(MonHocDTO monHocDTO)
        {
            try
            {
                return Ok(mon.Add(monHocDTO));
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("CapNhatLaiMonHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(MonHocViewModel x,string id)
        {
            try
            { 
                return Ok(mon.Update(x, id));
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("XoaMonHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            try
            {   
                return Ok(mon.Delete(id));
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("DanhSachMonHoc")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll(int page = 1)
        {
            try
            {
                return Ok(mon.Getall(page));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
