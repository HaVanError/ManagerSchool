using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;
using Test.Sevices;

namespace Test.Response
{
    public class MonHocResponse : IMonHoc
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public static int pagesize { get; set; } = 5;
        public MonHocResponse(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public MonHocDTO Add(MonHocDTO monHocDTO)
        {
            var map = mapper.Map<MonHoc>(monHocDTO);
            map.NgayTao = DateTime.Now;
            var check = db.MonHocs.FirstOrDefault(x => x.maMonHoc == map.maMonHoc);
            if (check == null)
            {
                db.MonHocs.Add(map);
                db.SaveChanges();return monHocDTO;
            }
            return null;
        }

        public string Delete(string id)
        {
           var checkMonHoc=db.MonHocs.FirstOrDefault(x=>x.maMonHoc.Equals(id));
            if(checkMonHoc != null)
            {
                db.MonHocs.Remove(checkMonHoc);
                db.SaveChanges() ;
                return "Thanh Cong";
            }
            return "Loi";
        }

        public string Update(MonHocViewModel monHocDTO, string id)
        {
            var checkMonHoc = db.MonHocs.FirstOrDefault(x => x.maMonHoc.Equals(id));
            if( checkMonHoc != null)
            {
                checkMonHoc.tenMonHoc = monHocDTO.tenMonHoc;
                checkMonHoc.moTa = monHocDTO.moTa;
                //checkMonHoc.maHocSinh= monHocDTO.maHocSinh;
                checkMonHoc.maGiaoVien = monHocDTO.maGiaoVien;
                checkMonHoc.NgayTao = DateTime.Now;
                db.Entry(checkMonHoc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges() ;

                return "Thanh Cong";
            }
            return "Loi";
        }
        public List<MonHocDTO> Getall(int page = 1)
        {
            var check = db.MonHocs.AsQueryable();
            check = check.Skip((page - 1) * pagesize).Take(pagesize);
            var kq = check.Select(x => new MonHocDTO
            {
                maMonHoc =x.maMonHoc,   
               tenMonHoc = x.tenMonHoc,
               maGiaoVien=x.maGiaoVien,
               maLop = x.maLop,
              moTa = x.moTa 
            }).ToList();
            return kq.ToList();
        }

    }
}
