using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.BookFeatures.BookMainFeatures.Commands;
using Application.Models.ApiResult;
using Application.Models.BookDtos;
using AutoMapper;
using Identity.Identity.PermissionManager;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Web.Api.ViewModels;
using WebFramework.BaseController;

namespace Web.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/BooksAdmin")]
    //[Authorize(policy: nameof(ConstantPolicies.DynamicPermission))]
    public class BooksAdminController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BooksAdminController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ApiResult<BookDto>), 200)]
        public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        {
            var requestModel = _mapper.Map<BookCreateCommand>(model);
            //TODO:Get user id from claim
            requestModel.UserCreatedId = 1;
            var result = await _mediator.Send(requestModel);
            return result.IsSuccess ? OperationResult(result) : NotFound(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        public IActionResult GetAllBooks()
        {
            return Ok();
        }
    }
}
