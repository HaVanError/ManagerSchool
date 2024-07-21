using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class HocSinhResponse : IHocSinh
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public HocSinhResponse(Database _db, IMapper _mapper) { db = _db; mapper = _mapper; }
        public HocSinhDTO Add(HocSinhDTO x)
        {
                var maphs= mapper.Map<HocSinh>(x);
                db.HocSinhs.Add(maphs);
            var checkhs= db.HocSinhs.FirstOrDefault(a=>a.maHocSinh==maphs.maHocSinh);
            var checkuse = db.HocSinhs.FirstOrDefault(x => x.maTK == maphs.maTK);

            if (checkhs == null && checkuse == null)
            {
                db.HocSinhs.Add(maphs);
                db.SaveChanges();
                return x;
            }return null;

        }
        public string Delete(string id)
        {
            var checkhs = db.HocSinhs.SingleOrDefault(x => x.maHocSinh.Equals(id));
            var checkuser = db.Users.SingleOrDefault(x => x.Id == checkhs.maTK);
            if (checkhs != null )
            {
                db.HocSinhs.Remove(checkhs);
                if (checkuser != null)
                {
                    db.Users.Remove(checkuser);
                }
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }
        public string Update(IFormFile HinhAnh, string id)
        {
           var checkhs = db.HocSinhs.SingleOrDefault(x=> x.maHocSinh.Equals(id));
            var checkuser = db.Users.SingleOrDefault(a => a.Id == checkhs.maTK);
            if (checkhs != null)
            { if(checkuser != null)
                {
                    checkuser.hinhAnh = HinhAnh.FileName;
                    db.Entry(checkuser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return "Thanh Cong";
                }
               
            }
            return "Loi";
        }
    }
}
