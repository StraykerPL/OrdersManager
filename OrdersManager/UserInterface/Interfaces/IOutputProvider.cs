namespace OrdersManager.UserInterface.Interfaces
{
    public interface IOutputProvider
    {
        void OutputLine(string outputData);

        string GetInputLine();
    }
}