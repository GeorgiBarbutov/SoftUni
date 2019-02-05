namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class Retire : Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            this.repository.RemoveUnit(this.Data[1]);
            string output = $"{this.Data[1]} retired!";

            return output;
        }
    }
}
