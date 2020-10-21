using System;
using System.Collections.Generic;

namespace H5Chocolate
{
    public class Order
    {
        private Guid guid;
        public Guid Guid { get => guid; }

        public OrderStatus status = OrderStatus.Pending;

        private List<Product> orderedItems = new List<Product>();

        public string Message { get; set; }

        public Donation donation;

        //public Address shippingAdress; //TODO: Lägg till klass
        //public Package package; //TODO: Lägg till klass

        public int Count { get => orderedItems.Count; }

        public Order()
        {
            this.guid = Guid.NewGuid();
        }

        public void AddProduct(Product product)
        {
            orderedItems.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            orderedItems.Add(product);
        }

        public string GetOrderedItemsAsString()
        {
            string output = "";
            orderedItems.ForEach(i => output += i.Name + "\n");
            return output;
        }

        public bool Confirm()
        {
            if (orderedItems.Count > 0 && donation != null)
            {
                status = OrderStatus.Confirmed;
                return true;
            }

            return false;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Shipping,
        Delivered
    }
}