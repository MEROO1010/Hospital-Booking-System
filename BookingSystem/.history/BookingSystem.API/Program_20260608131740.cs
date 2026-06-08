using Microsoft.EntityFrameworkCore;
using BookingSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. تسجيل خدمات الـ Controllers لكي يتعرف النظام على الـ API
builder.Services.AddControllers();

// 2. تسجيل قاعدة البيانات (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. إعداد الـ Swagger (واجهة التوثيق والتجربة)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // هذا سيفعل الرابط /swagger الذي كنا نحاول الوصول إليه
}

app.UseHttpsRedirection();

// 4. تفعيل استخدام الـ Controllers في المسارات
app.MapControllers();

// المسارات الخاصة بالتجربة (WeatherForecast)
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}