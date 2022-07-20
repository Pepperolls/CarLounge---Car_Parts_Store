namespace WebApplication.CustomDataTypes
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;

	[DebuggerDisplay("{Value}")]
	internal readonly struct ItemTypeId
	{
		public int Value { get; }

		public ItemTypeId(int value)
		{
			if (value is < 1 or > 9999)
				throw new ArgumentOutOfRangeException(nameof(value), "Item type ID must be between 1 and 9999.");

			Value = value;
		}

		public bool Equals(ItemTypeId other) => Value == other.Value;

		public override bool Equals(object obj) => obj is ItemTypeId other && Equals(other);

		public override int GetHashCode() => Value;

		public static bool operator ==(ItemTypeId left, ItemTypeId right) => left.Equals(right);

		public static bool operator !=(ItemTypeId left, ItemTypeId right) => !left.Equals(right);
	}
}