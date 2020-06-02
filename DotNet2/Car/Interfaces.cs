using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2.Car
{
    interface IStore
    {
        string Name { get; set; }
        public IList<Producer> Producers { get; set; }
        public IList<Person> Customers { get; set; }        
    }

    interface IPerson
    {
        //public IList<IOrder> Orders { get; set; }
        string Name { get; set;}
        string Address { get; set; }
        string Telephone { get; set; }
        public Order Buy(Vehicle vehicle);
        public bool CancelOrder(Vehicle vehicle);
    }

    interface IOrder
    {
        //public Vehicle vehicle { get; set; }        
        DateTime Date { get; set; }        
        //bool Order(Vehicle vehicle);
    }

    interface IProducer
    {
        string Name { get; set; }
        int DeliveryWeeks { get; set; }
        //public IList<IVehicle> Vehicles { get; set; }

    }

    interface IVehicle
    {
        public string Model { get; set; }       
        public string Year { get; set; }
        public decimal Price { get; set; }

    }
}
