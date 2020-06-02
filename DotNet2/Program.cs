using DotNet2.Car;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace DotNet2
{
    class Program
    {
        static void hotelActions()
        {
            Rate rate1 = new Rate(150.3, Currency.EUR);
            Rate rate2 = new Rate(170.4, Currency.GBP);
            Rate rate3 = new Rate(230.8, Currency.EUR);
            rate1.Print();
            rate2.Print();
            rate3.Print();

            Room room1 = new Room(RoomType.doubleRoom, "Double Standard", 2, 1, rate1);
            Room room2 = new Room(RoomType.superior, "Double Superior", 2, 2, rate2);
            Room room3 = new Room(RoomType.doubleDeluxe, "Double Deluxe", 2, 2, rate3);
            room1.Print();
            room2.Print();
            room3.Print();
            room1.GetPriceForDays(5);
            room2.GetPriceForDays(5);

            Hotel hotel1 = new Hotel("Malibu Hotel", "Mamaia");
            hotel1.AddRoom(room1);
            hotel1.AddRoom(room2);
            hotel1.Print();
            double price = hotel1.GetPriceForNumberOfRooms(2);
            Console.WriteLine("The price for the number of rooms is: {0}", price);

            hotel1.FindACheaperRoom(160);

            //delete?!
            //hotel1 = null;
        }


        static void carActions()
        {            
            Vehicle Focus = new Vehicle("Focus", "2015", 15000);
            Vehicle Mondeo = new Vehicle("Mondeo", "2017", 19000);
            Vehicle Fiesta = new Vehicle("Fiesta", "2016", 18000);

            List<Vehicle> fordVehicles = new List<Vehicle>();
            fordVehicles.Add(Focus);
            fordVehicles.Add(Mondeo);
            fordVehicles.Add(Fiesta);
            Producer Ford = new Producer("Ford", fordVehicles, 5);

            Console.WriteLine(Ford.Name);
            Console.WriteLine(Ford.Vehicles);
            Console.WriteLine(Ford.DeliveryWeeks);

            Store fordStore = new Store("FordStore");
            fordStore.Producers.Add(Ford);

            Person person1 = new Person("Alex", "address", "0700990099");
            Order order1 = person1.Buy(Focus);
            Console.WriteLine("{0} costs {1} and is delivered in {2} weeks", Focus.Model, Focus.Price, Ford.DeliveryWeeks);

            fordStore.Customers.Add(person1);


            Vehicle Octavia = new Vehicle("Octavia", "2018", 17000);
            Vehicle Superb = new Vehicle("Superb", "2017", 22000);
            Vehicle Kamiq = new Vehicle("Kamiq", "2016", 19000);

            List<Vehicle> skodaVehicles = new List<Vehicle>();
            skodaVehicles.Add(Focus);
            skodaVehicles.Add(Mondeo);
            skodaVehicles.Add(Fiesta);
            Producer Skoda = new Producer("Skoda", skodaVehicles, 3);

            Store skodaStore = new Store("SkodaStore");
            skodaStore.Producers.Add(Skoda);

            Order order2 = person1.Buy(Octavia);
            Console.WriteLine("{0} costs {1} and is delivered in {2} weeks", Octavia.Model, Octavia.Price, Skoda.DeliveryWeeks);
            person1.CancelOrder(Octavia);
            order2.OrderCompleted = 1; //received the car
        }

        static void Main(string[] args)
        {
            //hotelActions();
            carActions();
        }
    }
}
