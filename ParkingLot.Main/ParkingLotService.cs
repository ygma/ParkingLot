using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParkingLot.Main
{
    public static class ParkingLotService
    {
        private static readonly List<Car> ParkedCars = new List<Car>();

        public static int Park(Car car)
        {
            ParkedCars.Add(car);
            return car.GetHashCode();
        }

        public static Car Pick(int ticket)
        {
            var car = ParkedCars.SingleOrDefault(c => c.GetHashCode() == ticket);
            ParkedCars.Remove(car);
            return car;
        }
    }
}