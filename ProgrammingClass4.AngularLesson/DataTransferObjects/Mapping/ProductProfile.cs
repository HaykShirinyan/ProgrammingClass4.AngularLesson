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
                .ForMember(productModel => productModel.ManufacturerId, options => options.MapFrom(productDto => productDto.Manufacturer!.Id))//Manufacturer.id vercra dir Manufacturerid propertii mej
                .ForMember(productModel => productModel.Manufacturer, options => options.Ignore())//mi ara maping(convert) Product modeli Manufacturer@
                .ForMember(productTypeModel => productTypeModel.ProductTypeId, options => options.MapFrom(productTypeDto => productTypeDto.ProductType!.Id))
                .ForMember(productTypeModel => productTypeModel.ProductType, options => options.Ignore())
                .ForMember(UnitOfMeasureModel => UnitOfMeasureModel.UnitOfMeasureId, options => options.MapFrom(unitOfMeasureDto => unitOfMeasureDto.UnitOfMeasure!.Id))
                .ForMember(UnitOfMeasureModel => UnitOfMeasureModel.UnitOfMeasure, options => options.Ignore());
        }
    }
}
