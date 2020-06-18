using OpenClosedShoppingCartAfter.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OpenClosedShoppingCartAfter
{
    class PriceCalculator : IPriceCalculator
    {
        private readonly List<IPriceRules> _priceRules;

        public PriceCalculator(List<IPriceRules> priceRules)
        {
            _priceRules = priceRules;
        }

        public decimal CalculatePrice(OrderItem item)
        {
            foreach(IPriceRules rule in _priceRules)
            {
                if(rule.ProductPaymentRules(item))
                {
                    return rule.CalculatePrice(item);
                }
            }
            return 0m;
        }        
    }
}
