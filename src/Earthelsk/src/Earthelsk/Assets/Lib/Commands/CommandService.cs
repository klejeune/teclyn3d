using System;
using Assets.Lib.Ioc;

namespace Assets.Lib.Commands
{
    public class CommandService
    {
        [Inject]
        public BasicIocContainer IocContainer { get; set; }

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
            command.Execute(null);
        }
    }
}