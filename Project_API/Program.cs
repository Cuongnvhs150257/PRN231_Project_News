using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_API.DTO;
using Project_API.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<PRN_ProjectContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("PRN_Project")));

// loai bo errol vong lap vong tron
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Article, ArticleDTO>();
    cfg.CreateMap<Category, CategoryDTO>();
    cfg.CreateMap<User, UserDTO>();
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);



var app = builder.Build();


builder.Services.AddCors();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
