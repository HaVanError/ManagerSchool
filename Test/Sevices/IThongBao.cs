using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IThongBao
    {

        List<ThongBaoViewModel> ThongBaoList(int page = 1);
        ThongBao_LopViewModel themThongBaoChoLop (ThongBao_LopViewModel thongBaoDTO/*, List<HocSinh> hocsinh*/);
        string Delete(int id);
        string DeleteAll();
    }
}
