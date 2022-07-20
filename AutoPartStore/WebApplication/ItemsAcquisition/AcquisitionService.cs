using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.CustomDataTypes;

namespace WebApplication.Models.ItemsAcquisition
{
	internal sealed class AcquisitionService
	{
		private static readonly List<PartAcquisitionModel> acquisitions = new();

		public event EventHandler<AcquisitionEventArgs> NewAcquisitionRegistered;

		public void Register(ItemTypeId itemTypeId, Quantity100 quantity, Price price)
		{
			// Record a new entry into Acquisitions Subsystem
			acquisitions.Add(new(itemTypeId, quantity, price));

			// Raise event for new acquisition
			OnNewAcquisitionRegistered(new(itemTypeId, quantity, price));
		}

		private void OnNewAcquisitionRegistered(AcquisitionEventArgs e)
		{
			NewAcquisitionRegistered?.Invoke(this, e);
		}

		public Price GetAcquisitionPriceFor(ItemTypeId itemTypeId) => acquisitions.Last(x => x.TypeId == itemTypeId).UnitPrice;
	}

	internal class AcquisitionEventArgs : EventArgs
	{
		public AcquisitionEventArgs(ItemTypeId itemTypeId, Quantity100 quantity, Price price)
		{
			ItemTypeId = itemTypeId;
			Quantity = quantity;
			Price = price;
		}

		public ItemTypeId ItemTypeId { get; }

		public Quantity100 Quantity { get; }

		public Price Price { get; }
	}
}
