namespace Shop.Core.Commands
{
    internal class QuitApplication : IAppCommand
    {
        public void Execute()
        {

        }
    }

    internal interface IAppCommand
    {
        void Execute();
    }
}