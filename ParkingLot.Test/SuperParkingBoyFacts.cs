using System.Collections.Generic;
using ParkingLotManagement.Main;
using Xunit;

namespace ParkingLotManagement.Test
{
    public class SuperParkingBoyFacts
    {
        [Fact]
        public void should_park_car_when_there_is_one_parking_lot()
        {
            var parkingLot = new ParkingLot(1);
            var superParkingBoy = ParkingBoyFactory.CreateSuperParkingBoy(new List<ParkingLot>{parkingLot});
            var car = new Car();

            var ticket = superParkingBoy.Park(car);

            Assert.Equal(car, parkingLot.Pick(ticket));
        }

        [Fact]
        public void should_park_car_to_parking_lot_with_higher_free_rate()
        {
            var lowerFreeRateParkingLot = new ParkingLot(2);
            lowerFreeRateParkingLot.Park(new Car());
            var higherFreeRateParkingLot = new ParkingLot(2);
            var superParkingBoy = ParkingBoyFactory.CreateSuperParkingBoy(new List<ParkingLot> { lowerFreeRateParkingLot, higherFreeRateParkingLot });
            var car = new Car();

            var ticket = superParkingBoy.Park(car);

            Assert.Null(lowerFreeRateParkingLot.Pick(ticket));
            Assert.Equal(car, higherFreeRateParkingLot.Pick(ticket));
        }

        [Fact]
        public void should_be_able_to_park_car_if_parking_lots_has_same_free_space_rate()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var superParkingBoy = ParkingBoyFactory.CreateSuperParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            var ticket = superParkingBoy.Park(car);

            Assert.Equal(car, superParkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_not_park_car_when_parking_lot_is_0_free_space_rate()
        {
            var parkingLot = new ParkingLot(1);
            parkingLot.Park(new Car());
            var superParkingBoy = ParkingBoyFactory.CreateSuperParkingBoy(new List<ParkingLot> { parkingLot });
            var car = new Car();

            var ticket = superParkingBoy.Park(car);

            Assert.Null(parkingLot.Pick(ticket));
        }

        [Fact]
        public void should_decrease_free_space_rate_when_park_car()
        {
            var parkingLot = new ParkingLot(2);
            var superParkingBoy = ParkingBoyFactory.CreateSuperParkingBoy(new List<ParkingLot>{parkingLot});
            var freeSpaceRateBeforePark = parkingLot.FreeSpaceRate;

            superParkingBoy.Park(new Car());
            var freeSpaceRateAfterPark = parkingLot.FreeSpaceRate;

            Assert.True(freeSpaceRateBeforePark > freeSpaceRateAfterPark);
        }

        [Fact]
        public void should_increase_free_space_rate_when_pick_car()
        {
            var parkingLot = new ParkingLot(2);
            var superParkingBoy = ParkingBoyFactory.CreateSuperParkingBoy(new List<ParkingLot> { parkingLot });
            var ticket = superParkingBoy.Park(new Car());
            var freeSpaceRateBeforePick = parkingLot.FreeSpaceRate;

            superParkingBoy.Pick(ticket);
            var freeSpaceRateAfterPick = parkingLot.FreeSpaceRate;

            Assert.True(freeSpaceRateBeforePick < freeSpaceRateAfterPick);
        }

        [Fact]
        public void should_be_able_to_pick_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(1);
            var parkingBoy = ParkingBoyFactory.CreateSuperParkingBoy(new List<ParkingLot>() { parkingLot });

            var ticket = parkingLot.Park(car);

            Assert.Equal(car, parkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_pick_car_from_parking_lot_2_if_the_car_is_in_parking_lot_2()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var parkingBoy = ParkingBoyFactory.CreateSuperParkingBoy(new List<ParkingLot>() { parkingLot1, parkingLot2 });
            var car = new Car();

            var ticket = parkingLot2.Park(car);

            Assert.Equal(car, parkingBoy.Pick(ticket));
        }
    }
}