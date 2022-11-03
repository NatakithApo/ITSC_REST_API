using Microsoft.AspNetCore.Mvc;

namespace REST.DOIT.Controllers
{
    [ApiController]
    [Route("api/v1/meta")]
    public class MetaController : ControllerBase
    {
        [HttpGet("genre")]
        public List<string> GetGenre()
        {
            return new List<string>();
        }
    }
}
