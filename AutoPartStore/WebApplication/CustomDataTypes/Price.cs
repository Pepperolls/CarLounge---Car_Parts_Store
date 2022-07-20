using System;
using System.Diagnostics;

namespace WebApplication.CustomDataTypes
{
    [DebuggerDisplay("{Value}")]
	public class Price
	{
		public Price(decimal value)
		{
			if (value is < 0m or >= 10_000m)
				throw new ArgumentOutOfRangeException(nameof(value),
				                                      "Price must be greater than 0 and less than 10000");

			Value = value;
		}
		public decimal Value { get; set; }

		public Price Index(decimal index) => new(Value * index);

		public static Price operator +(Price x, Price y) => new(x.Value + y.Value);
		public static Price operator +(Price x, decimal y) => new(x.Value + y);
		public static Price operator +(decimal x, Price y) => new(x + y.Value);
		public static Price operator *(Price x, Price y) => new(x.Value * y.Value);
		public static Price operator *(Price x, decimal y) => new(x.Value * y);
		public static Price operator *(decimal x, Price y) => new(x * y.Value);
	}
}