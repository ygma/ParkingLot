using System.Collections.Generic;

namespace ParkingLotManagement.Main
{
    public class ParkingBoy
    {
        private readonly IParkStrategy parkingStrategy;
        private readonly PickService pickService;

        public ParkingBoy(List<ParkingLot> parkingLots, IParkStrategy parkingStrategy)
        {
            this.parkingStrategy = parkingStrategy;
            pickService = new PickService(parkingLots);     
        }

        public int? Park(Car car)
        {
            return parkingStrategy.Park(car);
        }

        public Car Pick(int? ticket)
        {
            return pickService.Pick(ticket);
        }
    }
}