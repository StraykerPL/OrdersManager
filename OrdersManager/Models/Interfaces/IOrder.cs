namespace OrdersManager.Models.Interfaces
{
    public interface IOrder : IBaseEntity
    {
        string OrderingAddress { get; set; }

        OrderStatuses OrderStatus { get; set; }

        DateTime OrderDate { get; }

        ICollection<Product> OrderedProducts { get; }

        void FinalizeOrder(ICollection<Product> products);
    }
}