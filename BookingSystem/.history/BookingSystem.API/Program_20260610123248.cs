using Microsoft.EntityFrameworkCore;
using BookingSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. إضافة خدمة CORS (هنا يتم تعريف السياسة)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
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

// 2. تفعيل خدمة CORS (يجب أن توضع قبل MapControllers)
app.UseCors("AllowAll");

app.MapControllers();

app.Run();