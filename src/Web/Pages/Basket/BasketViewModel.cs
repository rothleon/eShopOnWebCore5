using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.Web.Pages.Basket
{
    

    public class BasketViewModel
    {
        //Sprint 2 - Add a tax calculation and a Grand Total field to each basket in a manner similar to what you did for an order above. - Leon Roth
        private const decimal TAXMULTIPLIER = ApplicationCore.Entities.OrderAggregate.Order.TAXMULTIPLIER;
        
        public int Id { get; set; }
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        public string BuyerId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }

        //Sprint 2 - Add a tax calculation and a Grand Total field to each basket in a manner similar to what you did for an order above. - Leon Roth
        public decimal TaxAmount()
        {
            decimal taxAmount = this.Total() * TAXMULTIPLIER;

            return taxAmount;
        }

        //Sprint 2 - Add a tax calculation and a Grand Total field to each basket in a manner similar to what you did for an order above. - Leon Roth
        public decimal GrandTotal()
        {
            decimal grandTotal = this.Total() + this.TaxAmount();

            return grandTotal;
        }
    }
}
