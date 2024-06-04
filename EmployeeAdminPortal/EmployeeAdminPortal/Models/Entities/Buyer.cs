using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models.Entities
{
    public class Buyer
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public required string Name { get; set; }
        public decimal Summa { get; set; }
    }
}
