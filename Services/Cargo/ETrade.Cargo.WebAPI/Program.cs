using ETrade.Cargo.Business.Abstract;
using ETrade.Cargo.Business.Concreate;
using ETrade.Cargo.DataAccesLayer.Abstract;
using ETrade.Cargo.DataAccesLayer.Concreate.Context;
using ETrade.Cargo.DataAccesLayer.EfCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo";
    opt.RequireHttpsMetadata = false;

}

);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CargoContext>();
builder.Services.AddScoped<ICargoCompanyDal,EfCargoCompanyDal>();
builder.Services.AddScoped<ICargoOperationDal,EfCargoCompanyOperationDal>();
builder.Services.AddScoped<ICargoDetail,EfCargoDetailDal>();
builder.Services.AddScoped<ICargoCustomerDal,EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoCompanyService,CargoCompanyService>();
builder.Services.AddScoped<ICargoOperationService,CargoOperationService>();
builder.Services.AddScoped<ICargoDetailService,CargoDetailService>();
builder.Services.AddScoped<ICargoCustomerService,CargoCustomerService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
