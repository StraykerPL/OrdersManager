using OrdersManager.UserInterface.Interfaces;

namespace OrdersManager.UserInterface
{
    public sealed class ConsoleInputProvider : IInputProvider
    {
        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}