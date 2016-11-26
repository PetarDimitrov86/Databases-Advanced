namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Interfaces;
    using IO;
    using Data.Interfaces;

    class Application
    {
        static void Main()
        {
            IUnitOfWork unit = new UnitOfWork();
            ICommandDispatcher commandDispatcher = new CommandDispatcher(unit);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IRunnable engine = new Engine(commandDispatcher, reader, writer);
            engine.Run();
        }
    }
}