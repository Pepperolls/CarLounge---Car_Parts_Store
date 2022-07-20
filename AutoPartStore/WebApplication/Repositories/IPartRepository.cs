using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public interface IPartRepository
    {
        void CreatePart(PartModel part);
        void DeletePart(int partId);
        PartModel GetPart(int partId);
        PartModel GetPartWithCar(int partId);
        IEnumerable<PartModel> GetAllParts();
        IEnumerable<PartModel> GetAllPartsWithCars();
        IEnumerable<PartModel> GetPartsOfCar(int carId);
    }
}