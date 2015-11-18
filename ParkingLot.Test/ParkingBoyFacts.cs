using ParkingLotManagement.Main;
using Xunit;

namespace ParkingLotManagement.Test
{
    public class ParkingBoyFacts
    {
        [Fact]
        public void should_park_car_by_parking_boy()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();

            var ticket = parkingBoy.Park(car);

            Assert.Equal(car, ParkingLotService.Pick(ticket));
        }

        [Fact]
        public void should_be_able_to_pick_car_by_parking_boy()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();

            var ticket = ParkingLotService.Park(car);

            Assert.Equal(car, parkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_park_car_to_parking_lot_1_if_parking_lot_1_is_not_full()
        {
            
        }
    }
}