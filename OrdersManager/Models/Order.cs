using OrdersManager.Models.Interfaces;

namespace OrdersManager.Models
{
    public class Order : IOrder
    {
        public string Id { get; private set; } = string.Empty;

        public string OrderingAddress { get; private set; } = string.Empty;

        public string OrderStatus { get; set; } = string.Empty;

        public string OrderDate { get; private set; } = string.Empty;

        public ICollection<Product> OrderedProducts { get; set; } = new List<Product>();

        public string FinalizeOrder()
        {
            return string.Empty;
        }
    }
}