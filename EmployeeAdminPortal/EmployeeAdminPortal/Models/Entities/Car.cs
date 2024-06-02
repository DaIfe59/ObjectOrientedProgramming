namespace EmployeeAdminPortal.Models.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public decimal Cost { get; set; }
    }
}
