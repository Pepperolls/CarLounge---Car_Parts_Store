using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.CustomDataTypes;
using WebApplication.Order;

namespace WebApplication.Billing
{
    internal sealed class BillingService
    {
        private static readonly List<Bill> bills = new();
        private readonly OrderService orderService;

        public event EventHandler<BillingEventArgs> NewBillIssued;

        public void IssueBill(Guid orderId)
        {
            Bill bill = new(Guid.NewGuid(), orderId, orderService.GetOrderById(orderId).Total);

            bills.Add(bill);

            OnNewBillIssued(new(bill.BillId));
        }

        private void OnNewBillIssued(BillingEventArgs e)
        {
            NewBillIssued?.Invoke(this, e);
        }
        public BillingService(OrderService orderService)
        {
            this.orderService = orderService;
        }

        public Price GetTotalPriceFor(Guid billId) => bills.Find(p => p.BillId == billId).BillTotal;

    }

    internal class BillingEventArgs : EventArgs
    {
        public BillingEventArgs(Guid billId)
        {
            BillId = billId;
        }
        public Guid BillId { get; }
    }
}
