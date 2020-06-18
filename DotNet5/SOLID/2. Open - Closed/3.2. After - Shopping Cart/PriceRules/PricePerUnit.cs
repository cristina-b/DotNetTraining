using OpenClosedShoppingCartAfter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedShoppingCartAfter.PriceRules
{
    class PricePerUnit : IPriceRules
    {
        public decimal CalculatePrice(OrderItem orderItem)
        {
            return orderItem.Quantity * 5m;
        }

        public bool ProductPaymentRules(OrderItem orderItem)
        {
            return orderItem.Sku.StartsWith("EACH");
        }
    }
}
