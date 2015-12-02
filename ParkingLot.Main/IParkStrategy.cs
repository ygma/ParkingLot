using System.Collections.Generic;

namespace ParkingLotManagement.Main
{
    public abstract class IParkStrategy
    {
        public abstract int? Park(Car car, List<ParkingLot> lots);
    }
}