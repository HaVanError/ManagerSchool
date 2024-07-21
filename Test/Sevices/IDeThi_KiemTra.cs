
using Microsoft.AspNetCore.Mvc;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IDeThi_KiemTra
    {
        DeThi themDeThiTuLuan(string TenBaiThi, string mon, string hinhThuc,  List<TuLuan> s, string gio, string phut);
        DeThi themDeThiTracNghiem(string tenBaiThi, string Mon, string hinhThuc, List<CauHoiTracNghiem> s, string gio, string phut);
        List<DeThiViewModel> getAll(string name,int page=1);
        DeThi XemChiTietDeThi(int id);
        string DuyetBai(int id,string trangThai);
        List<DeThiViewModel> getAllDTAdmin( int page = 1);
        
    }
}
