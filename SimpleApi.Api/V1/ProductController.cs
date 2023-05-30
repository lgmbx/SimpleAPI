using Microsoft.AspNetCore.Mvc;
using SimpleApi.Api.Controllers;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Interfaces;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Domain.Entities;
using System.Net;

namespace SimpleApi.Api.V1
{
    public class ProductController : BaseController
    {

        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseApiResponse<ProductResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await productService.GetAllProducts();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseApiResponse<ProductResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await productService.GetProductById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseApiResponse<ProductResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductRequestDTO product)
        {
            try
            {
                var response = await productService.AddProduct(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(BaseApiResponse<ProductResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseApiResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductRequestDTO product)
        {
            try
            {
                var response = await productService.UpdateProduct(id, product);
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
                var response = await productService.DeleteProduct(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

    }
}
