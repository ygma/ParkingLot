using System;
using System.Collections.Generic;
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
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>(){parkingLot});

            var ticket = parkingBoy.Park(car);

            Assert.Equal(car, parkingLot.Pick(ticket));
        }

        [Fact]
        public void should_be_able_to_pick_car_by_parking_boy()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>(){parkingLot});

            var ticket = parkingLot.Park(car);

            Assert.Equal(car, parkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_park_car_to_parking_lot_1_if_parking_lot_1_is_not_full()
        {
            var car = new Car();
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>(){parkingLot1, parkingLot2});

            var ticket = parkingBoy.Park(car);

            Assert.Null(parkingLot2.Pick(ticket));
            Assert.Equal(car, parkingLot1.Pick(ticket));
        }

        [Fact]
        public void should_park_car_to_parking_lot_2_if_parking_lot_1_is_full()
        {
            var car = new Car();
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { parkingLot1, parkingLot2 });
            parkingLot1.Park(new Car());

            var ticket = parkingBoy.Park(car);

            Assert.Null(parkingLot1.Pick(ticket));
            Assert.Equal(car, parkingLot2.Pick(ticket));
        }
        
        [Fact]
        public void should_park_cars_in_order_using_multiple_parking_lot()
        {
            var car1 = new Car();
            var car2 = new Car();
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { parkingLot1, parkingLot2 });
            
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);

            Assert.Null(parkingLot1.Pick(ticket2));
            Assert.Null(parkingLot2.Pick(ticket1));
            Assert.Equal(car1, parkingLot1.Pick(ticket1));
            Assert.Equal(car2, parkingLot2.Pick(ticket2));
        }

        [Fact]
        public void should_throw_exception_if_try_to_park_a_car_when_all_parking_lots_are_full()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot>() { parkingLot1, parkingLot2 });
            parkingBoy.Park(new Car());
            parkingBoy.Park(new Car());

            Assert.Throws(typeof(ArgumentOutOfRangeException), () => parkingBoy.Park(new Car()));
        }
    }
}