using InventoryAPI.Context;
using InventoryAPI.Services.ProductServices;
using InventoryAPI.Services.ProductTypeService;
using InventoryAPI.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexão com o banco
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=JEFFERSON\\SQLEXPRESS;Initial Catalog=InventoryProject;Integrated Security=True"));

// Injeção de dependencia
builder.Services.AddScoped<IProductService, ProductsService>();
builder.Services.AddScoped<IProductTypeService, ProductTypesService>();
builder.Services.AddScoped<IUserService, UserService>();

// Registro de automappper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
