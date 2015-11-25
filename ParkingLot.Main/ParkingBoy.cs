using System.Collections.Generic;
using ParkingLotManagement.Main.ParkingStrategy;

namespace ParkingLotManagement.Main
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> parkingLots;
        private readonly IParkStrategy parkingStrategy;


        public ParkingBoy(List<ParkingLot> parkingLots, IParkStrategy parkingStrategy)
        {
            this.parkingLots = parkingLots;
            this.parkingStrategy = parkingStrategy;       
        }

        public int? Park(Car car)
        {
            return parkingStrategy.Park(car);
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