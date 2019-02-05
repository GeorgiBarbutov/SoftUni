namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
    using Travel.Core;

    public class Airport : IAirport
	{
		private IList<IBag> checkedBags;
		private IList<IBag> notCheckedBags;
		private IList<ITrip> trips;
		private IList<IPassenger> passengers;

        public IReadOnlyCollection<IBag> CheckedInBags => (IReadOnlyCollection<IBag>)checkedBags;

        public IReadOnlyCollection<IBag> ConfiscatedBags => (IReadOnlyCollection<IBag>)notCheckedBags;

        public IReadOnlyCollection<IPassenger> Passengers => (IReadOnlyCollection<IPassenger>)passengers;

        public IReadOnlyCollection<ITrip> Trips => (IReadOnlyCollection<ITrip>)trips;

        public Airport(IList<IBag> checkedBags, IList<IBag> notCheckedBags, IList<ITrip> trips, IList<IPassenger> passengers)
        {
            this.checkedBags = checkedBags;
            this.notCheckedBags = notCheckedBags;
            this.trips = trips;
            this.passengers = passengers;
        }

		public IPassenger GetPassenger(string username)
        {
            IPassenger passenger =  this.passengers.FirstOrDefault(p => p.Username == username);

            return passenger;
        }

        public ITrip GetTrip(string id)
        {
            ITrip trip = this.trips.FirstOrDefault(p => p.Id == id);

            if (trip == null)
            {
                throw new ArgumentException(Constants.TRIP_NOT_FOUND);
            }

            return trip;
        }

		public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

		public void AddTrip(ITrip trip)
        {
            this.trips.Add(trip);
        }

        public void AddCheckedBag(IBag bag)
        {
            this.checkedBags.Add(bag);
        }

        public void AddConfiscatedBag(IBag bag)
        {
            this.notCheckedBags.Add(bag);
        }
    }
}