using System.Collections.Generic;
using System.Linq;
using ParkingLotManagement.Main.ParkingStrategy;

namespace ParkingLotManagement.Main
{
    public class Car
    {
        public int? Park(List<ParkingLot> parkingLots2, MaxAvailiableCountStrategy maxAvailiableCountStrategy)
        {
            return parkingLots2.OrderByDescending(p => p.AvaliableCount).First().Park(this);
        }
    }
}