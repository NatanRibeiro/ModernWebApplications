using ModernWebStore.Domain.Commands.CategoryCommands;
using ModernWebStore.Domain.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryApplicationService _service;

        public CategoryController(ICategoryApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/categories")]
        public Task<HttpResponseMessage> Get()
        {
            var categories = _service.Get();
            return CreateResponse(HttpStatusCode.Created, categories);
        }

        [HttpGet]
        [Route("api/categories/{skip}/{take}")]
        public Task<HttpResponseMessage> Get(int skip, int take)
        {
            var categories = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.Created, categories);
        }

        [HttpGet]
        [Route("api/categories/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var category = _service.Get(id);
            return CreateResponse(HttpStatusCode.Created, category);
        }

        [HttpPost]
        [Route("api/categories")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateCategoryCommand(
                title: (string)body.title
            );

            var category = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, category);
        }

        [HttpPut]
        [Route("api/categories/{id}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateCategoryCommand(
                id: id,
                title: (string)body.title
            );

            var category = _service.Update(command);
            return CreateResponse(HttpStatusCode.OK, category);
        }

        [HttpDelete]
        [Route("api/categories/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var command = new DeleteCategoryCommand(id: id);

            var category = _service.Delete(command);
            return CreateResponse(HttpStatusCode.OK, category);
        }
    }
}