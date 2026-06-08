using System;

namespace BookingSystem.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; } // العلاقة مع الطبيب
        public string PatientName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = "Scheduled"; // حالة الموعد
    }
}