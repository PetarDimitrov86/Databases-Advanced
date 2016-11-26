namespace PhotoShare.Client.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Commands;
    using Data;
    using Interfaces;
    using Data.Interfaces;

    public class CommandDispatcher : ICommandDispatcher
    {
        private const string CommandsNamespacePath = "PhotoShare.Client.Core.Commands.";
        private const string CommandSuffix = "Command";

        private IUnitOfWork unit;

        public CommandDispatcher(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public IExecutable DispatchCommand(string commandName, string[] commandParameters)
        {
            string commandFullName =
                CommandsNamespacePath +
                commandName +
                CommandSuffix;

            object[] parameters = new object[] { commandParameters };

            IExecutable command = null;
            try
            {
                command = (Command)Activator.CreateInstance(Type.GetType(commandFullName), parameters);
            }
            catch
            {
                throw new InvalidOperationException("Invalid command!");
            }

            command = this.InjectDependencies(command);
            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] commandFields = command.GetType()
                                              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] dispatcherFields = typeof(CommandDispatcher)
                                              .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in commandFields)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));
                if (fieldAttribute != null)
                {
                    if (dispatcherFields.Any(x => x.FieldType == field.FieldType))
                    {
                        field.SetValue(command,
                            dispatcherFields.First(x => x.FieldType == field.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return command;
        }
    }
}
