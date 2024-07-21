using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLUpdateGVController : ControllerBase
    {
        private readonly IGiaoVien gv;
        public QLUpdateGVController(IGiaoVien gv)
        {
            this.gv = gv;
        }

        [HttpPut("ThayDoiHinhAnhGV")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult suaHinhAnh(IFormFile File, string id)
        {
            try
            {
               
                return Ok(gv.Update(File, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
