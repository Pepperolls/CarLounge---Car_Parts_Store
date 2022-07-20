namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartModel // The one in the database
    {
        public int PartModelId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CarModelId { get; set; }
        public CarModel Car { get; set; }
        //public PartStockKeepingUnit Stock { get; set; }
        public string ImgUrl { get; set; }

        public PartModel()
        {

        }
        public PartModel(string name, decimal price, string category, string description, string imgUrl, CarModel carModel)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.Description = description;
            this.ImgUrl = imgUrl;
            this.Car = carModel;
        }

        public override string ToString()
        {
            return $"Part Name:{Name}, Part Price: {Price}";
        }
    }
}