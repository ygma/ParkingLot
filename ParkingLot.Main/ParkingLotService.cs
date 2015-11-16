using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParkingLot.Main
{
    public static class ParkingLotService
    {
        private static readonly List<Car> AllCars = new List<Car>();

        public static void Park(Car car)
        {
            AllCars.Add(car);
        }

        public static string Take(Car car)
        {
            if (car == null) throw new InvalidDataException();

            if (!IsInParkingLot(car)) return ResultMessage.NotFoundInParkingLot;

            AllCars.Remove(car);

            return ResultMessage.TakeSuccess;
        }

        private static bool IsInParkingLot(Car car)
        {
            return AllCars.Any(c => c.Equals(car));
        }
    }
}