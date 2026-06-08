using Microsoft.EntityFrameworkCore;
using BookingSystem.Core.Entities;

namespace BookingSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // هذه هي الجداول التي ستظهر في قاعدة البيانات
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // يمكننا هنا إضافة قيود احترافية
            modelBuilder.Entity<Appointment>().Property(a => a.PatientName).IsRequired();
        }
    }
}