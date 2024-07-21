using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class AdminResponse : IAdmin
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public static int pagesize { get; set; } = 5;
        public AdminResponse (Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public AdminDTO AddAdmin(AdminDTO adminDTO)
        {
          var map= mapper.Map<Admin>(adminDTO);
          
            var check = db.Admins.FirstOrDefault(x => x.IDAdmin == map.IDAdmin);
            var checkuser = db.Admins.FirstOrDefault(a => a.maTK == map.maTK);
           if(check == null && checkuser== null)
            {

                db.Admins.Add(map);
                db.SaveChanges();
                return adminDTO;
            }return null;
        }

        public string Delete(string id)
        {
            var checkAdmin= db.Admins.SingleOrDefault(s=>s.IDAdmin.Equals(id));
            var checkTK = db.Users.SingleOrDefault(x => x.Id == checkAdmin.maTK);
            if(checkAdmin != null)
            {
                db.Admins.Remove(checkAdmin);
                if (checkTK != null)
                {
                    db.Users.Remove(checkTK);
                  
                }
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "That Bai";

        }



        public string UpdateAdmin(IFormFile file, string id)
        {
            var checkAdmin = db.Admins.SingleOrDefault(x => x.IDAdmin.Equals(id));
            var checkUser = db.Users.SingleOrDefault(a => a.Id.Equals(checkAdmin.maTK));
            if (checkAdmin != null)
            {

                if (checkUser != null)
                {
                    checkUser.hinhAnh = file.FileName;
                    db.Entry(checkUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                   
                }
                return "Thanh Cong";
            }
            return "That Bai";
        }
    }
}
