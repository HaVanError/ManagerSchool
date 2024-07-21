using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using Test.DatabaseContext;
using Test.Middleware;
using Test.Model.DTO;
using Test.Response;
using Test.Sevices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpContextAccessor();
#region KhaiBaoCacThuVien
builder.Services.AddScoped<IUser, UserResponse>();
builder.Services.AddScoped<IGiaoVien, GiaoVienResponse>();
builder.Services.AddScoped<IHocSinh, HocSinhResponse>();
builder.Services.AddScoped<IAdmin, AdminResponse>();
builder.Services.AddScoped<IKhoa, KhoaResponse>();
builder.Services.AddScoped<ILop, LopResponse>();
builder.Services.AddScoped<IMonHoc, MonHocResponse>();
builder.Services.AddScoped<IChuDe, ChuDeResponse>();
builder.Services.AddScoped<IBaiGiang, BaiGiangResponse>();
builder.Services.AddScoped<IThongBao, ThongBaoResponse>();
builder.Services.AddScoped<IRole, RoleResponse>();
builder.Services.AddScoped<ICauHoi, CauHoiResponse>();
builder.Services.AddScoped<ITraLoi, TraLoiResponse>();
builder.Services.AddScoped<IDeThi_KiemTra, DeThi_KiemTraResponse>();
builder.Services.AddScoped<INganHangCauHoi, NganHangCauHoiResponse>();
builder.Services.AddScoped<IThongBaoAdmin, ThongBaoAdminResponse>();
builder.Services.AddScoped<ITaiNguyen, TaiNguyenResponse>();
#endregion
builder.Services.AddDbContext<Database>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));


builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(otp =>
{
    //otp.SaveToken = true;
   
    otp.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSetting:SecretKey").Value)),

        ClockSkew = TimeSpan.Zero
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<JWTInHeaderMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
