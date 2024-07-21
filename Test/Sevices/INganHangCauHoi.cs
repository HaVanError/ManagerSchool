using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface INganHangCauHoi
    {
        NganHangCauHoiTN Add(string id,string mon, string doKho, string name, List<CauHoiTN> S);
        List<DSNganHangCauHoiViewModel> GetALL(string name, int page =1);
        string Update(int id, CauHoiTNViewModel s);
        string delete(string id);



    }
}
