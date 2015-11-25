using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public int? Park(Car car)
        {
            return parkingLots.OrderByDescending(l => l.FreeSpaceRate).First().Park(car);
        }
    }
}