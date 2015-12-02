using System.Collections.Generic;
using System.Linq;
using ParkingLotManagement.Main.ParkingStrategy;

namespace ParkingLotManagement.Main
{
    public class ParkingManager
    {
        private  List<ParkingLot> parkingLots;
        private readonly List<ParkingBoy> parkingBoys;
        private readonly SequenceParkStrategy parkingStrategy;
        private readonly PickService pickService;

        public ParkingManager(List<ParkingBoy> parkingBoys = null, List<ParkingLot> parkingLots = null)
        {
            this.parkingLots = parkingLots ?? new List<ParkingLot>();
            this.parkingBoys = parkingBoys ?? new List<ParkingBoy>();
            parkingStrategy = new SequenceParkStrategy();
            pickService = new PickService(parkingLots ?? new List<ParkingLot>());
        }

        public int? Park(Car car)
        {
            var parkableList = new List<IParkable>();
            parkableList.AddRange(parkingLots);
            parkableList.AddRange(parkingBoys);

            foreach (var parkable in parkableList)
            {
                var ticket = parkable.Park(car);

                if (ticket.HasValue) 
                    return ticket;
            }

            return null;
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