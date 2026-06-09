using BookingSystem.Core.Entities;
using BookingSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AppointmentsController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        // عرض المواعيد مع بيانات الطبيب المرتبط بها
        return Ok(await _context.Appointments.Include(a => a.Doctor).ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return Ok(appointment);
    }
}