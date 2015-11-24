using System.Collections.Generic;

namespace ParkingLotManagement.Main
{
    public class ParkingBoyBase
    {
        protected List<ParkingLot> parkingLots;

        public ParkingBoyBase(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Car Pick(int? ticket)
        {
            foreach (var item in parkingLots)
            {
                var car = item.Pick(ticket);

                if (car != null) return car;
            }
            return null;
        }
    }
}