using DotNet2.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DotNet2.Car
{
    class Store : IStore
    {
        public string Name { get; set; }
        public IList<Producer> Producers { get; set; } = new List<Producer>();
        public IList<Person> Customers { get; set; } = new List<Person>();
        public Store(string name)
        {
            Name = name;
        }
    }

    class Person : IPerson
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();

        public Person(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Telephone = phone;
        }

        public Order Buy(Vehicle vehicle)
        {
            Order order = new Order(vehicle);
            this.Orders.Add(order);
            return order;           
        }

        public bool CancelOrder(Vehicle vehicle)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].car.Model.Equals(vehicle.Model))
                {                    
                    Orders.RemoveAt(i);
                    Console.WriteLine(" Order canceled");
                    return true;
                }                
            }
            return false;
        }
    }

    class Order : IOrder
    {
        public int OrderCompleted { get; set; }
        public DateTime Date { get; set; }
        public Vehicle car { get; set; }

        public Order(Vehicle vehicle)
        {
            this.car = vehicle;
            Date = DateTime.Now;
            OrderCompleted = 0;
        }
    }

    class Producer : IProducer
    {
        public string Name { get; set; }
        public int DeliveryWeeks { get; set; }
        public IList<Vehicle> Vehicles { get; set; }

        public Producer(string name, IList<Vehicle> vehicles, int deliveryWeeks)
        {
            Name = name;
            Vehicles = vehicles;
            DeliveryWeeks = deliveryWeeks;
        }
    }

    class Vehicle : IVehicle
    {
        public string Model { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }

        public Vehicle(string model, string year, decimal price)
        {
            Model = model;
            Year = year;
            Price = price;
        }
    }
}
