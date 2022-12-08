using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class OrderViewModel
    {
        private const string DEFAULT_STATUS = "Pending";

        public int OrderNumber { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Total { get; set; }

        //Sprint 2 - Add a tax calculation and a Grand Total field to each order. - Leon Roth
        public decimal TaxAmount { get; set; }

        //Sprint 2 - Add a tax calculation and a Grand Total field to each order. - Leon Roth
        public decimal GrandTotal { get; set; }

        public string Status => DEFAULT_STATUS;
        public Address ShippingAddress { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }
}
