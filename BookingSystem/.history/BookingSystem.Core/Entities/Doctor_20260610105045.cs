public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    
    // إضافة الربط (Relationship)
    public int DepartmentId { get; set; }
    public Department? Department { get; set; } 
}