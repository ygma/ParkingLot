using System.Collections.Generic;

namespace ParkingLotManagement.Main
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            var parkingLots = new List<ParkingLot>(){parkingLot};
            this.parkingLot = parkingLot;
        }

        public int Park(Car car)
        {
            return parkingLot.Park(car);
        }

        public Car Pick(int ticket)
        {
            return parkingLot.Pick(ticket);
        }

        public void AddManagedParkingLot(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }
    }
}