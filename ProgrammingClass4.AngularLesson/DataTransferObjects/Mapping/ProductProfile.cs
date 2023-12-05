using AutoMapper;
using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        { 
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>()
                .ForMember(productModel => productModel.ManufacturerId, options => options.MapFrom(productDto => productDto.Manufacturer!.Id))
                .ForMember(productModel => productModel.Manufacturer, options => options.Ignore());
        }
    }
}
