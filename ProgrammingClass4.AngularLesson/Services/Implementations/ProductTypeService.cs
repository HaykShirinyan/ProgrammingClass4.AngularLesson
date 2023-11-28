using AutoMapper;
using ProgrammingClass4.AngularLesson.DataTransferObjects;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Services.Definitions;

namespace ProgrammingClass4.AngularLesson.Services.Implementations
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductTypeService(IProductTypeRepository productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public List<ProductTypeDto> GetAllProductTypes()
        {
            var productTypeModelList = _productTypeRepository.GetAllProductTypes();
            var productTypeDtoList = _mapper.Map<List<ProductType>, List<ProductTypeDto>>(productTypeModelList);

            return productTypeDtoList;
        }

        public ProductTypeDto? GetProductType(int id)
        {
            var productTypeModel = _productTypeRepository.GetProductType(id);

            if (productTypeModel != null)
            {
                var productTypeDto = _mapper.Map<ProductType, ProductTypeDto>(productTypeModel);
                return productTypeDto;
            }

            return null;
        }

        public ProductTypeDto AddProductType(ProductTypeDto productType)
        {
            var productTypeModel = _mapper.Map<ProductTypeDto, ProductType>(productType);

            var addedProductType = _productTypeRepository.AddProductType(productTypeModel);
            var addedProductTypeDto = _mapper.Map<ProductType, ProductTypeDto>(addedProductType);

            return addedProductTypeDto;
        }

        public ProductTypeDto UpdateProductType(ProductTypeDto productType)
        {
            var productTypeModel = _mapper.Map<ProductTypeDto, ProductType>(productType);

            var updatedProductType = _productTypeRepository.UpdateProductType(productTypeModel);
            var updatedProductTypeDto = _mapper.Map<ProductType, ProductTypeDto>(updatedProductType);

            return updatedProductTypeDto;
        }

        public ProductTypeDto? DeleteProductType(int id)
        {
            var deletedProductType = _productTypeRepository.DeleteProductType(id);

            if (deletedProductType != null)
            {
                var deletedProductTypeDto = _mapper.Map<ProductType, ProductTypeDto>(deletedProductType);
                return deletedProductTypeDto;
            }

            return null;
        }
    }
}
