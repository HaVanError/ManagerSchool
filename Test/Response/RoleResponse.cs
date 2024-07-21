using AutoMapper;
using Test.DatabaseContext;
using Test.Model;
using Test.Model.DTO;
using Test.Sevices;

namespace Test.Response
{
    public class RoleResponse : IRole
    {
        private readonly Database db;
        private readonly IMapper mapper;
        public RoleResponse(Database db,IMapper mapper)
        {
             this.db = db;
            this.mapper = mapper;   
        }
        public RoleDTO Add(RoleDTO role)
        {
           var map=mapper.Map<Role>(role);
            db.Roles.Add(map);
            db.SaveChanges();
            return role;
        }

        public List<RoleDTO> GetAll()
        {

           var check = db.Roles.ToList();
            var kqtv = check.Select(x => new RoleDTO
            {
                Name = x.Name,
                moTa= x.moTa,
                ngay= x.ngay,

            });
            return kqtv.ToList();
        }

        public string Remove(int id)
        {
            var check=db.Roles.FirstOrDefault(x=>x.Id == id);
            if (check != null)
            {
                db.Roles.Remove(check);
                db.SaveChanges() ;
                return "Thanh Cong";

            }
            return "Loi";
        }

        public string Update(int id, RoleDTO role)
        {
            var check = db.Roles.FirstOrDefault(x => x.Id==id);
            if (check != null)
            {
                check.Name=role.Name;
                check.moTa=role.moTa;
                check.ngay = DateTime.Now;
                db.Entry(check).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return "Thanh Cong";
            }
            return "Loi";
        }
    }
}
