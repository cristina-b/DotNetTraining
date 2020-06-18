namespace DecoratorCoffeeShop
{
    public class ChocolateDecorator : Decorator
    {
        public ChocolateDecorator(ICoffee coffee) : base(coffee)
        {
            Description = "Chocolate";
            Price = 1.5;
        }
    }
}