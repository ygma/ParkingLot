using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public class ParkingLot
    {
        private readonly int capacity;
        private readonly List<Car> parkedCars = new List<Car>();

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
        }

        public int Park(Car car)
        {
            if (IsFull())
            {
                throw new ArgumentOutOfRangeException();
            }

            parkedCars.Add(car);
            return car.GetHashCode();
        }

        public Car Pick(int ticket)
        {
            var car = parkedCars.SingleOrDefault<Car>(c => c.GetHashCode() == ticket);
            parkedCars.Remove(car);
            return car;
        }

        public bool IsFull()
        {
            return parkedCars.Count >= capacity;
        }
    }
}