namespace PhotoShare.Client.Core.Commands
{
    using Interfaces;
    using Attributes;
    using Data.Interfaces;

    public abstract class Command : IExecutable
    {
        private string[] data;
        [Inject]
        protected IUnitOfWork unit;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public abstract string Execute();

        public virtual void CommitChanges()
        {
            this.unit.Commit();
        }
    }
}
