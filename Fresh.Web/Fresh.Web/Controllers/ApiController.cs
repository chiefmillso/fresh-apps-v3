using System.Web.Http;
using Fresh.Core.Web.Security.Attributes;

namespace Fresh.Web.Controllers
{
    [RequireHttpsInProduction]
    public class FreshController : ApiController
    {
        [HttpGet]
        [Route("api/echo/{input}")]
        public string Echo(string input)
        {
            return input;
        }
    }
}