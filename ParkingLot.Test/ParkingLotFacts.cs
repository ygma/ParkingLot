using ParkingLotManagement.Main;
using Xunit;

namespace ParkingLotManagement.Test
{
    public class ParkingLotFacts
    {
        [Fact]
        public void should_pick_the_parked_car_when_park_a_car()
        {
            var car = new Car();

            var ticket = ParkingLotService.Park(car);

            Assert.Equal(car, ParkingLotService.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_a_car_from_empty_parking_lot_when_use_invalid_ticket()
        {
            var invalidTicket = 1;

            var actual = ParkingLotService.Pick(invalidTicket);

            Assert.Equal(null, actual);
        }

        [Fact]
        public void should_not_pick_a_car_when_use_invalid_ticket_and_exist_car_in_parking_lot()
        {
            var car1 = new Car();
            ParkingLotService.Park(car1);
            var invalidTicket = 1;

            var actual = ParkingLotService.Pick(invalidTicket);

            Assert.Equal(null, actual);
        }

        [Fact]
        public void should_return_success_first_then_return_not_found_when_try_to_pick_car_twice()
        {
            var car = new Car();
            var ticket = ParkingLotService.Park(car);
            ParkingLotService.Pick(ticket);

            var secondResult = ParkingLotService.Pick(ticket);

            Assert.Equal(null, secondResult);
        }
    }
}
