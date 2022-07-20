using System.Collections.Generic;
using WebApplication.CustomDataTypes;
using System.Linq;
using System;

namespace WebApplication.Order
{
    internal record ActualOrder
    {
        private readonly Dictionary<SkuId, OrderItem> Items = new();
        public Price Total => new(Items.Sum(p => p.Value.Total.Value));
        public Guid OrderId { get; }

        public ActualOrder(Guid orderId)
        {
            OrderId = orderId;
        }

        public void AddItemToOrder(SkuId skuId, Quantity100 quantity, Price price)
        {
            Items.Add(skuId, new(skuId, quantity, price));
        }

        private record OrderItem
        {
            public SkuId SkuId { get; }
            public Quantity100 Quantity { get; }
            public Price Price { get; }

            public OrderItem(SkuId skuId, Quantity100 quantity, Price price)
            {
                SkuId = skuId;
                Quantity = quantity;
                Price = price;
            }

            public Price Total => Quantity.Value * Price;
        }
    }

}
