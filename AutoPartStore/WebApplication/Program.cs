using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using WebApplication.Models.ItemsAcquisition;
using WebApplication.ItemsStock;
using WebApplication.ItemsPricing;
using WebApplication.Order;
using WebApplication.Billing;

namespace WebApplication
{
    public class Program
    {
		private static AcquisitionService acquisitionService;

		private static StockService stockService;

		private static PricingService pricingService;

		private static OrderService orderService;

		private static BillingService billingService;

		public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
			acquisitionService = new();
			acquisitionService.NewAcquisitionRegistered += AcquisitionService_NewAcquisitionRegistered;

			stockService = new();
			stockService.NewItemInStock += StockService_NewItemInStock;

			pricingService = new();

			OrderItems myOrder = new();

			orderService = new();
			orderService.NewOrderRegistered += OrderService_NewOrderRegistered;


			acquisitionService.Register(new(13), new(10), new(2m));
			acquisitionService.Register(new(13), new(5), new(2m));
			acquisitionService.Register(new(14), new(2), new(10m));

			myOrder.AddItemToOrder(new(new(13)), new(5));
			myOrder.AddItemToOrder(new(new(14)), new(2));

			orderService.RegisterOrder(myOrder, pricingService);

			billingService = new(orderService);
			billingService.IssueBill(orderService.orders[0].OrderId);
			//Console.ReadLine();
		}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

		private static void AcquisitionService_NewAcquisitionRegistered(object sender, AcquisitionEventArgs e)
		{
			try
			{
				stockService.UpdateStock(e.ItemTypeId, e.Quantity);
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine($"Error updating stock: {ex.Message}");
			}
		}
		private static void StockService_NewItemInStock(object sender, NewItemInStockEventArgs e)
		{
			var p = acquisitionService.GetAcquisitionPriceFor(new(e.SkuId.ItemId));

			pricingService.RegisterPrice(e.SkuId, p.Index(1.1m));
		}

		private static void OrderService_NewOrderRegistered(object sender, OrderEventArgs e)
        {
			try
			{
				// Decrease stock for each item ordered

				//foreach(var orderItem in e.OrderId)
    //            {
				//	stockService.DecreaseStock(new(orderItem.Key.ItemId), orderItem.Value);
    //            }
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine($"Error updating stock: {ex.Message}");
			}
		}

		private static void BillingService_NewBillIssued(object sender, BillingEventArgs e)
		{
			Console.WriteLine(billingService.GetTotalPriceFor(e.BillId));
		}
	}

}
