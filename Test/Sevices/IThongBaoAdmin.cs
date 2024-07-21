using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IThongBaoAdmin
    {
       List<ThongBaoAdminDTO>Getall(int page =1);
        string delete(int id);
        string DeleteAll();
    }
}
