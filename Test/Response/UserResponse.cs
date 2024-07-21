using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;
using System.Security.Claims;
using Test.Model.ModelView;

namespace Test.Response
{
    public class UserResponse : IUser
    {
        private readonly Database db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper mapper;
      
        public static int kichthuctrang { get; set; } = 5;
        public UserResponse(Database db, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        



    }

        public UserDTO Add(string id, IFormFile HinhAnh, string ten, string Email, string matKhau, string diaChi, string SoDienThoai, bool gioiTinh,int Quyen)
        {
            try
            {
                var kiemtra = db.Users.SingleOrDefault(a=>a.Email==Email);

                var mahoaPassword = BCrypt.Net.BCrypt.HashPassword(matKhau);
                var tk = new User();
                tk.Id = id;
                tk.SDT = SoDienThoai;
                tk.maQuyen = Quyen;
                tk.Email = Email;
                tk.Password = mahoaPassword;
                tk.Name = ten;
                tk.hinhAnh = HinhAnh.FileName;
                tk.gioTinh = gioiTinh;
                tk.DiaChi = diaChi;
                var check = db.Users.SingleOrDefault(x => x.Id ==id);
                if (check ==null && kiemtra ==null)
                {
                    db.Users.Add(tk);
                    db.SaveChanges();
                    return new UserDTO { Name = tk.Name, DiaChi = tk.DiaChi, SDT = tk.SDT, Email = Email, Password = tk.Password, maQuyen = tk.maQuyen };
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }


        public UserDTO GetByCase(string id)
        {

            var check = db.Users.SingleOrDefault(x => x.Id.Equals(id));
            var gt = "";
            if (check.gioTinh == true) {
                gt = "Nam";
            }
            else
            {
                gt = "Nữ";
            }
            if(check != null )
            {
                
                return new UserDTO
                {
                    Id = check.Id,
                    Name = check.Name,
                    DiaChi = check.DiaChi,
                    Email = check.Email,
                    Password = check.Password,
                    SDT = check.SDT,
                    maQuyen = check.maQuyen,
                    gioTinh = gt,
                };
            }
            return null;


        }
        public void CapLaiMatKhau(string Email)
        {
            var check = db.Users.SingleOrDefault(s => s.Email.Equals(Email));

            if (check != null)
            {
                SendEmailLayLaiMK(check.Email);
            }
        }
        public void SendEmailLayLaiMK(string emailID)
        {
            Random random = new Random();
            string s = "";
            for (int i = 0; i < 1; i++)
            {
                s = next(random, 6);
            }
            var fromEmail = new MailAddress("phuongnama121999@gmail.com", "Back_End_LMS");
            var toEmail = new MailAddress(emailID);

            var fromEmailPassword = "pketjypguhgbgjkx";
            string subject = "Hệ thống cấp lại mật khẩu cho Email :!" + emailID;

            string body = "<br/><br/>Admin đã cấp lại mật khẩu cho Email này  " +
                " Thành Công.Vui lòng đăng nhập vào hệ thống để đổi lại mật khẩu ngay Lưu ý không để lộ mật khẩu cho người khác Xin Cảm Ơn!! " +
                " <br/><br/><a href='" + s + "'>" + s + "</a> ";
            var kiemtraEmail = db.Users.SingleOrDefault(x => x.Email == emailID);
            //var kiemtraEmailGV = db.GiaoViens.SingleOrDefault(x => x.Email == emailID);
         
            if (kiemtraEmail != null )
            {
                    kiemtraEmail.Password = BCrypt.Net.BCrypt.HashPassword(s);
                    db.Entry(kiemtraEmail).State = EntityState.Modified;
                
                db.SaveChanges();
            }
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        public static string next(Random random, int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

            IEnumerable<string> string_Enumerable = Enumerable.Repeat(chars, length);
            char[] arr = string_Enumerable.Select(s => s[random.Next(s.Length)]).ToArray();

            return new string(arr);
        }
        public UserDTO UpdateAllUser(string id, IFormFile HinhAnh, string ten, string Email, string matKhau, string diaChi, string SoDienThoai, bool gioiTinh, int Quyen)
        {
            var checkuser =db.Users.SingleOrDefault(x=>x.Id == id);
            if (checkuser != null) {
                var mahoa=BCrypt.Net.BCrypt.HashPassword(matKhau);
                checkuser.Name = ten;
                checkuser.hinhAnh = HinhAnh.FileName;
                checkuser.SDT= SoDienThoai;
                checkuser.maQuyen=Quyen;
                checkuser.DiaChi = diaChi;
                checkuser.Email = checkuser.Email;
                checkuser.Password = mahoa;
                checkuser.gioTinh = gioiTinh;
                db.Entry(checkuser).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                var gt = "";
                if(checkuser.gioTinh == true)
                {
                    gt = "Nam";

                }
                else
                {
                    gt = "Nữ";

                }
                return new UserDTO
                {
                    Name = checkuser.Name,
                    DiaChi = checkuser.DiaChi,
                    SDT = checkuser.SDT,
                    
                    gioTinh = gt,
                    hinhAnh= checkuser.hinhAnh,
                    maQuyen = checkuser.maQuyen,
                    Email = checkuser.Email,
                    Password=checkuser.Password,

                };
            }return null;
           
        }

        public List<UserViewModel> GetAll(int page = 1)
        {
            var check = db.Users.AsQueryable();
            check = check.Skip((page - 1) * kichthuctrang).Take(kichthuctrang);
            //var hocSinh = db.HocSinhs.ToList();
            //var GV = db.GiaoViens.ToList();
            //var user= db.Users.ToList();
            var kqtv = check.Select(x => new UserViewModel
            {
                maNguoiDung = x.Id,
                tenNguoiDung = x.Name,
                Email = x.Email,
                vaiTro = x.Role.Name

            });

            return kqtv.ToList();
        }

        public string GetUserName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
    }
}
