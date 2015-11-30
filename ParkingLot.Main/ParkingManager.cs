using System.Collections.Generic;
using System.Linq;
using ParkingLotManagement.Main.ParkingStrategy;

namespace ParkingLotManagement.Main
{
    public class ParkingManager
    {
        private readonly List<ParkingBoy> parkingBoys;
        private readonly SequenceParkStrategy parkingStrategy;
        private readonly PickService pickService;

        public ParkingManager(List<ParkingBoy> parkingBoys = null, List<ParkingLot> parkingLots = null)
        {
            this.parkingBoys = parkingBoys ?? new List<ParkingBoy>();
            parkingStrategy = new SequenceParkStrategy(parkingLots ?? new List<ParkingLot>());
            pickService = new PickService(parkingLots ?? new List<ParkingLot>());
        }

        public int? Park(Car car)
        {
            foreach (var parkingBoy in parkingBoys)
            {
                var ticket = parkingBoy.Park(car);

                if (ticket.HasValue) 
                    return ticket;
            }

            return parkingStrategy.Park(car);
        }

        public Car Pick(int? ticket)
        {
            foreach (var parkingBoy in parkingBoys)
            {
                var car = parkingBoy.Pick(ticket);

                if (car != null)
                    return car;
            }
            return pickService.Pick(ticket);
        }
    }
}