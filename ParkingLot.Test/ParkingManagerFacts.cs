using System.Collections.Generic;
using ParkingLotManagement.Main;
using Xunit;

namespace ParkingLotManagement.Test
{
    public class ParkingManagerFacts
    {
        [Fact]
        public void should_park_car_in_his_own_parking_lots_if_there_is_no_managed_parking_boys()
        {
            var parkingLot = new ParkingLot(1);
            var parkingLots = new List<ParkingLot>(){parkingLot};
            var parkingManager = new ParkingManager(parkingLots: parkingLots);
            var car = new Car();

            var ticket = parkingManager.Park(car);
            
            Assert.Equal(car, parkingLot.Pick(ticket));
        }

        [Fact]
        public void should_not_park_car_in_his_own_parking_lots_if_there_is_no_managed_parking_boys_and_his_own_Lots_are_full()
        {
            var parkingLot = new ParkingLot(1);
            parkingLot.Park(new Car());
            var parkingLots = new List<ParkingLot>(){parkingLot};
            var parkingManager = new ParkingManager(parkingLots: parkingLots);
            var car = new Car();

            var ticket = parkingManager.Park(car);
            
            Assert.Null(parkingLot.Pick(ticket));
        }

        [Fact]
        public void should_park_car_to_parking_lots_of_parking_boys_if_there_is_no_his_own_parking_lots()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(new List<ParkingLot>(){parkingLot});
            var parkingManager = new ParkingManager(new List<ParkingBoy>{parkingBoy});
            var car = new Car();

            var ticket = parkingManager.Park(car);

            Assert.Equal(car, parkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_park_cars_to_his_own_parking_lots_if_parking_lots_of_parking_boys_are_full()
        {
            var boyParkingLot = new ParkingLot(1);
            boyParkingLot.Park(new Car());
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(new List<ParkingLot>(){boyParkingLot});

            var managerParkingLot = new ParkingLot(1);
            var parkingManager = new ParkingManager(new List<ParkingBoy>(){parkingBoy}, new List<ParkingLot>(){managerParkingLot});

            var car = new Car();
            var ticket = parkingManager.Park(car);

            Assert.Equal(car, managerParkingLot.Pick(ticket));
        }

        [Fact]
        public void should_park_cars_to_parking_lots_of_parking_boys_if_parking_lots_of_parking_manager_are_full()
        {
            var boyParkingLot = new ParkingLot(1);
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(new List<ParkingLot>(){boyParkingLot});

            var managerParkingLot = new ParkingLot(1);
            managerParkingLot.Park(new Car());
            var parkingManager = new ParkingManager(new List<ParkingBoy>(){parkingBoy}, new List<ParkingLot>(){managerParkingLot});

            var car = new Car();
            var ticket = parkingManager.Park(car);

            Assert.Equal(car, boyParkingLot.Pick(ticket));
        }

        [Fact]
        public void should_pick_car_from_his_own_parking_lots_if_there_is_no_managed_parking_boys()
        {
            var parkingLot = new ParkingLot(1);
            var parkingLots = new List<ParkingLot> { parkingLot };
            var parkingManager = new ParkingManager(parkingLots: parkingLots);
            var car = new Car();
            var ticket = parkingLot.Park(car);

            Assert.Equal(car, parkingManager.Pick(ticket));
        }
        
        [Fact]
        public void should_pick_car_from_parking_lots_of_parking_boys_if_there_is_no_parking_lots_of_parking_manager()
        {
            var parkingLot = new ParkingLot(1);
            var parkingLots = new List<ParkingLot> { parkingLot };
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(parkingLots);

            var parkingManager = new ParkingManager(new List<ParkingBoy>(){parkingBoy});

            var car = new Car();
            var ticket = parkingLot.Park(car);

            Assert.Equal(car, parkingManager.Pick(ticket));
        }

        [Fact]
        public void should_pick_car_from_parking_lots_of_parking_manager_if_parking_manager_manages_parking_boys_and_parking_lots()
        {
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(new List<ParkingLot> { new ParkingLot(1) });
            var managerParkingLot = new ParkingLot(1);
            var parkingManager = new ParkingManager(new List<ParkingBoy>(){parkingBoy}, new List<ParkingLot>(){managerParkingLot});

            var car = new Car();
            var ticket = managerParkingLot.Park(car);

            Assert.Equal(car, parkingManager.Pick(ticket));
        }

        [Fact]
        public void should_pick_car_from_parking_lots_of_parking_boys_if_parking_manager_manages_parking_boys_and_parking_lots()
        {
            var boyParkingLot = new ParkingLot(1);
            var parkingBoy = ParkingBoyFactory.CreateParkingBoy(new List<ParkingLot> { boyParkingLot });
            var parkingManager = new ParkingManager(new List<ParkingBoy>(){parkingBoy}, new List<ParkingLot>(){new ParkingLot(1)});

            var car = new Car();
            var ticket = boyParkingLot.Park(car);

            Assert.Equal(car, parkingManager.Pick(ticket));
        }
    }
}