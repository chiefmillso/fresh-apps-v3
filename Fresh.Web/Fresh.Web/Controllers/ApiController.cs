using System.Web.Http;
using Fresh.Core.Web.Security.Attributes;
using MediatR;

namespace Fresh.Web.Controllers
{
    [RequireHttpsInProduction]
    public class FreshController : ApiController
    {
        private readonly IMediator _mediator;

        public FreshController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [System.Web.Http.HttpGet]
        [Route("api/echo/{input}")]
        public string Echo(string input)
        {
            return input;
        }
    }
}