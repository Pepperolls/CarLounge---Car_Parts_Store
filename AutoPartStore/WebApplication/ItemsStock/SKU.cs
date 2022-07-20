using System;
using WebApplication.CustomDataTypes;

namespace WebApplication.ItemsStock
{
	internal class Sku
	{
		public Sku(SkuId skuId, ItemTypeId itemTypeId, Quantity100 quantity)
		{
			SkuId = skuId;
			ItemTypeId = itemTypeId;
			Quantity = quantity;
		}

		public SkuId SkuId { get; }

		public ItemTypeId ItemTypeId { get; }

		public Quantity100 Quantity { get; }

		/// <summary>
		/// </summary>
		/// <param name="newQuantity"></param>
		/// <exception cref="InvalidOperationException"></exception>
		public void IncrementQuantity(Quantity100 newQuantity)
		{
			Quantity.Add(newQuantity);
		}

		public void DecrementQuantity(Quantity100 quantityToDecrement)
        {
			Quantity.Decrease(quantityToDecrement);
        }
	}
}
