namespace WebApplication.CustomDataTypes
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;

	[DebuggerDisplay("{Value}")]
	internal class SkuId
	{
		public string Value => $"SKU-{ItemId}";

		public int ItemId { get; }

		public SkuId(ItemTypeId itemTypeId) => ItemId = itemTypeId.Value;
	}
}