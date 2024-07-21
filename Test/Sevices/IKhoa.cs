using System.Xml.Serialization;
using Test.Model.DTO;

namespace Test.Sevices
{
    public interface IKhoa
    {
        KhoaDTO Add(KhoaDTO dto);
        string Delete(string id);
        string update(string id,string tenKhoa);
        List<KhoaDTO> GetAll(int page=1);
    }
}
