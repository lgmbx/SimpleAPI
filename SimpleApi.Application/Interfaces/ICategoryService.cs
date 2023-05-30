using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Models;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Domain.Entities;

namespace SimpleApi.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<BaseApiResponse<List<CategoryResponseDTO>>> GetAllCategories();
        Task<BaseApiResponse<CategoryResponseDTO>> AddCategory(CategoryRequestDTO category);
        Task<BaseApiResponse<CategoryResponseDTO>> GetCategoryById(int id);
        Task<BaseApiResponse<CategoryResponseDTO>> UpdateCategory(int id, CategoryRequestDTO category);
        Task<BaseApiResponse<bool>> DeleteCategory(int id);
    }

}
