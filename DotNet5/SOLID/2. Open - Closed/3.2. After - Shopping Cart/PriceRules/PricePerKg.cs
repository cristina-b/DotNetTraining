using OpenClosedShoppingCartAfter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedShoppingCartAfter.PriceRules
{
    class PricePerKg : IPriceRules
    {
        public decimal CalculatePrice(OrderItem orderItem)
        {
            return orderItem.Quantity * 4m / 1000;
        }

        public bool ProductPaymentRules(OrderItem orderItem)
        {
            return orderItem.Sku.StartsWith("WEIGHT");
        }
    }
}
