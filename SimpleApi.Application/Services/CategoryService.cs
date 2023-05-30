using AutoMapper;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Interfaces;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Domain.Entities;
using SimpleApi.Domain.Interfaces;

namespace SimpleApi.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseApiResponse<CategoryResponseDTO>> AddCategory(CategoryRequestDTO requestDto)
        {
            var baseResponse = new BaseApiResponse<CategoryResponseDTO>();

            var categoryToCheck = await categoryRepository.GetSingleAsync(x => x.Name == requestDto.Name);

            if(categoryToCheck != null)
            {
                baseResponse.AddErrors("Category already exists");
                return baseResponse;
            }

            var entity = mapper.Map<Category>(requestDto);

            categoryRepository.Add(entity);

            await unitOfWork.Commit();

            var responseDto = mapper.Map<CategoryResponseDTO>(entity);

            baseResponse.Response = responseDto;

            return baseResponse;
        }

        public async Task<BaseApiResponse<bool>> DeleteCategory(int id)
        {
            categoryRepository.Delete(id);

            await unitOfWork.Commit();

            return new BaseApiResponse<bool>(true);
        }

        public async Task<BaseApiResponse<List<CategoryResponseDTO>>> GetAllCategories()
        {
            var entities = await categoryRepository.GetAllAsync();

            var responseDto = mapper.Map<List<CategoryResponseDTO>>(entities.ToList());

            return new BaseApiResponse<List<CategoryResponseDTO>>(responseDto);
        }

        public async Task<BaseApiResponse<CategoryResponseDTO>> GetCategoryById(int id)
        {
            var entity = await categoryRepository.GetByIdAsync(id);

            var responseDto = mapper.Map<CategoryResponseDTO>(entity);

            return new BaseApiResponse<CategoryResponseDTO>(responseDto);
        }

        public async Task<BaseApiResponse<CategoryResponseDTO>> UpdateCategory(int id, CategoryRequestDTO requestDto)
        {
            var baseResponse = new BaseApiResponse<CategoryResponseDTO>();

            var entity = await categoryRepository.GetByIdAsync(id);

            if (entity == null)
            {
                baseResponse.AddErrors("Category doesn't exists!");
                return baseResponse;
            }

            entity.Name = requestDto.Name;

            categoryRepository.Update(entity);
            await unitOfWork.Commit();

            var responseDto = mapper.Map<CategoryResponseDTO>(entity);

            baseResponse.Response = responseDto;

            return baseResponse;
        }



    }
}
