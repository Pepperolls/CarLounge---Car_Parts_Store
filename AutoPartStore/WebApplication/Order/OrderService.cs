using System;
using System.Collections.Generic;
using WebApplication.CustomDataTypes;
using WebApplication.ItemsPricing;

namespace WebApplication.Order
{
	internal sealed class OrderService
	{
		public readonly List<ActualOrder> orders = new();

		public event EventHandler<OrderEventArgs> NewOrderRegistered;

		public void RegisterOrder(OrderItems orderItems, PricingService pricingService)
        {
            ActualOrder actualOrder = new(Guid.NewGuid());

            foreach(var orderItem in orderItems.orderItems)
            {
                actualOrder.AddItemToOrder(orderItem.Key, orderItem.Value, pricingService.GetMarketPriceFor(orderItem.Key));
            }

            orders.Add(actualOrder);

			OnNewOrderRegistered(new(actualOrder.OrderId));
        }

        public ActualOrder GetOrderById(Guid orderId)
        {
           return orders.Find(p => p.OrderId == orderId);
        }

        private void OnNewOrderRegistered(OrderEventArgs e)
        {
			NewOrderRegistered?.Invoke(this, e);
        }

    }
	internal class OrderEventArgs : EventArgs
	{
        public OrderEventArgs(Guid orderId)
        {
            OrderId = orderId;
        }
        public Guid OrderId { get; }
    }
}
