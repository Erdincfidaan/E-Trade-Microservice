using ETrade.Catalog.Services.AboutServices;
using ETrade.Catalog.Services.CategoryServices;
using ETrade.Catalog.Services.ContactServices;
using ETrade.Catalog.Services.FeatureSliderService;
using ETrade.Catalog.Services.ProductDetailsServices;
using ETrade.Catalog.Services.ProductImagesServices;
using ETrade.Catalog.Services.ProductServices;
using ETrade.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;

}
    
); 

builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IProductImageServices, ProductImageServices>();
builder.Services.AddScoped<IProductDetailServices, ProductDetailServices>();
builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<IFeatureSliderServices, FeatureSliderService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
 return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ETrade Catalog API",
        Version = "v1",
        Description = "This service manages product and category operations in the ETrade system."
    });
});

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
