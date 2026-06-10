using Microsoft.AspNetCore.Mvc;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DepartmentsController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        // عرض الأقسام مع الأطباء التابعين لها
        return Ok(await _context.Departments.Include(d => d.Doctors).ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return Ok(department);
    }
}