using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BuyerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(dbContext.Buyers.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBuyerById(int id)
        {
            var employee = dbContext.Buyers.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult AddBuyer(AddBuyerDto addBuyerDto)
        {
            var buyerEntity = new Buyer()
            {
                Name = addBuyerDto.Name,
                Summa = addBuyerDto.Summa,
            };


            dbContext.Buyers.Add(buyerEntity);
            dbContext.SaveChanges();

            return Ok(buyerEntity);
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBuyer(int id, UpdateBuyerDto updateBuyerDto)
        {
            var buyer = dbContext.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }
            buyer.Name = updateBuyerDto.Name;
            buyer.Summa = updateBuyerDto.Summa;

            dbContext.SaveChanges();

            return Ok(buyer);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBuyer(int id)
        {
            var buyer = dbContext.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }
            dbContext.Buyers.Remove(buyer);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
