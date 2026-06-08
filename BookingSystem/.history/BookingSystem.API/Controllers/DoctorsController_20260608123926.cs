using Microsoft.AspNetCore.Mvc;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Core.Entities;

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/doctors
        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }

        // GET: api/doctors
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors.ToList());
        }
    }
}