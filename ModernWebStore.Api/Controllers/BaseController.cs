using ModernWebStore.SharedKernel;
using ModernWebStore.SharedKernel.Events;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class BaseController : ApiController
    {
        public IHandler<DomainNotification> Notifications;
        public HttpResponseMessage ResponseMessage;

        public BaseController()
        {
            Notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            ResponseMessage = new HttpResponseMessage();
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            ResponseMessage = Notifications.HasNotifications() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = Notifications.Notify() }) :
                Request.CreateResponse(code, result);

            return Task.FromResult<HttpResponseMessage>(ResponseMessage);
        }

        protected override void Dispose(bool disposing)
        {
            Notifications.Dispose();
        }
    }
}