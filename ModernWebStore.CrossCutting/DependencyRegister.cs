using Microsoft.Practices.Unity;
using ModernWebStore.ApplicationService;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infrastructure.Persistence;
using ModernWebStore.Infrastructure.Persistence.DataContext;
using ModernWebStore.Infrastructure.Repositories;
using ModernWebStore.SharedKernel;
using ModernWebStore.SharedKernel.Events;

namespace ModernWebStore.CrossCutting
{
    public static class DependencyRegister
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve gera uma nova instancia.
        /// HierarchicalLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>
        public static void Register(UnityContainer container)
        {
            container.RegisterType<StoreDataContext, StoreDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserApplicationService, UserApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryApplicationService, CategoryApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductApplicationService, ProductApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderApplicationService, OrderApplicationService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
        }
    }
}
