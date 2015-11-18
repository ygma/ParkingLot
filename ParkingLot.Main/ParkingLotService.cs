using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public static class ParkingLotService
    {
        public static readonly List<Car> ParkedCars = new List<Car>();

        public static Car Pick(int ticket)
        {
            var car = ParkedCars.SingleOrDefault(c => c.GetHashCode() == ticket);
            ParkedCars.Remove(car);
            return car;
        }

        public static int Park(Car car)
        {
            ParkingLotService.ParkedCars.Add(car);
            return car.GetHashCode();
        }
    }

    public class ParkingLot
    {
    }
}