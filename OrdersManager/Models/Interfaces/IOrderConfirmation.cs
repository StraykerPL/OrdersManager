namespace OrdersManager.Models.Interfaces
{
    public interface IOrderConfirmation : IBaseEntity
    {
        IOrder AssignedOrder { get; }

        void DisplayConfirmationInfo();
    }
}