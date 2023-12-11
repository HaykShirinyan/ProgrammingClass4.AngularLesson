using AutoMapper;
using ProgrammingClass4.AngularLesson.Models;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects.Mapping
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile() {

            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductTypeDto, ProductType>();

            CreateMap<ProductType, ReferencedProductTypeDto>()
               .ReverseMap();
        }
           
    }
}
