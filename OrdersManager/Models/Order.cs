using OrdersManager.Models.Interfaces;
using OrdersManager.UserInterface.Interfaces;

namespace OrdersManager.Models
{
    public class Order : IOrder
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public string OrderingAddress { get; set; } = string.Empty;

        public OrderStatuses OrderStatus { get; set; } = OrderStatuses.Ordering;

        public DateTime OrderDate { get; set; } = DateTime.MinValue;

        public ICollection<IProduct> OrderedProducts { get; private set; } = [];

        private readonly IOutputProvider _outputProvider;

        public Order(IOutputProvider outputProvider)
        {
            _outputProvider = outputProvider;
        }

        public IOrderConfirmation? FinalizeOrder(ICollection<IProduct> products)
        {
            if (OrderingAddress is null or "")
            {
                return null;
            }

            if (products == null || products.Count == 0)
            {
                return null;
            }

            foreach (var product in products)
            {
                OrderedProducts.Add(product);
            }

            OrderDate = DateTime.UtcNow;
            OrderStatus = OrderStatuses.Packaging;

            return new OrderConfirmation(this, _outputProvider);
        }
    }
}