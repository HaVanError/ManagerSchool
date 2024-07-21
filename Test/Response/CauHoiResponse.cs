using AutoMapper;
using System.Dynamic;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class CauHoiResponse : ICauHoi
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public static int pagesize { get; set; } = 5;
        public CauHoiResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public CauHoiDTO DatCauHoi(string tieuDe, string nguoiDatCauHoi, bool like, string noiDung,string mon)
        {
            try
            {
              var cauHoi = new CauHoi();
                cauHoi.TenBai = tieuDe;
                cauHoi.noiDungCauHoi=noiDung;
                cauHoi.NguoiBinhLuan = nguoiDatCauHoi;
                cauHoi.ngay = DateTime.Now;
                cauHoi.thich = false;
                cauHoi.Mon = mon;
                db.CauHois.Add(cauHoi);
                var thongBao = new ThongBao();
                thongBao.tieuDeThongBao = nguoiDatCauHoi + "Da them Cau hoi Vao mon Hoc " + cauHoi.MonHoc.tenMonHoc;
                thongBao.TenNguoiThongBao = nguoiDatCauHoi;
                db.ThongBaos.Add(thongBao);
                db.SaveChanges();
                return new CauHoiDTO
                {
                    nguoiBinhLuan = cauHoi.NguoiBinhLuan,
                    TenBai = cauHoi.TenBai,
                    noiDungCauHoi = cauHoi.noiDungCauHoi,
                    thich =cauHoi.thich,
                   ngay = cauHoi.ngay,
                   Mon = cauHoi.Mon
                   
                };
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        public List<ListHoiDap> GetAll(int page = 1)
        {
            var check = db.CauHois.AsQueryable();
            check = check.Skip((page - 1) * pagesize).Take(pagesize);
            var kq = check.Select(x => new ListHoiDap
            {
                tieuDe = x.TenBai,
                noiDungCauHoi = x.noiDungCauHoi,
                ngayHoi = x.ngay,
                tenNguoiHoi = x.NguoiBinhLuan,
                traLois = db.TraLois.Where(a=>a.maCauHoi == x.maCauHoi).ToList(),
            }).ToList();

            return kq.ToList();


        }

        public string Delete(int id)
        {
            var check = db.CauHois.SingleOrDefault(x => x.maCauHoi == id);
            if (check != null)
            {

                var thongBao = new ThongBao();
                thongBao.tieuDeThongBao = check.NguoiBinhLuan + "Da Xoa Cau Hoi";
                thongBao.TenNguoiThongBao = check.NguoiBinhLuan;
                db.ThongBaos.Add(thongBao);
                db.CauHois.Remove(check);
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public string Update(CauHoiDTO x, int id)
        {
          var check = db.CauHois.SingleOrDefault(x=>x.maCauHoi == id);
            if(check != null)
            {
                check.ngay= DateTime.Now;
                check.noiDungCauHoi = x.noiDungCauHoi;
                check.TenBai = x.TenBai;
                db.Entry(check).State=Microsoft.EntityFrameworkCore.EntityState.Modified; db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public string Like(int id, bool Like)
        {
            var check = db.CauHois.SingleOrDefault(x => x.maCauHoi == id);
            if (check != null)
            {
                check.thich = Like;
                var ThongBao = new ThongBao();
                if (Like == true)
                {
                   
                    ThongBao.tieuDeThongBao = check.NguoiBinhLuan + "Da thich Binh Cau Hoi";
                    ThongBao.TenNguoiThongBao = check.NguoiBinhLuan;
                  
                }
                else
                {
                    
                    ThongBao.tieuDeThongBao = check.NguoiBinhLuan + "Da Bo thich Binh Cau Hoi";
                    ThongBao.TenNguoiThongBao = check.NguoiBinhLuan;
                 
                }
                db.ThongBaos.Add(ThongBao);    
                db.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges() ;
                return "Thanh Cong";
            }
            return "Loi";
        }
        public List<ListHoiDap> GetAllHoiDap(string name, int page = 1)
        {
            var check = db.CauHois.AsQueryable();
            check = check.Skip((page-1)*pagesize).Take(pagesize);
            var gv = db.GiaoViens.Where(x => x.user.Name == name).SingleOrDefault();
            if(gv != null)
            {
              var kt=   check.SingleOrDefault(x => x.NguoiBinhLuan == gv.user.Name);
                if(kt!= null)
                {
                    var kq = check.Select(x => new ListHoiDap
                    {
                        tieuDe = x.TenBai,
                        noiDungCauHoi = x.noiDungCauHoi,
                        ngayHoi = x.ngay,
                        tenNguoiHoi = x.NguoiBinhLuan,

                        traLois = db.TraLois.Where(b => b.maCauHoi == x.maCauHoi).ToList(),

                    }).ToList();
                    return kq.ToList();
                }
            }
            return null ;
            
          
        }
        }
    }
