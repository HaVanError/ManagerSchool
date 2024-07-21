using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class ThongBaoAdminResponse : IThongBaoAdmin
    {
        private readonly Database db;
        //private readonly IMapper map;
        public static int pageSize { get; set; } = 5;
        public ThongBaoAdminResponse(Database db) { this.db = db; }
        public List<ThongBaoAdminDTO> Getall(int page =1)
        {
           var check = db.ThongBaoAdmins.AsQueryable();
            check = check.Skip((page-1)*pageSize).Take(pageSize);
            var kq = check.Select(x => new ThongBaoAdminDTO
            {
                tieuDeThongBao = x.tieuDe
            });
            return kq.ToList();
        }

        public string delete(int id)
        {
            var check = db.ThongBaoAdmins.SingleOrDefault(x => x.maTBaoAdmin == id);
            if (check != null)
            {
                db.ThongBaoAdmins.Remove(check);
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }

        public string DeleteAll()
        {
            List<ThongBaoAdmin> ds = new List<ThongBaoAdmin>();
            if (ds.Count > 0)
            {


                foreach (var id in db.ThongBaoAdmins)
                {
                    db.ThongBaoAdmins.Remove(id);
                    db.SaveChanges();

                }
                return "Thanh Cong";
            }return "Loi";

        }
    }
}
