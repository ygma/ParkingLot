using System.Collections.Generic;
using ParkingLotManagement.Main.ParkingStrategy;

namespace ParkingLotManagement.Main
{
    public class ParkingBoyFactory
    {
        public static ParkingBoy CreateSuperParkingBoy(List<ParkingLot> parkingLots)
        {
            return new ParkingBoy(parkingLots, new MaxFreeSpaceRateStrategy());
        }

        public static ParkingBoy CreateSmartParkingBoy(List<ParkingLot> parkingLots)
        {
            return new ParkingBoy(parkingLots, new MaxAvailiableCountStrategy());
        }

        public static ParkingBoy CreateParkingBoy(List<ParkingLot> parkingLots)
        {
            return new ParkingBoy(parkingLots, new SequenceParkStrategy());
        }
    }
}