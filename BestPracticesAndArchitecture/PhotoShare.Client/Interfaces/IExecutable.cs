namespace PhotoShare.Client.Interfaces
{
    public interface IExecutable
    {
        string Execute();

        void CommitChanges();
    }
}
