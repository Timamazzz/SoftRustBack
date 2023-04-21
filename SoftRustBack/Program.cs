using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SoftRustBack.Application;
using SoftRustBack.DTO.Repositories;
using SoftRustBack.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// получаем строку подключения из файла конфигурации

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});
builder.Services.AddScoped<ContactsService>();
builder.Services.AddScoped<TopicsService>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<TopicRepository>();
builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<MessageRepository>();

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
