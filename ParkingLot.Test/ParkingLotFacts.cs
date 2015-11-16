using System.IO;
using ParkingLot.Main;
using Xunit;

namespace ParkingLot.Test
{
    public class ParkingLotFacts
    {
        [Fact]
        public void should_return_success_message_when_park_and_take_car()
        {
            var car = new Car();

            ParkingLotService.Park(car);
            var actual = ParkingLotService.Take(car);

            Assert.Equal(ResultMessage.TakeSuccess, actual);
        }

        [Fact]
        public void should_return_not_found_message_when_try_to_take_car_which_not_in_parking_lot()
        {
            var carNotInParkingLot = new Car();

            var actual = ParkingLotService.Take(carNotInParkingLot);

            Assert.Equal(ResultMessage.NotFoundInParkingLot, actual);
        }

        [Fact]
        public void should_return_not_found_message_when_try_to_take_another_one_after_park_one_car()
        {
            var car1 = new Car();
            var car2 = new Car();

            ParkingLotService.Park(car1);
            var actual = ParkingLotService.Take(car2);

            Assert.Equal(ResultMessage.NotFoundInParkingLot, actual);
        }

        [Fact]
        public void should_throw_invalid_data_exception_when_try_to_take_car_using_invalid_data()
        {
            Assert.ThrowsDelegate takeDelegate = () => ParkingLotService.Take(null);

            Assert.Throws(typeof (InvalidDataException), takeDelegate);
        }

        [Fact]
        public void should_return_success_first_then_return_not_found_when_try_to_take_car_twice()
        {
            var car = new Car();
            ParkingLotService.Park(car);
            ParkingLotService.Take(car);

            var secondResult = ParkingLotService.Take(car);

            Assert.Equal(ResultMessage.NotFoundInParkingLot, secondResult);
        }
    }
}
