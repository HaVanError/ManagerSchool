using Test.Model;
using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IGiaoVien
    {
        GiaoVienDTO Add(GiaoVienDTO x);
        string Update(IFormFile HinhAnh, string id);
        string Delete(string id);

    }
}
