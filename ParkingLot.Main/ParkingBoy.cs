using System.Collections.Generic;

namespace ParkingLotManagement.Main
{
    public class ParkingBoy : IParkable
    {
        private readonly List<ParkingLot> parkingLots;
        private readonly IParkStrategy parkingStrategy;
        private readonly PickService pickService;

        public ParkingBoy(List<ParkingLot> parkingLots, IParkStrategy parkingStrategy)
        {
            this.parkingLots = parkingLots;
            this.parkingStrategy = parkingStrategy;
            pickService = new PickService(parkingLots);     
        }

        public int? Park(Car car)
        {
            return parkingStrategy.Park(car, parkingLots);
        }

        public Car Pick(int? ticket)
        {
            return pickService.Pick(ticket);
        }
    }
}