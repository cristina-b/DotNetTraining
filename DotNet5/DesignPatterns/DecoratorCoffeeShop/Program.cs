using System;
using System.Collections.Generic;
using System.Linq;

namespace DecoratorCoffeeShop
{
    class Program
    {
        public void Main()
        {                        
            var chocolateFiltered = new ChocolateDecorator(new Filtered());
            chocolateFiltered.GetDescription();
               
            var espressoWithChocolateAndMilk = new ChocolateDecorator(new MilkDecorator(new Espresso()));
            espressoWithChocolateAndMilk.GetDescription();
            }        
    }
}
