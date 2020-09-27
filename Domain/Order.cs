using System;
using System.Collections.Generic;

namespace H5Chocolate
{
    public class Order
    {
        private int orderNo;
        public int OrderNo
        {
            get => orderNo;
        }

        public OrderStatus status = OrderStatus.Pending;

        private List<Product> orderedItems = new List<Product>();

        public string Message
        {
            get;
            set;
        }

        public Donation donation;
        //public Address adress; //TODO: Lägg till klass
        //public Package package; //TODO: Lägg till klass
        public int Count
        {
            get => orderedItems.Count;
        }

        public Order(int ordernumber)
        {
            this.orderNo = ordernumber;
        }

        public void AddProduct(Product product)
        {
            orderedItems.Add(product);
            Console.WriteLine($"[{product.Name} ordered]");
        }

        public void RemoveProduct(Product product)
        {
            orderedItems.Add(product);
            Console.WriteLine($"[{product.Name} removed]");
        }

        public string GetOrderedItemsAsString()
        {
            string output = "";
            orderedItems.ForEach(i => output += orderedItems.IndexOf(i) + " " + i.Name + "\n");
            return output;
        }

        public bool HasItems()
        {
            return orderedItems.Count > 0;
        }

        public bool IsConfirmable()
        {
            return orderedItems.Count > 0 && donation != null;
        }

        public bool Confirm()
        {
            if (IsConfirmable())
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