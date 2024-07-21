using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Test.DatabaseContext;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLChuDeController : ControllerBase
    {
        private readonly IChuDe chuDe;
        public QLChuDeController(IChuDe chuDe) { 
        this.chuDe = chuDe;
        }
        [HttpPost("ThemChuDeMonHoc")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Add(ChuDeDTO x)
        {
            try
            {
                return Ok(chuDe.Add(x));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("SuaChuDeMonHoc")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Update(ChuDeDTO x,int id) {

            try
            {
               
                return Ok(chuDe.Update(x, id)) ;
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("XoaChuDeMonHoc")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Delete(int id)
        {
            try
            { 
                return Ok(chuDe.Delete(id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("DanhSachChuDeMonHoc")]
        [Authorize(Roles = "GiaoVien,Admin")]
        public IActionResult Delete(string maMon)
        {
            try
            {
               
                return Ok(chuDe.GetAll(maMon));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
