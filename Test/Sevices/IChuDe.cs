using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IChuDe
    {
        ChuDeDTO Add(ChuDeDTO x);
        string Delete(int id);
        string Update(ChuDeDTO x,int id);
        List<ChuDeViewModel> GetAll(string maMon);
    }
}
