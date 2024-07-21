using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.Sevices
{
    public interface IUser
    {
      //  IEnumerable<ChiTietTaiKhoan> getAll(/*int page =1*/);
      List<UserViewModel>GetAll(int page = 1);
        UserDTO Add(string id, IFormFile HinhAnh, string ten, string Email, string matKhau, string diaChi, string SoDienThoai, bool gioiTinh,int  Quyen);

        //void Delete(string id);
        UserDTO GetByCase(string id);
        void CapLaiMatKhau(string Email);
       UserDTO UpdateAllUser(string id, IFormFile HinhAnh, string ten, string Email, string matKhau, string diaChi, string SoDienThoai, bool gioiTinh, int Quyen);
        string GetUserName();
       
    }
}
