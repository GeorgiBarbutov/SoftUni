namespace Travel.Core.Commands
{
    using Travel.Core.Controllers.Contracts;

    class RegisterPassengerCommand : Command
    {
        private IAirportController airportController;

        public RegisterPassengerCommand(IAirportController airportController)
        {
            this.airportController = airportController;
        }

        public override void ExecuteCommand()
        {
            //airportController.
        }
    }
}
