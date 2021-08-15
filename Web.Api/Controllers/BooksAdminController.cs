using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Application.Features.BookFeatures.BookMainFeatures.Commands;
using Application.Features.BookFeatures.BookMainFeatures.Commands.Create;
using Application.Features.BookFeatures.BookMainFeatures.Commands.Delete;
using Application.Features.BookFeatures.BookMainFeatures.Commands.Publish_Unpublish;
using Application.Features.BookFeatures.BookMainFeatures.Commands.Update;
using Application.Features.BookFeatures.BookMainFeatures.Queries;
using Application.Models.ApiResult;
using Application.Models.BookDtos;
using AutoMapper;
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
    [Authorize(Roles = "admin")]
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
        [HttpPut("[action]")]
        [ProducesResponseType(typeof(ApiResult<BookDto>), 200)]
        public async Task<IActionResult> UpdateBook(UpdateBookViewModel model)
        {
            var requestModel = _mapper.Map<BookUpdateCommand>(model);
            //TODO:Get user id from claim
            requestModel.UserCreatedId = 1;
            var result = await _mediator.Send(requestModel);
            return result.IsSuccess ? OperationResult(result) : NotFound(result.ErrorMessage);
        }
        [HttpDelete("[action]")]
 
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            var requestModel = new BookDeleteCommand {BookId = bookId};
            var result = await _mediator.Send(requestModel);
            return result.IsSuccess ? OperationResult(result) : NotFound(result.ErrorMessage);
        }
        [HttpPatch("[action]")]

        public async Task<IActionResult> PublishBook(Guid bookId)
        {
            var requestModel = new BookPublishCommand() { BookId = bookId };
            var result = await _mediator.Send(requestModel);
            return result.IsSuccess ? OperationResult(result) : NotFound(result.ErrorMessage);
        }
        [HttpPatch("[action]")]

        public async Task<IActionResult> UnPublishBook(Guid bookId)
        {
            var requestModel = new BookUnPublishCommand() { BookId = bookId };
            var result = await _mediator.Send(requestModel);
            return result.IsSuccess ? OperationResult(result) : NotFound(result.ErrorMessage);
        }
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ApiResult<List<BookDto>>), 200)]
        public async Task<IActionResult> GetAllBooks()
        {
            var model = new BookGetAllQuery();
            var result =await _mediator.Send(model);
            return result.IsSuccess ? OperationResult(result) : NotFound(result.ErrorMessage);

        }
    }
}
