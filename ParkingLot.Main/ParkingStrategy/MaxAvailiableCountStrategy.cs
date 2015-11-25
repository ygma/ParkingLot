using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main.ParkingStrategy
{
    public class MaxAvailiableCountStrategy : IParkStrategy
    {
        private readonly List<ParkingLot> parkingLots;

        public MaxAvailiableCountStrategy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public int? Park(Car car)
        {
            return parkingLots.OrderByDescending(p => p.AvaliableCount).First().Park(car);
        }
    }
}