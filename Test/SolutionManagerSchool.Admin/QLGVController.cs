using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model.DTO;
using Test.Response;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLGVController : ControllerBase
    {
        private readonly IGiaoVien gv;
        private readonly IUser user;
        public QLGVController(IGiaoVien _gv, IUser _user)
        {
            gv = _gv;
            user = _user;
        }
        [HttpPost("ThemGV")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemGV(GiaoVienDTO x)
        {
            try
            {
                var themgv = gv.Add(x);

                return Ok(themgv);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpDelete("XoaTaiKhoanGV")]
        [Authorize(Roles = "Admin")]
        public IActionResult Xoa(string id)
        {
            try
            {
                
                return Ok(gv.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
       
    }
}
