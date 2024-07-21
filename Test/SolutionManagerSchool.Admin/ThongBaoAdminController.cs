using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoAdminController : ControllerBase
    {
        private readonly IThongBaoAdmin tb;
        public ThongBaoAdminController(IThongBaoAdmin tb) { 
        this.tb = tb;
        }
        [HttpGet("ThongBao")]
        [Authorize(Roles ="Admin")]
        public IActionResult Gell(int page = 1)
        {
            try
            {
                return Ok(tb.Getall(page));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           

        }
        [HttpDelete("XoaThongBao")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                
                return Ok(tb.delete(id));
            }
           catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("XoaTatCaThongBao")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAll()
        {
            try
            {
               
                return Ok(tb.DeleteAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
