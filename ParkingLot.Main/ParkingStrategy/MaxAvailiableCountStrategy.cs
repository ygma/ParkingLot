using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main.ParkingStrategy
{
    public class MaxAvailiableCountStrategy : IParkStrategy
    {
        public override int? Park(Car car, List<ParkingLot> lots)
        {
            return lots.OrderByDescending(p => p.AvaliableCount).First().Park(car);
        }
    }
}