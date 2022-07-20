namespace WebApplication.CustomDataTypes
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;

	[DebuggerDisplay("{Value}")]
	internal class Quantity100
	{
		public Quantity100(int value)
		{
			if (value is < 1 or > 100)
				throw new ArgumentOutOfRangeException(nameof(value), "Quantity must be between 1 and 100.");

			Value = value;
		}

		public int Value { get; private set; }

		/// <summary>
		/// </summary>
		/// <param name="newQuantity"></param>
		/// <exception cref="InvalidOperationException">Thrown when resulting quantity exceeds limit.</exception>
		public void Add(Quantity100 newQuantity)
		{
			var newValue = Value + newQuantity.Value;

			if (newValue > 100)
				throw new InvalidOperationException("Resulting quantity must be less than 100.");

			Value = newValue;
		}

		public void Decrease(Quantity100 quantityToDecrease)
        {
			var newValue = Value - quantityToDecrease.Value;

			if (newValue < 0)
				throw new InvalidOperationException("Resulting quantity must not be less than 0.");

			Value = newValue;
		}
	}
}