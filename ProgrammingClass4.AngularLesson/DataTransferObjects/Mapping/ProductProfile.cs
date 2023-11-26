using AutoMapper;
using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        { 
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
