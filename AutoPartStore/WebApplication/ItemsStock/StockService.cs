using System;
using System.Collections.Generic;
using WebApplication.CustomDataTypes;

namespace WebApplication.ItemsStock
{
	internal sealed class StockService
	{
		private static readonly Dictionary<ItemTypeId, Sku> Skus = new();

		public event EventHandler<NewItemInStockEventArgs> NewItemInStock;

		public void UpdateStock(ItemTypeId itemTypeId, Quantity100 quantity)
		{
			if (Skus.TryGetValue(itemTypeId, out var sku))
			{
				sku.IncrementQuantity(quantity);
			}
			else
			{
				SkuId skuId = new(itemTypeId);

				Skus.Add(itemTypeId, new(skuId, itemTypeId, quantity));

				OnNewItemInStock(new(skuId, quantity));
			}
		} 

		public void DecreaseStock(ItemTypeId itemTypeId, Quantity100 quantity)
        {
			if (Skus.TryGetValue(itemTypeId, out var sku))
			{
				sku.DecrementQuantity(quantity);
			}
			else
			{
				throw new ArgumentException("Item not found");
			}
		}
		private void OnNewItemInStock(NewItemInStockEventArgs e)
		{
			NewItemInStock?.Invoke(this, e);
		}
	}

	internal class NewItemInStockEventArgs : EventArgs
	{
		public NewItemInStockEventArgs(SkuId skuId, Quantity100 quantity)
		{
			SkuId = skuId;
			Quantity = quantity;
		}

		public SkuId SkuId { get; }

		public Quantity100 Quantity { get; }
	}
}
