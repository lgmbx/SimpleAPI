using Microsoft.AspNetCore.Mvc;
using SimpleApi.Application.Models.BaseReponse;
using System.Net;

namespace SimpleApi.Api.Controllers
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult InternalErrorResponse(Exception exception)
        {
            var response = new BaseApiResponse<string>();
            response.AddErrors(exception.Message);
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }

        protected IActionResult BadRequestResponse(string message)
        {
            var response = new BaseApiResponse<string>();
            response.AddErrors(message);
            return StatusCode((int)HttpStatusCode.BadRequest, response);
        }

        protected IActionResult ValidationErrorResponse(List<string> messages)
        {
            var response = new BaseApiResponse<string>();
            messages.ForEach(x => response.AddErrors(x));
            return StatusCode((int)HttpStatusCode.BadRequest, response);
        }
    }
}
