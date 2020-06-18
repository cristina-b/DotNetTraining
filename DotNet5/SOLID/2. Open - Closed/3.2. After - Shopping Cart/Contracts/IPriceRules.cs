using SingleResponsibilityBooksAfter;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedShoppingCartAfter.Contracts
{
    public interface IPriceRules
    {
        bool ProductPaymentRules(OrderItem item);
        decimal CalculatePrice(OrderItem item);
    }
}
