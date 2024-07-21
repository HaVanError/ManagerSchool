using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class GiaoVienResponse : IGiaoVien
    {
        private readonly Database db; 
        private readonly IMapper mapper;
        private readonly IUser user;
        public GiaoVienResponse(Database db,IMapper mapper, IUser _user) {  this.db = db;this.mapper = mapper;  user=_user; }
       

        public GiaoVienDTO Add(GiaoVienDTO x )
        {
         
            var map = mapper.Map<GiaoVien>(x);        
            var check = db.GiaoViens.FirstOrDefault(x => x.maGiaoVien == map.maGiaoVien);
            var checkuse = db.GiaoViens.FirstOrDefault(x => x.maTK == map.maTK);
            if ( check == null && checkuse == null )
            {
                db.GiaoViens.Add(map);
                db.SaveChanges();
                return x;
            }
            return null;

        }
        public string Delete(string id)
        {
            var checkgv = db.GiaoViens.SingleOrDefault(x=>x.maGiaoVien.Equals(id));
            var checkTK = db.Users.SingleOrDefault(a => a.Id == checkgv.maTK);
            if (checkgv != null )
            {
                db.GiaoViens.Remove(checkgv);
                if(checkTK != null)
                {
                    db.Users.Remove(checkTK);
                }
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public string Update(IFormFile HinhAnh, string id)
        {
            var checkGv = db.GiaoViens.SingleOrDefault(x => x.maGiaoVien.Equals(id));
            var checkUser = db.Users.SingleOrDefault(a => a.Id == checkGv.maTK);
            if (checkGv != null)
            {
              
               if(checkUser != null)
                {
                    checkUser.hinhAnh = HinhAnh.FileName;
                    db.Entry(checkGv).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return "Thanh Cong";
                }
               
            }
            return "Loi";
        }
    }
}
