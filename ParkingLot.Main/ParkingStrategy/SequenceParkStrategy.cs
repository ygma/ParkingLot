using System.Collections.Generic;

namespace ParkingLotManagement.Main.ParkingStrategy
{
    public class SequenceParkStrategy : IParkStrategy
    {
        public override int? Park(Car car, List<ParkingLot> lots)
        {
            foreach (var parkingLot in lots)
            {
                var ticket = parkingLot.Park(car);

                if (ticket.HasValue) return ticket;
            }

            return null;
        }
    }
}