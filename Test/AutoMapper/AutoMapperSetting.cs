using AutoMapper;
using Test.Model;
using Test.Model.DTO;
using Test.Model.ModelView;

namespace Test.AutoMapper
{
    public class AutoMapperSetting:Profile
    {
        public AutoMapperSetting()
        {
            CreateMap<UserDTO, User>();
            CreateMap<RoleDTO,Role>();
            CreateMap<GiaoVienDTO, GiaoVien>();
            CreateMap<HocSinhDTO, HocSinh>();
            CreateMap<AdminDTO, Admin>();
            CreateMap<KhoaDTO, Khoa>();
            CreateMap<LopDTO, Lop>();
            CreateMap<LopViewModel, Lop>();
            CreateMap<MonHocDTO,MonHoc>();
            CreateMap<MonHocViewModel, MonHoc>();
            CreateMap<ChuDeDTO, ChuDe>();
            CreateMap<ThongBaoDTO, ThongBao>();
            CreateMap<ThongBao_LopViewModel, ThongBao>();
            CreateMap<CauHoiDTO, CauHoi>();
            CreateMap<TraLoiDTO, TraLoi>();
            CreateMap<NganHangCauHoiDTO, NganHangCauHoiTN>();
            CreateMap<ThongBaoAdminDTO, ThongBaoAdmin>();

        }
    }
}
