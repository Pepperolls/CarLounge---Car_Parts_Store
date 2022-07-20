using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.CustomDataTypes;
using WebApplication.Order;

namespace WebApplication.Billing
{
    public class Bill
    {
        public Guid BillId { get; }
        public Guid OrderId { get; }
        public Price BillTotal { get; }
        public Bill(Guid billId, Guid orderId, Price billTotal)
        {
            BillId = billId;
            OrderId = orderId;
            BillTotal = billTotal;
        }
    }
}
