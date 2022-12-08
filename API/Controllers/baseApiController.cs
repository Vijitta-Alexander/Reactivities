using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class baseApiController : ControllerBase
    {
        private IMediator _mediator;
        
        protected IMediator mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();
        
    }
}