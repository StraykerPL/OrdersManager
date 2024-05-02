﻿using OrdersManager.Models.Interfaces;

namespace OrdersManager.Models
{
    public class Order : IOrder
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public string OrderingAddress { get; set; } = string.Empty;

        public OrderStatuses OrderStatus { get; set; } = OrderStatuses.Ordering;

        public DateTime OrderDate { get; set; } = DateTime.MinValue;

        public ICollection<IProduct> OrderedProducts { get; private set; } = [];

        public void FinalizeOrder(ICollection<IProduct> products)
        {
            if (OrderingAddress is null or "")
            {
                return;
            }

            if (products == null || products.Count == 0)
            {
                return;
            }

            foreach (var product in products)
            {
                OrderedProducts.Add(product);
            }

            OrderDate = DateTime.UtcNow;
            OrderStatus = OrderStatuses.Packaging;
        }
    }
}