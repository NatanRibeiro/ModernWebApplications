using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernWebStore.Domain.Commands.OrderCommands;
using ModernWebStore.Domain.Entities;

namespace ModernWebStore.ApplicationService
{
    public class OrderApplicationService : BaseApplicationService, IOrderApplicationService
    {
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;

        public OrderApplicationService(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public Order Create(CreateOrderCommand command, string email)
        {
            var user = _userRepository.GetByEmail(email);
            var orderItems = new List<OrderItem>();

            foreach(var item in command.OrderItems)
            {
                var orderItem = new OrderItem();
                var product = _productRepository.Get(item.Product);
                orderItem.AddProduct(product, item.Quantity, item.Price);
                orderItems.Add(orderItem);
            }

            var order = new Order(orderItems, user.Id);
            order.Place();
            _orderRepository.Create(order);

            if (Commit())
                return order;

            return null;
        }

        public void Cancel(int id, string email)
        {
            var order = _orderRepository.GetHeader(id, email);
            order.Cancel();
            _orderRepository.Update(order);

            Commit();
        }

        public List<Order> Get(string email, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCreated(string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetPaid(string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetDelivered(string email)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCanceled(string email)
        {
            throw new NotImplementedException();
        }

        public Order GetDetaails(int id, string email)
        {
            throw new NotImplementedException();
        }

        public void Pay(int id, string email)
        {
            throw new NotImplementedException();
        }

        public void Delivery(int id, string email)
        {
            throw new NotImplementedException();
        }
    }
}
