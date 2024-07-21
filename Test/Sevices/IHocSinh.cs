using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IHocSinh
    {
        HocSinhDTO Add(HocSinhDTO x);
        string Update(IFormFile HinhAnh, string id);
        string Delete(string id);
    }
}
