using System;
using Assets.Lib.Ioc;
using Assets.Lib.Logs;

namespace Assets.Lib.Commands
{
    public class CommandService : ICommandContext
    {
        [Inject]
        public BasicIocContainer IocContainer { get; set; }

        [Inject]
        public TeclynUnity Teclyn { get; set; }

        [Inject]
        public ILogger Log { get; set; }

        public T Create<T>() where T : ICommand
        {
            return this.IocContainer.Build<T>();
        }

        public T Create<T>(Action<T> builder) where T : ICommand
        {
            var command = this.Create<T>();

            builder(command);

            return command;
        }

        public void Execute(ICommand command)
        {
            this.Log.Log("Executing command " + command.GetType().Name + "...");

            command.Execute(this);
        }
    }
}