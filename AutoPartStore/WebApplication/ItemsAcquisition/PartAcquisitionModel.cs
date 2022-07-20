using WebApplication.CustomDataTypes;

namespace WebApplication.Models
{
    internal record PartAcquisitionModel
    {
        public PartAcquisitionModel(ItemTypeId itemTypeId, Quantity100 quantity, Price unitPrice)
        {
            TypeId = itemTypeId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public ItemTypeId TypeId { get; }

        public Quantity100 Quantity { get; }

        public Price UnitPrice { get; }
    }
}
