namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using Entities.Contracts;
    using Travel.Core;
    using Travel.Entities.Airplanes.Contracts;

    // migrated from java. please do the needful kind sir
    public abstract class Airplane : IAirplane
    {
        private IList<IBag> bagsOnPlane;
        private IList<IPassenger> passengers;

        protected Airplane(int seats, int bags)
        {
            this.passengers = new List<IPassenger>();
            this.Seats = seats;
            this.BaggageCompartments = bags;
            this.bagsOnPlane = new List<IBag>();
        }

        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IBag> BaggageCompartment => (IReadOnlyCollection<IBag>)bagsOnPlane;

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public IReadOnlyCollection<IPassenger> Passengers => (IReadOnlyCollection<IPassenger>)passengers;

        public int Seats { get; }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            IList<IBag> returnedBaggage = new List<IBag>();

            foreach (var bag in this.bagsOnPlane)
            {
                if(bag.Owner == passenger)
                {
                    returnedBaggage.Add(bag);
                    //this.bagsOnPlane.Remove(bag);
                }
            }

            return returnedBaggage;
        }

        public void LoadBag(IBag bag)
        {
            if(this.BaggageCompartments <= this.bagsOnPlane.Count)
            {
                throw new InvalidOperationException(string.Format(Constants.NO_MORE_BAG_ROOM, this.GetType().Name));
            }

            this.bagsOnPlane.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            if(passengers[seat] == null)
            {
                throw new ArgumentException(Constants.NO_PASSANGERS_AT_SEAT);
            }

            IPassenger passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);

            return passenger;
        }
    }
}