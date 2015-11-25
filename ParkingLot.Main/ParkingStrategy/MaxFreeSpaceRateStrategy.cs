using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main.ParkingStrategy
{
    public class MaxFreeSpaceRateStrategy : IParkStrategy
    {
        private readonly List<ParkingLot> parkingLots;

        public MaxFreeSpaceRateStrategy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public int? Park(Car car)
        {
            return parkingLots.OrderByDescending(l => l.FreeSpaceRate).First().Park(car);
        }
    }
}