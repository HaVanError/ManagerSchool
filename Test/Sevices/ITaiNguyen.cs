using Test.Model;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface ITaiNguyen
    {
        Task<FileUploadResponse> Add(List<IFormFile> File, string maMonHoc, string tenBaiGiang, string gv, int maChuDe, int maBaiGiang);
        string Delete(string name);
        List<TaiNguyenViewModel> GetAll(string name,int page =1);
        Task<byte[]> DownloadFile(int id);
        TaiNguyen DuyetTaiNguyen(bool trangThai, int id, string ghiChu);
    }
}
