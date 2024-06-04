using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models
{
    public class AddBuyerDto
    {
        [ForeignKey("Employee")]
        public required string Name { get; set; }
        public decimal Summa { get; set; }
    }
}
