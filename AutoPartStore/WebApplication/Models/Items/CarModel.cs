using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public int CubicCapacity { get; set; }
        public string FuelType { get; set; }

        //public ICollection<PartModel> Parts { get; set; }
        public List<PartModel> Parts { get; set; } = new List<PartModel>() { };
        public CarModel()
        {

        }

        public CarModel(string make, string model, int fabricationYear, int cubicCapacity, string fuelType)
        {
            this.Make = make;
            this.Model = model;
            this.FabricationYear = fabricationYear;
            this.CubicCapacity = cubicCapacity;
            this.FuelType = fuelType;
        }

        public CarModel(int carId, string make, string model, int fabricationYear, int cubicCapacity, string fuelType)
        {
            this.CarModelId = carId;
            this.Make = make;
            this.Model = model;
            this.FabricationYear = fabricationYear;
            this.CubicCapacity = cubicCapacity;
            this.FuelType = fuelType;
        }
    }
}
