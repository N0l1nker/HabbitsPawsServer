using Microsoft.AspNetCore.Mvc;

namespace HabbitsPawServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ["Product1", "Product2", "Product3"];
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Product{id}";
        }
    }
}