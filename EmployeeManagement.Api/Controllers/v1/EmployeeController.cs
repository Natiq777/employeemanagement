using Application.Common.ResponseModels;
using Application.Delete.Create;
using Application.Employee.Create;
using Application.Employee.Get;
using Application.Employee.GetById;
using Application.Employee.Update;
using Application.Filters;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace EmployeeManagement.Api.Controllers.v1
{
    [Route("api/v1")]
    [AllowAnonymous]
    public class EmployeeController : ApiControllerBase
    {
        private readonly IHttpContextAccessor _accessor;
        public EmployeeController(IHttpContextAccessor accessor)           
        { 
            _accessor = accessor; 
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<ActionResult<BaseResponse>> Add([FromBody] CreateEmployeeCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateEmployeeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<BaseResponse>> Delete([FromQuery] DeleteEmployeeCommand command)
        {
            return Accepted(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetResponse<EmployeeGetByIdDto>>> GetById(int id)
        {
            var query = new EmployeeGetByIdQuery { Id = id };
            return await Mediator.Send(query);
        }
        [HttpGet]
        public async Task<ActionResult<ListResponse<EmployeeGetByIdDto>>> Get([FromQuery] EmployeeAllQuery query)
        {
            if (_accessor.HttpContext.Request.QueryString.HasValue)
            {
                List<CompareExpressionModel> expressionModels = CompareExpressionModels.CompareExpression(_accessor.HttpContext.Request.QueryString.Value);
                query.Filters = expressionModels;
            }
            return await Mediator.Send(query);
        }
    }
}
