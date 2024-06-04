using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        [ForeignKey("Buyer")]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
