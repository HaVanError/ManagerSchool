using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class TraLoiResponse : ITraLoi
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public TraLoiResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;

        }
        public string Delete(int id)
        {
            var check = db.TraLois.FirstOrDefault(x=>x.maTl==id);
            if (check != null)
            {
                db.TraLois.Remove(check);
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }
        public TraLoiDTO TraLoiCauHoi(string tenNguoiTL, string NoiDung, int maCauHoi)
        {
            try
            {
               var tl = new TraLoi();
                tl.tenNguoiTraLoi = tenNguoiTL;
                tl.maCauHoi = maCauHoi;
                tl.NoiDung = NoiDung;
                tl.ngay = DateTime.Now;
                db.TraLois.Add(tl);
                var thongBao = new ThongBao();
                thongBao.tieuDeThongBao = tl.tenNguoiTraLoi + "Da tra Loi Cau Hoi" + tl.maCauHoi;
                thongBao.TenNguoiThongBao = tl.tenNguoiTraLoi;
                db.ThongBaos.Add(thongBao);
                db.SaveChanges();
                return new TraLoiDTO
                {
                    tenNguoiTraLoi = tl.tenNguoiTraLoi,
                    NoiDung = tl.NoiDung,
                    maCauHoi = tl.maCauHoi

                };
               
            }catch (Exception ex)
            {
                return null;
            }
        
        }

        public string Update(int id, TraLoiDTO x)
        {
            
                var check = db.TraLois.FirstOrDefault(x=>x.maTl == id);
                if (check != null)
                {
                    check.NoiDung = x.NoiDung;
                    db.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified; db.SaveChanges();
                    return "Thanh Cong";
                }
                return "Loi";
            
        }
    }
}
