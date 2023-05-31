using Microsoft.Extensions.DependencyInjection;
using SimpleApi.Application.Services;
using SimpleApi.Application.Interfaces;
using SimpleApi.Domain.Interfaces;
using SimpleApi.Data.Repositories;
using AutoMapper;
using SimpleApi.Application.Mappings;
using FluentValidation;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Application.Validators;

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
            
            //repos
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //validators
            services.AddScoped<IValidator<ProductRequestDTO>, ProductRequestDTOValidator>();
            services.AddScoped<IValidator<CategoryRequestDTO>, CategoryRequestDTOValidator>();

        }

    }
}
