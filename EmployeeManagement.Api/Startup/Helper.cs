using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Startup
{
    public static class Helper
    {
        public static IServiceCollection AddCustomModelState(this IServiceCollection services)
        {
            _ = services.Configure((Action<ApiBehaviorOptions>)(apiBehaviorOptions =>
                    apiBehaviorOptions.InvalidModelStateResponseFactory = actionContext =>
                    {
                        var response = new Application.Common.ResponseModels.BaseResponse
                        {
                            Exception = GetModelStateError(actionContext)
                        };
                        return new BadRequestObjectResult(response);
                    }));
            return services;
        }

        private static string GetModelStateError(ActionContext actionContext)
        {
            var errors = actionContext.ModelState.Values.SelectMany(x => x.Errors)
                            .Select(x => x.ErrorMessage).ToList();
            return string.Join(", ", errors);
        }
    }
}
