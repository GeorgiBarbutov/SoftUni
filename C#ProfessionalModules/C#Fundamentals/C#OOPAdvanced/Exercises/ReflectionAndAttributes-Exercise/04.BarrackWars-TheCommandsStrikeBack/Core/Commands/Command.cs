namespace _03BarracksFactory.Core
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IUnitFactory unitFactory;
        private IRepository repository;

        protected Command(string[] data, IUnitFactory unitFactory, IRepository repository)
        {
            this.Data = data;
            this.UnitFactory = unitFactory;
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return repository; }
            private set { repository = value; }
        }

        protected IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            private set { unitFactory = value; }
        }

        protected string[] Data
        {
            get { return data; }
            private set { data = value; }
        }

        public abstract string Execute();
    }
}
