namespace Travel
{
    using System.Collections.Generic;
    using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Airplanes;
	using Entities.Contracts;

	// god loves ugly
	public static class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader;

			if (args.Length == 1)
			{
				var testPath = args.First();
				reader = new Core.IO.StringReader(File.ReadAllText(testPath));
			}
			else
			{
				reader = new ConsoleReader();
			}

			IWriter writer = new ConsoleWriter();

			IAirport airport = new Airport(new List<IBag>(), new List<IBag>(), new List<ITrip>(), new List<IPassenger>());
			IAirportController airportController = new AirportController(airport);
			IFlightController flightController = new FlightController(airport);

			IEngine engine = new Engine(reader, writer, airportController, flightController);

			engine.Run();
		}
	}
}