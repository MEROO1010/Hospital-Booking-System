using Microsoft.AspNetCore.Mvc;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")] // هذا يحدد أن المسار هو api/Appointments
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AppointmentsController(ApplicationDbContext context) => _context = context;

    [HttpGet] // هذا السطر هو ما كان مفقوداً أو غير مفهوم للنظام
    public async Task<IActionResult> GetAll() 
    {
        return Ok(await _context.Appointments.Include(a => a.Doctor).ToListAsync());
    }

    [HttpPost] // هذا السطر يحدد أن هذه دالة إضافة
    public async Task<IActionResult> Create(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return Ok(appointment);
    }
}