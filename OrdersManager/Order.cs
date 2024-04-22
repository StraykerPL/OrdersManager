namespace OrdersManager
{
    public class Order
    {
        public string Id { get; set; } = string.Empty;

        public string OrderingAddress { get; set; } = string.Empty;

        public string OrderStatus { get; set; } = string.Empty;

        public string OrderDate { get; set; } = string.Empty;

        public ICollection<Product> OrderedProducts { get; set; } = new HashSet<Product>();

        public string FinalizeOrder()
        {
            return string.Empty;
        }
    }
}