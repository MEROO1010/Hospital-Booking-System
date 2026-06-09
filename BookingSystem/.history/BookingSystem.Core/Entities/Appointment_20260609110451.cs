using System;

namespace BookingSystem.Core.Entities
{
    public class Appointment
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; } // الربط مع الطبيب
    public string PatientName { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = "Scheduled";
}
}