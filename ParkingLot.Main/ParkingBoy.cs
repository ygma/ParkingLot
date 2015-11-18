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

        public int Park(Car car)
        {
            var position = parkingLots.FirstOrDefault(p => !p.IsFull());
            if (position == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            return position.Park(car);
        }

        public Car Pick(int ticket)
        {
            return parkingLots[0].Pick(ticket);
        }
    }
}