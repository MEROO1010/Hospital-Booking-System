using Microsoft.EntityFrameworkCore;
using BookingSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// تسجيل الخدمات
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// تفعيل Swagger ببساطة
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// تفعيل Swagger في بيئة التطوير
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();