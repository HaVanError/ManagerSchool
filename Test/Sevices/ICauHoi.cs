using Test.Model;
using Test.Model.DTO;

namespace Test.Sevices
{
    public interface ICauHoi
    {
        CauHoiDTO DatCauHoi(string tieuDe,string nguoiDatCauHoi,bool like,string noiDung,string mon);
        List<ListHoiDap> GetAllHoiDap(string name,int page = 1);
        List<ListHoiDap> GetAll( int page = 1);
        string Delete(int id);
        string Update(CauHoiDTO x , int id );
        string Like(int id ,bool Like);

    }
}
