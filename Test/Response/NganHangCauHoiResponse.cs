using AutoMapper;
using System.Security.Claims;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Response
{
    public class NganHangCauHoiResponse : INganHangCauHoi
    {
        private readonly Database db;
        private readonly IMapper mapp;
        public static int pagesize { get; set; } = 5;
        public NganHangCauHoiResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapp = mapper;
        }
       

        public string delete(string id)
        {
            
            var check = db.NganHangCauHois.SingleOrDefault(x=>x.Id==id);
            var checkch = db.CauHoiTN.SingleOrDefault(x => x.IdNganHangCauHoi == check.Id);
            if (check != null && checkch!=null)
            {
                db.NganHangCauHois.Remove(check);
                db.CauHoiTN.Remove(checkch);
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public List<DSNganHangCauHoiViewModel> GetALL(string name, int page = 1)
        {
            var check = db.NganHangCauHois.AsQueryable();
            check = check.Skip((page - 1) * pagesize).Take(pagesize);
            var ds = db.CauHoiTN.ToList();
            var kq = check.Select(x => new DSNganHangCauHoiViewModel
            {
                Id = x.Id,
                doKho = x.doKho,
                mon = x.mon,
                nguoiSoHuu = x.nguoiSoHuu,
                suaDoiLanCuoi = x.suaDoiLanCuoi,
              CauHoiTN = db.CauHoiTN.Where(a=>a.IdNganHangCauHoi ==x.Id).ToList()


            }).Where(x => x.nguoiSoHuu == name).ToList(); ;
            return kq.ToList();
        }

        public string Update(int id, CauHoiTNViewModel s)
        {
           
            var ds = db.CauHoiTN.SingleOrDefault(x => x.maCauHoiTN == id);
            if (ds != null) {



                 ds.A=s.A; ds.B=s.B; ds.C=s.C;ds.D=s.D;ds.tieuDeCauHoi=s.NoiDungCauHoi;ds.dapAnChinhXac=s.DapAnChinhXacNhat;
               

                db.Entry(ds).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public NganHangCauHoiTN Add(string id, string mon, string doKho, string name, List<CauHoiTN> S)
        {
            var ch = new NganHangCauHoiTN();
            ch.mon = mon;
            ch.doKho = doKho;
            ch.nguoiSoHuu = name;
            foreach (var x in S)
            {
                var a = new CauHoiTN();
                a.tieuDeCauHoi = x.tieuDeCauHoi;
                a.A = x.A;
                a.B = x.B;
                a.C = x.C;
                a.D = x.D;
                a.dapAnChinhXac = x.dapAnChinhXac;
                a.IdNganHangCauHoi = x.IdNganHangCauHoi;
                db.CauHoiTN.Add(a);
                db.SaveChanges();
            }
            ch.Id = id;
            ch.suaDoiLanCuoi = DateTime.Now;
            db.NganHangCauHois.Add(ch);
            db.SaveChanges();
            return ch;
        }
    }
}
