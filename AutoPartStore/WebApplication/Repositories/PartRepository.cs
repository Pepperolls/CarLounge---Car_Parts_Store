using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class PartRepository : IPartRepository
    {
        private readonly AutoPartsContext _dbContext;

        public PartRepository(AutoPartsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePart(PartModel part)
        {
            _dbContext.Parts.Add(part);
            _dbContext.SaveChanges();
        }
        public void DeletePart(int partId)
        {
            _dbContext.Parts.Remove(GetPart(partId));
            _dbContext.SaveChanges();
        }
        public PartModel GetPart(int partId)
        {
            return _dbContext.Parts.Find(partId);
        }
        public PartModel GetPartWithCar(int partId)
        {
            return _dbContext.Parts.Include(x => x.Car).Single(x => x.PartModelId == partId);
        }
        public IEnumerable<PartModel> GetPartsOfCar(int carId)
        {
            return _dbContext.Parts.Where(p => p.CarModelId == carId);
        }
        public IEnumerable<PartModel> GetAllParts()
        {
            return _dbContext.Parts;
        }

        public IEnumerable<PartModel> GetAllPartsWithCars()
        {
            return _dbContext.Parts.Include(x => x.Car);
        }
    }
}
