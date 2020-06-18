namespace OpenClosedShoppingCartAfter
{
    using OpenClosedShoppingCartAfter.Contracts;
    using System.Collections.Generic;

    public class Cart
    {
        private readonly List<OrderItem> items;
        private readonly IPriceCalculator _priceCalculator;
        public string CustomerEmail { get; set; }

        public Cart(IPriceCalculator priceCalculator)
        {
            this.items = new List<OrderItem>();
            this._priceCalculator = priceCalculator;
        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }               

        public decimal TotalAmount()
        {
            decimal total = 0m;
            foreach (OrderItem orderItem in this.Items)
            {
                total += _priceCalculator.CalculatePrice(orderItem);
            }
            return total;
        }
    }
}