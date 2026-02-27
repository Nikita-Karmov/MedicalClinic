using Clinic.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. СЕРВИСЫ
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Это убирает бесконечные циклы (врач -> спец -> врач)
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true; // Сделает JSON красивым и читаемым
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Подключение к базе
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 2. КОНФИГУРАЦИЯ (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization(); // На будущее
app.MapControllers();   // Чтобы Rider видел твои контроллеры

app.Run(); // <--- САМАЯ ВАЖНАЯ СТРОКА!