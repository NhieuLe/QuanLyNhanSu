using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NhanSuAPI;
using NhanSuAPI.Data;
using NhanSuAPI.Repositories;
using NhanSuAPI.Services;
using System.Security.Cryptography;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver =
        new DefaultContractResolver();
    options.SerializerSettings.ReferenceLoopHandling =
        ReferenceLoopHandling.Ignore;
});
builder.Services.AddTransient<Seed>();

//Add DI
AddDI(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }

}
void AddDI(IServiceCollection services)
{
    #region NhanSu
    services.AddScoped<NhanSuRepository>();
    services.AddScoped<INhanSuService, NhanSuService>();
    #endregion

    #region PhanCong
    services.AddScoped<PhanCongRepository>();
    services.AddScoped<IPhanCongService, PhanCongService>();
    #endregion

    #region CongViec
    services.AddScoped<CongViecRepository>();
    services.AddScoped<ICongViecService, CongViecService>();
    #endregion

    #region PhongBan
    services.AddScoped<PhongBanRepository>();
    services.AddScoped<IPhongBanService, PhongBanService>();
    #endregion

    services.AddAutoMapper(typeof(Program).Assembly);
}