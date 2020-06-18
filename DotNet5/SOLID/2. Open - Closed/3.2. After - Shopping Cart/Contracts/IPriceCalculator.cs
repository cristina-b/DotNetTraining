using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedShoppingCartAfter.Contracts
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}
