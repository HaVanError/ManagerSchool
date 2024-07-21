using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private readonly IThongBao thongBao;
        public ThongBaoController(IThongBao thongBao)
        {
            this.thongBao = thongBao;
        }
        [HttpGet("DanhSachThongBao")]
        [Authorize(Roles ="GiaoVien")]
        public IActionResult getAll(int page=1)
        {
            try
            {
                return Ok(thongBao.ThongBaoList(page));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("XoaTheoMa")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult delete(int id)
        {
            try
            {
               
                return Ok(thongBao.Delete(id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "GiaoVien")]
        [HttpDelete("XoaToanBoThongBao")]
        public IActionResult Deleteall()
        {
            try
            {
               
                return Ok(thongBao.DeleteAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("ThemThongBaoChoLop")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Add(ThongBao_LopViewModel x)
        {
            try
            {
                return Ok(thongBao.themThongBaoChoLop(x));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
