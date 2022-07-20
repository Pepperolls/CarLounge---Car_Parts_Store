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
    public class PartsController : ControllerBase
    {
        public PartsController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<PartModel>> GetAllParts()
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IPartRepository partRepository = new PartRepository(dbContext);

            IEnumerable<PartModel> partList = partRepository.GetAllParts();

            return partList.ToArray();
        }

        [HttpGet("/Parts/withCars")]
        public ActionResult<IEnumerable<PartModel>> GetAllPartsWithCars()
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IPartRepository partRepository = new PartRepository(dbContext);

            IEnumerable<PartModel> partList = partRepository.GetAllPartsWithCars();

            return partList.ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<PartModel> GetPart(int id)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IPartRepository partRepository = new PartRepository(dbContext);

            var part = partRepository.GetPart(id);

            return part;
        }

        [HttpGet("{id}/car")]
        public ActionResult<PartModel> GetPartWithCar(int id)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IPartRepository partRepository = new PartRepository(dbContext);

            var part = partRepository.GetPartWithCar(id);

            return part;
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string connectionString = @"Server=DESKTOP-TCVVLRS\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";
            //string connectionString = @"Server=DESKTOP-4NO7DTE\SQLEXPRESS;Database=AutoPartStore;Trusted_Connection=True";

            using var dbContext = new AutoPartsContext(connectionString);
            dbContext.Database.EnsureCreated();

            IPartRepository partRepository = new PartRepository(dbContext);

            var existingPart = partRepository.GetPart(id);

            if (existingPart is null)
                return NotFound();

            partRepository.DeletePart(id);

            return NoContent();
        }
    }
}
