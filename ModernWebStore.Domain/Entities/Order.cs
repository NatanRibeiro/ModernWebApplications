using ModernWebStore.Domain.Enums;
using ModernWebStore.Domain.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernWebStore.Domain.Entities
{
    public class Order
    {
        private IList<OrderItem> _orderItems;
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public EOrderStatus Status { get; private set; }
        public ICollection<OrderItem> OrderItems
        {
            get { return _orderItems; }
            private set { _orderItems = new List<OrderItem>(value); }
        }
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in _orderItems)
                    total += (item.Price * item.Quantity);

                return total;
            }
        }

        public Order(IList<OrderItem> orderItems, int userId)
        {
            this.Date = DateTime.Now;
            this._orderItems = new List<OrderItem>();
            orderItems.ToList().ForEach(x => AddItem(x));
            this.UserId = userId;
            this.Status = EOrderStatus.Created;
        }

        public void AddItem(OrderItem item)
        {
            if (item.Register())
                _orderItems.Add(item);
        }

        public void Place()
        {
            this.PlaceOrderScopeIsValid();
        }

        public void MarkAsPaid()
        {
            this.Status = EOrderStatus.Paid;
        }

        public void MarkAsDelivered()
        {
            this.Status = EOrderStatus.Delivered;
        }

        public void Cancel()
        {
            this.Status = EOrderStatus.Canceled;
        }
    }
}
