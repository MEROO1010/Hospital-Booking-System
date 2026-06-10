using Microsoft.AspNetCore.Mvc;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }

        [HttpGet]
public async Task<ActionResult<List<DoctorDto>>> GetDoctors()
{
    var doctors = await _context.Doctors
        .Select(d => new DoctorDto
        {
            Id = d.Id,
            Name = d.Name,
            Specialty = d.Specialty,
            DepartmentName = d.Department != null ? d.Department.Name : "لا يوجد"
        })
        .ToListAsync();

    return Ok(doctors);
}
    }
}