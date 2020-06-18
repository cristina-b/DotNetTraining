namespace DecoratorCoffeeShop
{
    public class Filtered : ICoffee
    {
        public string Description { get; set; } = "filtered coffee";
        public double Price { get; set; } = 4.5;

        public string GetDescription()
        {
            return Description;
        }

        public double GetPrice()
        {
            return Price;
        }
    }
}