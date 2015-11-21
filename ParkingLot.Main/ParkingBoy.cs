using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotManagement.Main
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> parkingLots;

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
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