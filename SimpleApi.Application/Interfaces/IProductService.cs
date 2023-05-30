using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Domain.Entities;

namespace SimpleApi.Application.Interfaces
{
    public interface IProductService
    {
        Task<BaseApiResponse<List<ProductResponseDTO>>> GetAllProducts();
        Task<BaseApiResponse<ProductResponseDTO>> AddProduct(ProductRequestDTO requestModel);
        Task<BaseApiResponse<ProductResponseDTO>> GetProductById(int id);
        Task<BaseApiResponse<ProductResponseDTO>> UpdateProduct(int id, ProductRequestDTO requestModel);
        Task<BaseApiResponse<bool>> DeleteProduct(int id);
    }

}
