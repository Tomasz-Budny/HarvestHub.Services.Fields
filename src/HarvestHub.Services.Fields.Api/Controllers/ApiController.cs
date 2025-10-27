using HarvestHub.Shared.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Services.Fields.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected readonly ISender _sender;
        protected readonly IUserContextService _userContextService;

        protected ApiController(ISender sender, IUserContextService userContextService)
        {
            _sender = sender;
            _userContextService = userContextService;
        }
    }
}
