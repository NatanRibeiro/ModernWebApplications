using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Enums;
using System;
using System.Linq.Expressions;

namespace ModernWebStore.Domain.Specs
{
    public static class OrderSpecs
    {
        public static Expression<Func<Order, bool>> GetCreatedOrders(string email)
        => x => x.User.Email == email && x.Status == EOrderStatus.Created;

        public static Expression<Func<Order, bool>> GetPaidOrders(string email)
        => x => x.User.Email == email && x.Status == EOrderStatus.Paid;

        public static Expression<Func<Order, bool>> GetDeliveredOrders(string email)
        => x => x.User.Email == email && x.Status == EOrderStatus.Delivered;

        public static Expression<Func<Order, bool>> GetCanceledOrders(string email)
        => x => x.User.Email == email && x.Status == EOrderStatus.Canceled;
        
        public static Expression<Func<Order, bool>> GetOrdersDetails(int id, string email)
        => x => x.User.Id == id && x.User.Email == email;

        public static Expression<Func<Order, bool>> GetOrdersFromUser(string email)
        => x => x.User.Email == email;
    }
}