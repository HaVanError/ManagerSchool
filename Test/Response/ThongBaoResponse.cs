using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Response
{
    public class ThongBaoResponse : IThongBao
    {
        private readonly Database db; 
        private readonly IMapper mapper;
        public static int pagesize { get; set; } = 5;
        public ThongBaoResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public string Delete(int id)
        {
           var check = db.ThongBaos.FirstOrDefault(x=>x.maThongBao==id);
            if (check != null)
            { 
                db.ThongBaos.Remove(check); 
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }
        public List<ThongBaoViewModel> ThongBaoList(int page =1)
        {
            var check = db.ThongBaos.AsQueryable();
            check = check.Skip((page-1)*pagesize).Take(pagesize);
            var kq = check.Select(x => new ThongBaoViewModel
            {
               tieuDe = x.tieuDeThongBao
            }).ToList();
            return kq.ToList();
        }
        public string DeleteAll()
        {
           var check = db.ThongBaos.ToList();
            if (check.Count > 0)
            {


                foreach (var x in check)
                {
                    db.ThongBaos.Remove(x);
                }
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public ThongBao_LopViewModel themThongBaoChoLop(ThongBao_LopViewModel thongBaoDTO)
        {
            var mapp = mapper.Map<ThongBao>(thongBaoDTO);
            var list = db.HocSinhs.ToList();
            db.ThongBaos.Add(mapp);
            db.SaveChanges();
            return thongBaoDTO;
        }
    }
}
