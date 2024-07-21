using Test.Model.DTO;

namespace Test.Sevices
{
    public interface ITraLoi
    {
        TraLoiDTO TraLoiCauHoi(string tenNguoiTL,string NoiDung,int maCauHoi);
        string Update(int id , TraLoiDTO x);
        string Delete(int id);
    }
}
