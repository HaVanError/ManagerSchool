using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.GiaoVienController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiGiangController : ControllerBase
    {
        private readonly IBaiGiang baiGiang;
        private readonly IThongBao thong;
        private readonly Database db; 

        public BaiGiangController(IBaiGiang baiGiang, IThongBao thong, Database _db)
        {
            this.baiGiang = baiGiang;
            this.thong = thong;
            db = _db;
        }
        [HttpPost("ThemBaiGiang")]
        [Authorize(Roles ="GiaoVien")]
        public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files,string maMonHoc,string tenBaiGiang,int maChuDe)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
          
            var uploadResponse = await baiGiang.UploadFile(files,maMonHoc,tenBaiGiang,check.Email,maChuDe);
            if (uploadResponse.ErrorMessage != "")
                return BadRequest(new { error = uploadResponse.ErrorMessage });
            return Ok(uploadResponse);
        }
        [HttpGet("DownTheoId")]
        [Authorize(Roles = "GiaoVien,Admin")]
        
        public async Task<IActionResult> DownloadFile(int id)
        {
            var stream = await baiGiang.DownloadFile(id);
            if (stream == null)
                return NotFound();
            return new FileContentResult(stream, "application/octet-stream");
        }
        
        [HttpGet("XemDanhSachBaiGiang")]
        [Authorize(Roles = "GiaoVien")]
      
        public async Task<IActionResult> DanhSachBaiGiangGV(int page=1)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

                return Ok(baiGiang.GetALl(check.Name, page));
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
           
        }
        [HttpDelete("Xoa Bai Giang")]
        [Authorize(Roles = "GiaoVien")]
        public IActionResult Remove(string ten)
        {
            try
            {
                return Ok(baiGiang.Delete(ten));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
