using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public int? Park(Car car)
        {
            return parkingLots.OrderByDescending(p => p.AvaliableCount).First().Park(car);
        }
    }
}