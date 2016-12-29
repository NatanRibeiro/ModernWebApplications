using ModernWebStore.Domain.Commands.ProductCommands;
using ModernWebStore.Domain.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModernWebStore.Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductApplicationService _service;

        public ProductController(IProductApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/products")]
        public Task<HttpResponseMessage> Get()
        {
            var products = _service.Get();
            return CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("api/products/{skip:int:min(0)}/{take:int:min(1)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take)
        {
            var products = _service.Get(skip, take);
            return CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet]
        [Route("api/products/outofstock")]
        public Task<HttpResponseMessage> GetInStock()
        {
            var products = _service.GetOutOfStock();
            return CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpPost]
        [Route("api/products")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new CreateProductCommand(
                title: (string)body.title,
                categoryId: (int)body.category,
                description: (string)body.description,
                price: (decimal)body.price,
                quantityOnHand: (int)body.quantityOnHand
            );

            var product = _service.Create(command);
            return CreateResponse(HttpStatusCode.Created, product);
        }

        [HttpPut]
        //[Authorize]
        [Route("api/products/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]dynamic body)
        {
            var command = new UpdateProductInfoCommand(
                id: id,
                title: (string)body.title,
                categoryId: (int)body.category,
                description: (string)body.description
            );

            var product = _service.UpdateBasicInformation(command);
            return CreateResponse(HttpStatusCode.OK, product);
        }
    }
}