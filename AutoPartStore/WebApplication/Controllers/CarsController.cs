using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        public CarsController()
        {
        }

        [HttpPost]
        public IActionResult CreateCar(string make, string model, int fabricationYear, int cubicCapacity, string fuelType)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            ICarRepository carRepository = new CarRepository(dbContext);

            var carModel = new CarModel(make, model, fabricationYear, cubicCapacity, fuelType)
            {
                Make = make,
                Model = model,
                FabricationYear = fabricationYear,
                CubicCapacity = cubicCapacity,
                FuelType = fuelType,
                Parts = new List<PartModel>()
            };

            carRepository.CreateCar(carModel);

            return CreatedAtAction(nameof(CreateCar), new { id = carModel.CarModelId }, carModel);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarModel>> GetAllCars()
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            ICarRepository carRepository = new CarRepository(dbContext);

            IEnumerable<CarModel> carList = carRepository.GetAllCars();

            return carList.ToArray();
        }

        [HttpGet("/Cars/withParts")]
        public ActionResult<IEnumerable<CarModel>> GetAllCarsWithParts()
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            ICarRepository carRepository = new CarRepository(dbContext);

            IEnumerable<CarModel> carList = carRepository.GetAllCarsWithParts();

            return carList.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<CarModel> GetCar(int id)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            ICarRepository carRepository = new CarRepository(dbContext);

            var car = carRepository.GetCar(id);

            return car;
        }

        [HttpGet("{id}/parts")]
        public ActionResult<IEnumerable<PartModel>> GetPartsOfCar(int id)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IPartRepository partRepository = new PartRepository(dbContext);

            IEnumerable<PartModel> partList = partRepository.GetPartsOfCar(id);

            return partList.ToArray();
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, string partName, decimal partPrice, string partCategory, 
            string partDescription, string partImgUrl)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            ICarRepository carRepository = new CarRepository(dbContext);

            CarModel existingCar = carRepository.GetCar(id);

            if (existingCar is null)
                return NotFound();

            PartModel part = new PartModel(partName, partPrice, partCategory, partDescription, partImgUrl, existingCar);

            carRepository.AddPartToCar(id, part);

            carRepository.PersisteCar(existingCar);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            ICarRepository carRepository = new CarRepository(dbContext);

            var existingCar = carRepository.GetCar(id);

            if (existingCar is null)
                return NotFound();

            carRepository.DeleteCar(id);

            return NoContent();
        }

    }
}
