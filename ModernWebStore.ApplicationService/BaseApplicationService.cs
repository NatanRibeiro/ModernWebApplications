using ModernWebStore.Infrastructure.Persistence;
using ModernWebStore.SharedKernel;
using ModernWebStore.SharedKernel.Events;

namespace ModernWebStore.ApplicationService
{
    public class BaseApplicationService
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;

        public BaseApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
