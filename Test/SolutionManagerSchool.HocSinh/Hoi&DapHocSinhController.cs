using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.HocSinhController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Hoi_DapHocSinhController : ControllerBase
    {
        private readonly ICauHoi ch;
        private readonly Database db ;
        public Hoi_DapHocSinhController(ICauHoi ch, Database db)
        {
            this.ch = ch;
            this.db = db;
        }
        [HttpPost("HoiDapHocSinh")]
        [Authorize(Roles ="HocSinh")]
        public IActionResult Add(string tieuDe, string noiDung, string mon)
        {
            try
            {
                var ten = "";
                var like = false;
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                var checkM = db.MonHocs.FirstOrDefault();
                var kiemtra = db.HocSinhs.FirstOrDefault(x => x.maTK == check.Id);
                if (checkM.maLop == kiemtra.maLop)
                {
                    ten = check.Name;
                    return Ok(ch.DatCauHoi(tieuDe, ten, like, noiDung, mon));
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("DanhSachAllCauHoi&Dap")]
        [Authorize(Roles = "HocSinh")]
        public IActionResult GetALL(int page = 1)
        {
            try
            {
                return Ok(ch.GetAll(page));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
