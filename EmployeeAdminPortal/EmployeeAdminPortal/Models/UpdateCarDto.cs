namespace EmployeeAdminPortal.Models
{
    public class UpdateCarDto
    {
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public decimal Cost { get; set; }
    }
}