namespace ParkingLotManagement.Main
{
    public class ParkingBoy
    {
        public int Park(Car car)
        {
            return ParkingLotService.Park(car);
        }

        public Car Pick(int ticket)
        {
            return ParkingLotService.Pick(ticket);
        }
    }
}