using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.BookFeatures.BookMainFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using WebFramework.BaseController;

namespace Web.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/Book")]
    //[Authorize(policy: nameof(ConstantPolicies.DynamicPermission))]
    [Authorize(Roles = "admin,verifiedUser")]
    public class BookController : BaseController
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPublishedBooks()
        {
            var model = new BookGetPublishedQuery();
            var result = await _mediator.Send(model);
            return result.IsSuccess ? OperationResult(result) : NotFound(result.ErrorMessage);

        }
    }
}
