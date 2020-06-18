namespace DecoratorCoffeeShop
{
    public class MilkDecorator : Decorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
            Description = "Milk";
            Price = 1.2;
        }
    }
}