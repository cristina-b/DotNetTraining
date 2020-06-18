namespace DecoratorCoffeeShop
{
    public class Espresso : ICoffee
    {
        public string Description { get; set; } = "espresso";

        public double Price { get; set; } = 3.5;

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