using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class KhoaResponse : IKhoa
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public static int pagesize { get; set; } = 5;
        public KhoaResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public KhoaDTO Add(KhoaDTO dto)
        {
             var map = mapper.Map<Khoa>(dto);
            var checkKhoa= db.Khoas.FirstOrDefault(x=>x.maKhoa==map.maKhoa);
            if(checkKhoa!=null)
            {
                return null;

            }
            db.Khoas.Add(map);
            db.SaveChanges();
            return dto;
        }

        public string Delete(string id)
        {
          var check = db.Khoas.SingleOrDefault(x=>x.maKhoa==id);
            if(check!=null)
            {
                db.Khoas.Remove(check);
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public List<KhoaDTO> GetAll(int page = 1)
        {
            var check = db.Khoas.AsQueryable();
            check = check.Skip((page-1)*pagesize).Take(pagesize);
            var kqtv = check.Select(x => new KhoaDTO
            {
                maKhoa = x.maKhoa,
                tenKhoa = x.tenKhoa,
            }).ToList();
            return kqtv.ToList();
        }

        public string update( string id,string tenKhoa)
        {
            
           var check = db.Khoas.SingleOrDefault(x=>x.maKhoa == id);
            if(check!=null)
            {
                check.tenKhoa = tenKhoa;
                db.Entry(check).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges() ;return "Thanh Cong";
            }
            return "Loi";
        }
    }
}
