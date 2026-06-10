using Microsoft.EntityFrameworkCore;
using BookingSystem.Infrastructure.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. إضافة خدمة CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// إعداد الـ Controllers مع تجاهل الحلقات المفرغة (تم دمج السطرين في سطر واحد)
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 2. تفعيل خدمة CORS
app.UseCors("AllowAll");

app.MapControllers();

app.Run();