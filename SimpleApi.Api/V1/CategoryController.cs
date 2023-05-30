using Microsoft.AspNetCore.Mvc;
using SimpleApi.Api.Controllers;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Interfaces;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Domain.Entities;
using System.Net;

namespace SimpleApi.Api.V1
{
    public class CategoryController : BaseController
    {

        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
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
        public async Task<IActionResult> GetById(int id)
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
        public async Task<IActionResult> Create([FromBody] CategoryRequestDTO category)
        {
            try
            {
                var response = await categoryService.AddCategory(category);
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
        public async Task<IActionResult> Update(int id, [FromBody] CategoryRequestDTO category)
        {
            try
            {
                var response = await categoryService.UpdateCategory(id, category);
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
        public async Task<IActionResult> Delete(int id)
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
    }
}
