using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public interface ICarRepository
    {
        void CreateCar(CarModel car);
        void DeleteCar(int carId);
        CarModel GetCar(int carId);
        IEnumerable<CarModel> GetAllCars();
        IEnumerable<CarModel> GetAllCarsWithParts();
        void AddPartToCar(int carId, PartModel part);
        void PersisteCar(CarModel car);
    }
}