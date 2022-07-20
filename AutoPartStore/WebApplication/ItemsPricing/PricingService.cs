using System.Collections.Concurrent;
using WebApplication.CustomDataTypes;

namespace WebApplication.ItemsPricing
{
	internal sealed class PricingService
	{
		private static readonly ConcurrentDictionary<SkuId, Price> Prices = new();

		public void RegisterPrice(SkuId skuId, Price price)
		{
			Prices.AddOrUpdate(skuId,
							   _ => price,
							   (_, _) => price);
		}

		public Price GetMarketPriceFor(SkuId skuId)
        {
			//return Prices.GetValueOrDefault(skuId);
			foreach (var item in Prices)
            {
				if (item.Key.Value == skuId.Value) return item.Value;
            }
			return new(0);
        }
	}
}
