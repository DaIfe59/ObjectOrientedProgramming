using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models
{
    public class UpdateBuyerDto
    {
        [ForeignKey("Employee")]
        public required string Name { get; set; }
        public decimal Summa { get; set; }
    }
}
