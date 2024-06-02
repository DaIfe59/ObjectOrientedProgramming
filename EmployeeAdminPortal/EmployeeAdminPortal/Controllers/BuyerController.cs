using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
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
        public IActionResult GetAllBuyers()
        {
            return Ok(dbContext.Buyers.ToList());
        }


        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAllBuyersById(Guid id)
        {
            var buyer = dbContext.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return Ok(buyer);
        }


        [HttpPost]
        public IActionResult AddBuyer(AddBuyerDto addBuyerDto)
        {
            var buyerEntity = new Buyer()
            {
                Nameb = addBuyerDto.Nameb,
                Surname = addBuyerDto.Surname,
                Emailb = addBuyerDto.Emailb,
            };

            dbContext.Buyers.Add(buyerEntity);
            dbContext.SaveChanges();

            return Ok(buyerEntity);
        }


        [HttpPut]
        [Route("{id:guid")]
        public IActionResult UpdateBuyer(Guid id,UpdateBuyerDto updateBuyerDto)
        {
            var buyer = dbContext.Buyers.Find(id);
            if (buyer == null)
            {
                return NotFound();
            }
            buyer.Nameb= updateBuyerDto.Nameb;
            buyer.Surname= updateBuyerDto.Surname;
            buyer.Emailb= updateBuyerDto.Emailb;

            dbContext.SaveChanges();
            
            return Ok(buyer);
        }


        [HttpDelete]
        [Route("{id:guid")]
        public IActionResult DeleteBuyer(Guid id)
        {
            var buyer = dbContext.Buyers.Find(id);
            if(buyer == null)
            {
                return NotFound();
            }
            dbContext.Buyers.Remove(buyer);
            dbContext.SaveChanges();
            return Ok(buyer);
        }
    }
}
