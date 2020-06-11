namespace DecoratorCoffeeShop
{
    public abstract class Decorator : ICoffee
    {
        ICoffee coffee;

        protected string Description = "condiment default";
        protected double Price = 1.3;

        public Decorator(ICoffee icoffee)
        {
            coffee = icoffee;
        }        
    }
}