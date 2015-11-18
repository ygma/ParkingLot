using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public class ParkingLot
    {
        private static readonly List<Car> parkedCars = new List<Car>();

        public int Park(Car car)
        {
            parkedCars.Add(car);
            return car.GetHashCode();
        }

        public Car Pick(int ticket)
        {
            var car = parkedCars.SingleOrDefault<Car>(c => c.GetHashCode() == ticket);
            parkedCars.Remove(car);
            return car;
        }
    }
}