using ModernWebStore.SharedKernel;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace ModernWebStore.Api.Helpers
{
    public class DomainEventsContainer : IContainer
    {
        private IDependencyResolver _resolver;

        public DomainEventsContainer(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public object GetService(Type serviceType)
            => _resolver.GetService(serviceType);

        public T GetService<T>()
            => (T)_resolver.GetService(typeof(T));

        public IEnumerable<object> GetServices(Type serviceType)
            => _resolver.GetServices(serviceType);

        public IEnumerable<T> GetServices<T>()
            => (IEnumerable<T>)_resolver.GetService(typeof(T));
    }
}