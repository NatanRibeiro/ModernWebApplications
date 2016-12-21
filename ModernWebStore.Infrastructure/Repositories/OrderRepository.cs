using ModernWebStore.Domain.Entities;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Specs;
using ModernWebStore.Infrastructure.Persistence.DataContext;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ModernWebStore.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private StoreDataContext _context;

        public OrderRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Create(Order order)
            => _context.Orders.Add(order);

        public List<Order> Get(string email, int skip, int take)
            => _context.Orders.Where(OrderSpecs.GetOrdersFromUser(email)).OrderByDescending(x => x.Date).Skip(skip).Take(take).ToList();

        public List<Order> GetCanceled(string email)
            => _context.Orders.Where(OrderSpecs.GetCanceledOrders(email)).OrderByDescending(x => x.Date).ToList();

        public List<Order> GetCreated(string email)
            => _context.Orders.Where(OrderSpecs.GetCreatedOrders(email)).OrderByDescending(x => x.Date).ToList();

        public List<Order> GetDelivered(string email)
            => _context.Orders.Where(OrderSpecs.GetDeliveredOrders(email)).OrderByDescending(x => x.Date).ToList();

        public List<Order> GetPaid(string email)
            => _context.Orders.Where(OrderSpecs.GetPaidOrders(email)).OrderByDescending(x => x.Date).ToList();

        public Order GetDetails(int id, string email)
            => _context.Orders.Include(x=> x.OrderItems).Where(OrderSpecs.GetOrdersDetails(id, email)).OrderByDescending(x => x.Date).FirstOrDefault();

        public Order GetHeader(int id, string email)
            => _context.Orders.Where(OrderSpecs.GetOrdersDetails(id, email)).FirstOrDefault();

        public void Update(Order order)
            => _context.Entry<Order>(order).State = EntityState.Modified;
    }
}
