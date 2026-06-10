using Microsoft.AspNetCore.Mvc;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore; // تأكدي من وجود هذا السطر
using System.Linq; // ضروري جداً لعمل Select

namespace BookingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            // نختار الحقول التي نريدها فقط، مما يمنع حدوث خطأ الدائرة المفرغة
            var doctors = await _context.Doctors
                .Select(d => new 
                {
                    d.Id,
                    d.Name,
                    d.Specialty,
                    DepartmentName = d.Department != null ? d.Department.Name : "لا يوجد"
                })
                .ToListAsync();

            return Ok(doctors);
        }
        
        // ... (بقية الكود)
    }
}