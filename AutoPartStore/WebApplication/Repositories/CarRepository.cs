using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AutoPartsContext _dbContext;

        public CarRepository(AutoPartsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCar(CarModel car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }
        public void DeleteCar(int carId)
        {
            _dbContext.Cars.Remove(GetCar(carId));
            _dbContext.SaveChanges();
        }

        public CarModel GetCar(int carId)
        {
            return _dbContext.Cars.Find(carId);

            //return _dbContext.Cars.Include(p => p.Parts).FirstOrDefault(x => x.CarModelId == carId);

        }
        public IEnumerable<CarModel> GetAllCars()
        {
            return _dbContext.Cars;
        }

        public IEnumerable<CarModel> GetAllCarsWithParts()
        {
            return _dbContext.Cars.Include(x => x.Parts);
        }

        public void AddPartToCar(int carId, PartModel part)
        {
            _dbContext.Cars.Find(carId).Parts.Add(part);
        }

        public void PersisteCar(CarModel car)
        {
            _dbContext.SaveChanges();
        }
    }
}
