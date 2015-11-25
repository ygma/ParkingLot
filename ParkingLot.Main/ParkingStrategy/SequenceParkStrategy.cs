using System.Collections.Generic;

namespace ParkingLotManagement.Main.ParkingStrategy
{
    public class SequenceParkStrategy : IParkStrategy
    {
        private readonly List<ParkingLot> parkingLots;

        public SequenceParkStrategy(List<ParkingLot> parkingLots)
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
    }
}