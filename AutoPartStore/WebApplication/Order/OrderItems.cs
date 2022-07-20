using System.Collections.Generic;
using WebApplication.CustomDataTypes;

namespace WebApplication.Order
{
    internal sealed class OrderItems
    {
        public readonly Dictionary<SkuId, Quantity100> orderItems = new();

        public OrderItems()
        {
            
        }

        public void AddItemToOrder(SkuId skuId, Quantity100 quantity)
        {
            orderItems.Add(skuId, quantity);   
        }

        public void RemoveItemFromOrder(SkuId skuId)
        {
            orderItems.Remove(skuId);
        }
    }
}
