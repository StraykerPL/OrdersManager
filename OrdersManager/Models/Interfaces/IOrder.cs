namespace OrdersManager.Models.Interfaces
{
    public interface IOrder : IBaseEntity
    {
        string OrderingAddress { get; }

        string OrderStatus { get; set; }

        string OrderDate { get; }

        ICollection<Product> OrderedProducts { get; }

        string FinalizeOrder();
    }
}