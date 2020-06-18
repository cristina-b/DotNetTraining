using OpenClosedShoppingCartAfter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedShoppingCartAfter.PriceRules
{
    class PriceSpecial : IPriceRules
    {
        public decimal CalculatePrice(OrderItem orderItem)
        {
            decimal total = 0m;
            total += orderItem.Quantity * .4m;
            int setsOfThree = orderItem.Quantity / 3;
            total -= setsOfThree * .2m;
            return total;
        }

        public bool ProductPaymentRules(OrderItem orderItem)
        {
            return orderItem.Sku.StartsWith("SPECIAL");
        }
    }
}
