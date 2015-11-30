using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public class PickService
    {
        private readonly List<ParkingLot> parkingLots;

        public PickService(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Car Pick(int? ticket)
        {
            return parkingLots.Select(item => item.Pick(ticket)).FirstOrDefault(car => car != null);
        }
    }
}