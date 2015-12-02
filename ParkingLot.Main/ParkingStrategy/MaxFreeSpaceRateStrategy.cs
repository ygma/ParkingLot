using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main.ParkingStrategy
{
    public class MaxFreeSpaceRateStrategy : IParkStrategy
    {
        public override int? Park(Car car, List<ParkingLot> lots)
        {
            return lots.OrderByDescending(l => l.FreeSpaceRate).First().Park(car);
        }
    }
}