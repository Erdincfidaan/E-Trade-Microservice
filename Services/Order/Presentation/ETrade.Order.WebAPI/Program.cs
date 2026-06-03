using ETrade.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using ETrade.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Application.Services;
using ETrade.Order.Persistance.Context;
using ETrade.Order.Persistance.Repository;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{

    opt.Authority = "https://localhost:5001"; 
    opt.Audience = "ResourceOrder";
    opt.RequireHttpsMetadata = false;
}
);
builder.Services.AddDbContext<OrderContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationService(builder.Configuration);



builder.Services.AddScoped<GetAdressQueryHandler>();
builder.Services.AddScoped<GetAdressByIdQueryHandler>();
builder.Services.AddScoped<CreateAdressCommandHandler>();
builder.Services.AddScoped<UpdateAdressCommandHandler>(); //handler için bütün nesneler artık konteynerda her istendiğinde program verir
builder.Services.AddScoped<RemoveAdressCommandHandler>();

builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailHandler>();
builder.Services.AddScoped<RemoveOrderDetailHandler>();

// Add services to the container.

builder.Services.AddControllers();
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

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
