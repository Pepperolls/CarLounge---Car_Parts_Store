using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Car
    {
        public int VehicleIdNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public int CubicCapacity { get; set; }
        public string FuelType { get; set; }
        public Car()
        {

        }
        public Car(int vehicleIdNo, string make, string model, int fabricationYear, int cubicCapacity, string fuelType)
        {
            this.VehicleIdNo = vehicleIdNo;
            this.Make = make;
            this.Model = model;
            this.FabricationYear = fabricationYear;
            this.CubicCapacity = cubicCapacity;
            this.FuelType = fuelType;
        }
    }
}
