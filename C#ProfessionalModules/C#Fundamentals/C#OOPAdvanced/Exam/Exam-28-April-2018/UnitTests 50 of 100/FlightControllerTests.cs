// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void TakeOfReturnsCorrectString()
        {
            IAirport airport = new Airport();
            airport.AddTrip(new Trip("source", "Destination", new LightAirplane()));
            airport.AddPassenger(new Passenger("az"));
            airport.AddPassenger(new Passenger("ti"));
            IFlightController flightController = new FlightController(airport);

            string result = flightController.TakeOff();

            Assert.That(result, Is.EqualTo("sourceDestination2:\r\nSuccessfully transported 0 passengers from source to Destination.\r\nConfiscated bags: 0 (0 items) => $0"));
        }

        [Test]
        public void TakeOffIsOverbookedReturnsCorrectString()
        {
            IAirport airport = new Airport();
            
            LightAirplane lightAirplane = new LightAirplane();
            lightAirplane.AddPassenger(new Passenger("az"));
            lightAirplane.AddPassenger(new Passenger("ti"));
            lightAirplane.AddPassenger(new Passenger("toi"));
            lightAirplane.AddPassenger(new Passenger("tq"));
            lightAirplane.AddPassenger(new Passenger("to"));
            lightAirplane.AddPassenger(new Passenger("nie"));
            airport.AddTrip(new Trip("source", "Destination", lightAirplane));
            IFlightController flightController = new FlightController(airport);

            string result = flightController.TakeOff();

            Assert.That(result, Is.EqualTo("sourceDestination1:\r\nOverbooked! Ejected ti\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from source to Destination.\r\nConfiscated bags: 0 (0 items) => $0"));
        }

        //[Test]
        //public void TakeOffWithConfiscatedMoney()
        //{
        //    IAirport airport = new Airport();
        //    airport.AddTrip(new Trip("source", "Destination", new LightAirplane()));
        //    IPassenger passenger = new Passenger("az");
        //    passenger.Bags.Add(new Bag(passenger,IEnumerable<IItems>))
        //    airport.AddPassenger(new Passenger("az"));
        //    airport.AddPassenger(new Passenger("ti"));
        //    IFlightController flightController = new FlightController(airport);

        //    string result = flightController.TakeOff();

        //    Assert.That(result, Is.EqualTo("sourceDestination2:\r\nSuccessfully transported 0 passengers from source to Destination.\r\nConfiscated bags: 0 (0 items) => $0"));
        //}
    }
}
