namespace Assets.Lib.Commands
{
    public interface ICommand
    {
        void Execute(ICommandContext context);
    }
}