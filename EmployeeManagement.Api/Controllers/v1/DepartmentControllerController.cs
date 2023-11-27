using Application.Common.ResponseModels; 
using Application.Department.Create;
using Application.Department.Delete;
using Application.Department.Get;
using Application.Department.GetById;
using Application.Department.Update;
using Application.Filters; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace EmployeeManagement.Api.Controllers.v1
{
    [Route("api/v1/department")]
    [AllowAnonymous]
    public class DepartmentController : ApiControllerBase
    {
        private readonly IHttpContextAccessor _accessor;
        public DepartmentController(IHttpContextAccessor accessor)           
        { 
            _accessor = accessor; 
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<ActionResult<BaseResponse>> Add([FromBody] CreateDepartmentCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateDepartmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<BaseResponse>> Delete([FromQuery] DeleteDepartmentCommand command)
        {
            return Accepted(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetResponse<DepartmentGetByIdDto>>> GetById(int id)
        {
            var query = new DepartmentGetByIdQuery { Id = id };
            return await Mediator.Send(query);
        }
        [HttpGet]
        public async Task<ActionResult<ListResponse<DepartmentGetByIdDto>>> Get([FromQuery] DepartmentAllQuery query)
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
