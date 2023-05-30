using AutoMapper;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Interfaces;
using SimpleApi.Application.Models.BaseReponse;
using SimpleApi.Domain.Entities;
using SimpleApi.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace SimpleApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<BaseApiResponse<ProductResponseDTO>> AddProduct(ProductRequestDTO requestDto)
        {
            var baseResponse = new BaseApiResponse<ProductResponseDTO>();

            var category = await categoryRepository.GetByIdAsync(requestDto.CategoryId);
            
            if(category == null)
            {
                baseResponse.AddErrors("Category not found");
                return baseResponse;
            }
            
            var product = mapper.Map<Product>(requestDto);
            
            productRepository.Add(product);

            await unitOfWork.Commit();

            product.Category = category;

            var productResponse = mapper.Map<ProductResponseDTO>(product);

            baseResponse.Response = productResponse;

            return baseResponse;
        }

        public async Task<BaseApiResponse<bool>> DeleteProduct(int id)
        {
            productRepository.Delete(id);
            await unitOfWork.Commit();
            return new BaseApiResponse<bool>(true);
        }

        public async Task<BaseApiResponse<List<ProductResponseDTO>>> GetAllProducts()
        {
            var products = await productRepository.GetAllAsync();

            var productsDto = mapper.Map<List<ProductResponseDTO>>(products.ToList());

            return new BaseApiResponse<List<ProductResponseDTO>>(productsDto);
        }

        public async Task<BaseApiResponse<ProductResponseDTO>> GetProductById(int id)
        {
            var result = await productRepository.GetByIdAsync(id);

            var productDto = mapper.Map<ProductResponseDTO>(result);

            return new BaseApiResponse<ProductResponseDTO>(productDto);
        }

        public async Task<BaseApiResponse<ProductResponseDTO>> UpdateProduct(int id, ProductRequestDTO requestDto)
        {
            var productToUpdate = await productRepository.GetByIdAsync(id);

            var baseResponse = new BaseApiResponse<ProductResponseDTO>();

            if (productToUpdate == null)
            {
                baseResponse.AddErrors("Product not found");
                return baseResponse;
            }

            productToUpdate.Name = requestDto.Name;
            productToUpdate.CategoryId = requestDto.CategoryId;

            var productResponse = mapper.Map<ProductResponseDTO>(productToUpdate);

            baseResponse.Response = productResponse;

            return baseResponse;
        }
    }
}
