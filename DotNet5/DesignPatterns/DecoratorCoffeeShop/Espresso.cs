namespace DecoratorCoffeeShop
{
    public class Espresso : ICoffee
    {
        public string Description { get; set; } = "expresso coffee";
        public double Price { get; set; } = 3;
    }
}