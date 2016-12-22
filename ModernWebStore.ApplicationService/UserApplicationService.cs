using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infrastructure.Persistence;
using ModernWebStore.Domain.Commands.UserCommands;
using ModernWebStore.Domain.Entities;

namespace ModernWebStore.ApplicationService
{
    public class UserApplicationService : BaseApplicationService, IUserApplicationService
    {
        private IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public User Authenticate(string email, string password)
        {
            return _repository.Authenticate(email, password);
        }

        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.Email, command.Password, command.IsAdmin);
            user.Register();
            _repository.Register(user);

            if (Commit())
                return user;

            return null;
        }
    }
}
