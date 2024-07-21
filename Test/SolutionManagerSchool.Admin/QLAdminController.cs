using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.AdminF
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLAdminController : ControllerBase
    {
        private readonly IUser user;
        private readonly IAdmin admin;
        private readonly Database db;
        private readonly IMapper mapper;

        public QLAdminController(IUser _user, IAdmin _admin, Database _db, IMapper _mapper)
        {
            user = _user;
            admin = _admin;
            db = _db;
            mapper = _mapper;
        }
        [HttpPost("TaoTaiKhoanChoNguoiDung")]
       // [Authorize(Roles = "Admin")]
        public IActionResult Add(string id, IFormFile HinhAnh, string ten, string Email, string matKhau, string diaChi, string SoDienThoai, bool gioiTinh, int vaitro)
        {
                if (ModelState.IsValid)
                {
                    return Ok(user.Add(id, HinhAnh, ten, Email, matKhau, diaChi, SoDienThoai, gioiTinh, vaitro));
                }
                else { return BadRequest(); }    
        }

        [HttpGet("DanhSachTaiKhoan")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllDS(int page = 1)
        {
            return Ok(user.GetAll(page));
        }

        [HttpGet("GetByIDAndName")]
        [Authorize(Roles = "Admin")]
        public IActionResult Getby(string id)
        {
            try
            {
                return Ok(user.GetByCase(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ThemTKAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult ThemTKAdmin(AdminDTO x)
        {
            try
            {
                var themAdmin = admin.AddAdmin(x);
                return Ok(themAdmin);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("ThayDoiHinhAnhAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateHinhAnhAdmin(IFormFile file, string id)
        {
            try
            {
               
                return Ok(admin.UpdateAdmin(file, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpDelete("XoaTKAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTKAdmin(string id)
        {
            try
            {
            
                return Ok(admin.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost("DoiMatKhau_Admin_GV_HS")]
        [Authorize]
        public IActionResult SuaMatKhau(string passCu, string mkmoi, string nhaplaiMKM)
        {
            var check = db.Users.SingleOrDefault(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
            var dto = mapper.Map<User>(check);

            if (check != null && BCrypt.Net.BCrypt.Verify(passCu, check.Password))
            {
                if (mkmoi == nhaplaiMKM)
                {
                    var mahoapassMoi = BCrypt.Net.BCrypt.HashPassword(mkmoi);
                    check.Password = mahoapassMoi;
                    db.Entry(check).State = EntityState.Modified;
                    db.SaveChanges();
                    Response.Cookies.Delete("jwtCookie");
                    return Ok("Thay Doi Mat Khau Thanh Cong");
                }
            }
            return BadRequest();
        }

        [HttpPost("SendMailCapLaiMK_Admin_HS_GV")]
        public IActionResult SenMailCapLaiMK(string Email)
        {
            try
            {
                var check = db.Users.SingleOrDefault(x => x.Email.Equals(Email));
                if (check == null)
                {
                    return BadRequest("Không thể gửi Mail !!");
                }
                else
                {
                    user.CapLaiMatKhau(Email);
                    return Ok("Da Gui Mail Cho Nguoi Yeu Cau Co TK Email   :" + Email + "Vui Long Vao Gmail De Kiem Tra Hom Thu Va Nhanh Cong Doi Mat Khau");
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("CapNhatToanBoUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateALL(string id, IFormFile HinhAnh, string ten, string Email, string matKhau, string diaChi, string SoDienThoai, bool gioiTinh, int vaitro)
        {
            try
            {
                return Ok(user.UpdateAllUser(id,HinhAnh,ten,Email,matKhau,diaChi,SoDienThoai,gioiTinh,vaitro));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("NameLogin")]
        [Authorize]
        public IActionResult GetName() {

            return Ok(user.GetUserName());
        }
        
    }
}
