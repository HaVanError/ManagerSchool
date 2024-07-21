using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Sevices;

using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Reflection.PortableExecutable;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeThiVaKTController : ControllerBase
    {
        private readonly IDeThi_KiemTra dt;
        private readonly Database db;

        public DeThiVaKTController(IDeThi_KiemTra dt, Database db)
        {
            this.dt = dt;
            this.db = db;
        }
        
        [HttpGet("DS")]
        [Authorize(Roles = "GiaoVien,Admin")]
      
        public IActionResult getALL(int page=1)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                return Ok(dt.getAll(check.Name, page));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("XemChiTiet")]
        [Authorize(Roles = "GiaoVien,Admin")]
        public async Task<IActionResult> XemChiTiet(int id)
        {
            try
            {
                var dethi = dt.XemChiTietDeThi(id);
                string Filename = dethi.TenBaiThi + ".pdf";
                return File(dethi.Content.ToArray(), "application/pdf", Filename);
            }
            catch(Exception ex)
            {
                return BadRequest("Loi");
            }
        }
        [HttpPost("ThemDeThiTuLuan")]
        [Authorize(Roles = "GiaoVien")]
        public async Task<IActionResult> DethiTuLuan(string TenBaiThi,string mon,string hinhThuc, [FromBody] List<TuLuan> s ,string gio , string phut)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                return Ok(dt.themDeThiTuLuan(TenBaiThi, mon, hinhThuc, s, gio, phut));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        } 
        [HttpPost("ThemDeThiTracNghiem")]
        [Authorize(Roles = "GiaoVien")]
        public async Task<IActionResult> DethiNghiem(string TenBaiThi, string mon, string hinhThuc, [FromBody] List<CauHoiTracNghiem> s, string gio, string phut)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
                return Ok(dt.themDeThiTracNghiem(TenBaiThi, mon, hinhThuc, s, gio, phut));
            }
            catch(Exception x)
            {
                return BadRequest(x.Message);
            }
           
        }
    }
}
