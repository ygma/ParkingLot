using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public class CommonParkingBoy : ParkingBoyBase
    {
        public CommonParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public int? Park(Car car)
        {
            foreach (var parkingLot in parkingLots)
            {
                var ticket = parkingLot.Park(car);

                if (ticket.HasValue) return ticket;
            }

            return null;
        }
    }
}