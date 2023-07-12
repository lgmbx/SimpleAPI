using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Interfaces;
using SimpleApi.Application.Mappings;
using SimpleApi.Application.Services;
using SimpleApi.Application.Validators;
using SimpleApi.Data.Repositories;
using SimpleApi.Domain.Interfaces;

namespace SimpleApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services) 
        {
            //mapper
            services.AddAutoMapper(typeof(ProductMapping));
            services.AddAutoMapper(typeof(CategoryMapping));

            //uok 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();

            //repos
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //validators
            services.AddScoped<IValidator<ProductRequestDTO>, ProductRequestDTOValidator>();
            services.AddScoped<IValidator<CategoryRequestDTO>, CategoryRequestDTOValidator>();
            services.AddScoped<IValidator<UserRequestDTO>, UserRequestDTOValidator>();
            services.AddScoped<IValidator<LoginDTO>, LoginDTOValidator>();

        }

    }
}
