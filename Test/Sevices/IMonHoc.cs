using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IMonHoc
    {
        MonHocDTO Add(MonHocDTO monHocDTO);
        string Delete(string id);
        string Update(MonHocViewModel monHocDTO,string id);
        List<MonHocDTO> Getall(int page = 1);
    }
}
