using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface ILop
    {
        LopDTO Add(LopDTO x);
        string Update(string id, LopViewModel x);
        string Delete(string id);
        List<LopDTO> Getall(int page= 1);
    }
}
