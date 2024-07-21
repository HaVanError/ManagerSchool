using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLQuyenController : ControllerBase
    {
        private readonly IRole role; 
        public QLQuyenController(IRole role)
        {
            this.role = role;
        }
        [HttpPost("ThemQuyen")]
        //[Authorize(Roles ="Admin")]
        public IActionResult Add(RoleDTO roled)
        {
            try
            {
                return Ok(role.Add(roled));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("DsQuyen")]
        [Authorize(Roles = "Admin")]
        public IActionResult Getall()
        {
            try
            {
                return Ok(role.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateQuyen")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id,RoleDTO roled)
        {
            try
            {
                
                return Ok(role.Update(id, roled));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("XoaQuyen")]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            try
            {
              
                return Ok(role.Remove(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
