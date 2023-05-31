using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Api.Controllers;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Interfaces;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Application.Validators;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SimpleApi.Api.V1
{
    public class CategoryController : BaseController
    {

        private readonly ICategoryService categoryService;
        private readonly IValidator<CategoryRequestDTO> requestValidator;

        public CategoryController(ICategoryService categoryService, IValidator<CategoryRequestDTO> requestValidator)
        {
            this.categoryService = categoryService;
            this.requestValidator = requestValidator;
        }


        [HttpGet]
        [ProducesResponseType(typeof(BaseApiResponse<CategoryResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await categoryService.GetAllCategories();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseApiResponse<CategoryResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetById([Required, FromRoute] int id)
        {
            try
            {
                var response = await categoryService.GetCategoryById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseApiResponse<CategoryResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CategoryRequestDTO request)
        {
            try
            {
                var errors = RetrieveCategoryRequestValidationErrors(request);
                if(errors != null) 
                {
                    return ValidationErrorResponse(errors);
                }

                var response = await categoryService.AddCategory(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(BaseApiResponse<CategoryResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update([Required, FromRoute]int id, [FromBody] CategoryRequestDTO request)
        {
            try
            {
                var errors = RetrieveCategoryRequestValidationErrors(request);
                if (errors != null)
                {
                    return ValidationErrorResponse(errors);
                }

                var response = await categoryService.UpdateCategory(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(BaseApiResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([Required, FromRoute]int id)
        {
            try
            {
                var response = await categoryService.DeleteCategory(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        private List<string>? RetrieveCategoryRequestValidationErrors(CategoryRequestDTO request)
        {
            var errors = requestValidator.Validate(request).Errors;

            if(errors.Count > 0)
            {
                return errors.Select(x => x.ErrorMessage).ToList();
            }

            return null;
        }
        
    }
}
