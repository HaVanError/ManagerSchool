using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Response
{
    public class ChuDeResponse : IChuDe
    {
        private readonly Database db; 
        private readonly IMapper mapper;
        public ChuDeResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public ChuDeDTO Add(ChuDeDTO x)
        {
            var map= mapper.Map<ChuDe>(x); 
                db.ChuDes.Add(map);
                db.SaveChanges();
                return x;              
        }
        public string Delete(int id)
        {
            var checkChuDe= db.ChuDes.FirstOrDefault(x=>x.Id== id);
            if(checkChuDe!=null)
            {
                db.ChuDes.Remove(checkChuDe);
                db.SaveChanges();
                return "Thanh Cong";
            }
            return " LOi";
        }

        public List<ChuDeViewModel> GetAll(string maMon)
        {
           //var checkchuDe = db.ChuDes.AsQueryable();
            var kqtv =db.ChuDes.FirstOrDefault(x=>x.maMonHoc.Equals(maMon));
            if (kqtv != null)
            {
                var kq = db.ChuDes.Select(x=>new ChuDeViewModel
                {
                    tieuDe= x.tieuDe,
                    noiDung=x.NoiDung,

                });return kq.ToList();

             
            }
            return null ;
        }

        public string Update(ChuDeDTO x ,int id)
        {
            var checkChuDe=db.ChuDes.FirstOrDefault(x=>x.Id==id);
            if(checkChuDe!=null)
            {
                checkChuDe.tieuDe=x.tieuDe;
                checkChuDe.NoiDung=x.NoiDung;
                checkChuDe.maMonHoc=x.maMonHoc;
                db.Entry(checkChuDe).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

       
    }
}
