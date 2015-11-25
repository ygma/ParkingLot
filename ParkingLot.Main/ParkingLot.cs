using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public class ParkingLot
    {
        private readonly int capacity;
        private readonly List<Car> parkedCars = new List<Car>();

        public int AvaliableCount
        {
            get { return capacity - parkedCars.Count; }
        }

        public float FreeSpaceRate
        {
            get { return (float)AvaliableCount / capacity; }
        }

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
        }

        public int? Park(Car car)
        {
            if (IsFull())
            {
                return null;
            }

            parkedCars.Add(car);
            return car.GetHashCode();
        }

        public Car Pick(int? ticket)
        {
            var car = parkedCars.FirstOrDefault(c => c.GetHashCode() == ticket);
            parkedCars.Remove(car);
            return car;
        }

        private bool IsFull()
        {
            return parkedCars.Count >= capacity;
        }
    }
}