using ETrade.Basket.LoginServices;
using ETrade.Basket.Services;
using ETrade.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.IdentityModel.Tokens.Jwt;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = "http://localhost:5001";
    opt.Audience = "ResourceBasket";
    opt.RequireHttpsMetadata = false;

}

);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IBasketService, BasketServices>();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
builder.Services.AddSingleton<RedisService>(sp =>
{
    var redisSettings = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);
    redis.Connect();
    return redis;
});

builder.Services.AddControllers(opt =>
   {
       opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
   }
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
