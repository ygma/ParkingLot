using System.Collections.Generic;
using ParkingLotManagement.Main;
using Xunit;

namespace ParkingLotManagement.Test
{
    public class SmarParkingBoyFacts
    {
        [Fact]
        public void should_park_car_by_smart_parking_boy()
        {
            var parkingLot = new ParkingLot(1);
            var smartParkingBoy = ParkingBoyFactory.CreateSmartParkingBoy(new List<ParkingLot>(){parkingLot});
            var car = new Car();

            var ticket = smartParkingBoy.Park(car);

            Assert.Equal(car, parkingLot.Pick(ticket));
        }

        [Fact]
        public void should_park_car_to_parking_lot_1_if_parking_lot_1_has_more_space()
        {
            var parkingLot1 = new ParkingLot(2);
            var parkingLot2 = new ParkingLot(1);
            var car = new Car();
            var smartParkingBoy = ParkingBoyFactory.CreateSmartParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });

            var ticket = smartParkingBoy.Park(car);

            Assert.NotEqual(car, parkingLot2.Pick(ticket));
            Assert.Equal(car, parkingLot1.Pick(ticket));
        }

        [Fact]
        public void should_park_car_to_parking_lot_2_if_parking_lot_2_has_more_space()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(2);
            var car = new Car();
            var smartParkingBoy = ParkingBoyFactory.CreateSmartParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });

            var ticket = smartParkingBoy.Park(car);

            Assert.NotEqual(car, parkingLot1.Pick(ticket));
            Assert.Equal(car, parkingLot2.Pick(ticket));
        }

        [Fact]
        public void should_be_able_to_park_car_when_there_is_multi_parking_lot_with_same_avaliable_space()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var smartParkingBoy = ParkingBoyFactory.CreateSmartParkingBoy(new List<ParkingLot> {parkingLot1, parkingLot2});
            var car = new Car();

            var ticket = smartParkingBoy.Park(car);

            Assert.Equal(car,parkingLot1.Pick(ticket) ?? parkingLot2.Pick(ticket));
        }

        [Fact]
        public void should_get_null_ticket_if_both_parking_lots_are_full()
        {
            var parkingLot1 = new ParkingLot(1);
            parkingLot1.Park(new Car());
            var parkingLot2 = new ParkingLot(1);
            parkingLot2.Park(new Car());
            var smartParkingBoy = ParkingBoyFactory.CreateSmartParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            var ticket = smartParkingBoy.Park(car);

            Assert.Null(ticket);
            Assert.NotEqual(car, parkingLot1.Pick(ticket) ?? parkingLot2.Pick(ticket));
        }

        [Fact]
        public void should_be_able_to_pick_car_by_smart_parking_boy()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(1);
            var parkingBoy = ParkingBoyFactory.CreateSmartParkingBoy(new List<ParkingLot>() { parkingLot });

            var ticket = parkingLot.Park(car);

            Assert.Equal(car, parkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_pick_car_from_parking_lot_2_by_smart_parking_boy_if_the_car_is_in_parking_lot_2()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var parkingBoy = ParkingBoyFactory.CreateSmartParkingBoy(new List<ParkingLot>() { parkingLot1, parkingLot2 });
            var car = new Car();

            var ticket = parkingLot2.Park(car);

            Assert.Equal(car, parkingBoy.Pick(ticket));
        }
    }
}