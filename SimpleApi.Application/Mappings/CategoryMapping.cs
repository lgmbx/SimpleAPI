using AutoMapper;
using SimpleApi.Application.DTOs.RequestDTO;
using SimpleApi.Domain.Entities;

namespace SimpleApi.Application.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryResponseDTO>()
                .ReverseMap();

            CreateMap<CategoryRequestDTO, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
        
    }
}
