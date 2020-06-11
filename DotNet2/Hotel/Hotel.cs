using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DotNet2
{
    public enum RoomType
    {
        singleRoom,
        doubleRoom,
        doubleDeluxe,
        superior,
        suite
    }

    public enum Currency
    {
        RON,
        EUR,
        USD,
        GBP
    }

    public class Rate
    {
        public double Amount { get; private set; }
        public Currency Currency { get; private set; }

        public Rate (double amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public void Print()
        {
            Console.WriteLine("{0} {1}", Amount, Currency);
        }
    }

    public class Room
    {
        public string Name { get; private set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public Rate Rate { get; private set; }
        public Hotel Hotel { get; private set; }
        public RoomType RoomType { get; set; }

        public Room(RoomType roomType, string name, int adults, int children, Rate rate)
        {
            this.RoomType = roomType;
            this.Name = name;
            this.Adults = adults;
            this.Children = children;
            this.Rate = rate;
        }

        public void GetPriceForDays(int numberOfDays = 0)
        {
            if (numberOfDays <= 0)
            {
                throw new ArgumentException("Invalid number of days");
            }

            double cost = numberOfDays * this.Rate.Amount;// + " " + this.Rate.Currency ;

            Console.WriteLine("Staying {0} days will cost {1} {2}", numberOfDays, cost, this.Rate.Currency);
        }

        public void Print()
        {
            Console.WriteLine("Room {0} accommodates {1} adults and {2} children and costs {3} {4} per night", Name, this.Adults, this.Children, this.Rate.Amount, this.Rate.Currency);//
        }
    }

    public class Hotel
    {
        public string Name { get; private set; }
        public string City { get; private set; }

        private  IList<Room> Rooms { get; set; } = new List<Room>();

        public Hotel(string name, string city)
        {
            Name = name;
            City = city;          
        }


        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public double GetPriceForNumberOfRooms(int numberOfRooms = 0)
        {
            if (numberOfRooms <= 0)
            {
                Console.WriteLine("Invalid number of rooms");
                return 0;
            }

            if (numberOfRooms > Rooms.Count)
            {
                Console.WriteLine("Invalid number of rooms");
                return 0;
            }

            double cost = 0;
            for (int i = 0; i < numberOfRooms; i++)
            {
                cost += Rooms[i].Rate.Amount;
            }
            return cost;            
        }

        public void FindACheaperRoom(double price)
        {
            //return the first room cheaper than the given price
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].Rate.Amount < price)
                    Console.WriteLine(" {0} is costing {1}, it's less than {2}", Rooms[i].Name, Rooms[i].Rate.Amount, price);
                return;
            }
        }

        public void Print()
        {
            Console.WriteLine("The hotel name is {0}, located in {1} and the available rooms are: ", Name, City);
            for (int i = 0; i < Rooms.Count; i++)
            {
                Console.WriteLine("{0} costs {1} {2} per night", Rooms[i].Name, Rooms[i].Rate.Amount, Rooms[i].Rate.Currency);
            }
        }
    }
}
