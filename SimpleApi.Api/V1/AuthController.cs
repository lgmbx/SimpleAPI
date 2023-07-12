using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Api.Controllers;
using SimpleApi.Api.Helpers;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.DTOs.ResponseDTO;
using SimpleApi.Application.Interfaces;
using SimpleApi.Application.Models.BaseReponse;
using System.Net;

namespace SimpleApi.Api.V1
{
    public class AuthController : BaseController
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        private readonly IValidator<UserRequestDTO> userRequestValidator;
        private readonly IValidator<LoginDTO> loginValidator;

        public AuthController(IUserService userService, IConfiguration configuration, IValidator<UserRequestDTO> userRequestValidator, IValidator<LoginDTO> loginValidator)
        {
            this.userService = userService;
            this.configuration = configuration;
            this.userRequestValidator = userRequestValidator;
            this.loginValidator = loginValidator;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(BaseApiResponse<UserResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserRequestDTO request)
        {
            try
            {
                var validationResult = userRequestValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return ValidationErrorResponse(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
                }

                var response = await userService.RegisterUser(request);

                return Ok(response);
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesErrorResponseType(typeof(BadRequestResult))]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            try
            {
                var validationResult = loginValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return ValidationErrorResponse(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
                }

                var response = await userService.Login(request);

                if (!response.IsSuccessful)
                {
                    return BadRequestResponse("Invalid username or password");
                }

                var key = configuration.GetSection("Jwt:Key").Value!;
                var token = TokenHelper.GenerateToken(response.Response!, key);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        
    }
}
