using Test.Model;
using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IAdmin
    {
        AdminDTO AddAdmin(AdminDTO adminDTO);
        string UpdateAdmin(IFormFile file,string id);
        string Delete(string id);
      
       

    }
}
