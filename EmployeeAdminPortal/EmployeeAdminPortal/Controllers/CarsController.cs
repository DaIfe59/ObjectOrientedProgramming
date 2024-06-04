using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public CarsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(dbContext.Cars.ToList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCarById(int id)
        {
            var car = dbContext.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }


        [HttpPost]
        public IActionResult AddCar(AddCarDto addCarDto)
        {
            var carEntity = new Car()
            {
                Brand = addCarDto.Brand,
                Model = addCarDto.Model,
                Cost = addCarDto.Cost,
            };


            dbContext.Cars.Add(carEntity);
            dbContext.SaveChanges();

            return Ok(carEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCar(int id, UpdateCarDto updateCarDto)
        {
            var car = dbContext.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            car.Brand = updateCarDto.Brand;
            car.Model = updateCarDto.Model;
            car.Cost = updateCarDto.Cost;

            dbContext.SaveChanges();

            return Ok(car);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCar(int id)
        {
            var car=dbContext.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            dbContext.Cars.Remove(car);
            dbContext.SaveChanges();

            return Ok(car);
        }
    }
}
