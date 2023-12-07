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

        public async Task<List<ProductTypeDto>> GetAllAsync()
        {
            var productTypeModelList = await _productTypeRepository.GetAllAsync();
            var productTypeDtoList =  _mapper.Map<List<ProductType>, List<ProductTypeDto>>(productTypeModelList);

            return productTypeDtoList;
        }

        public async Task<ProductTypeDto?> GetAsync(int id)
        {
            var productTypeModel = await _productTypeRepository.GetAsync(id);

            if (productTypeModel != null)
            {
                var productTypeDto = _mapper.Map<ProductType, ProductTypeDto>(productTypeModel);
                return productTypeDto;
            }

            return null;
        }

        public async Task<ProductTypeDto> AddAsync(ProductTypeDto productType)
        {
            var productTypeModel = _mapper.Map<ProductTypeDto, ProductType>(productType);

            var addedProductType = await _productTypeRepository.AddAsync(productTypeModel);
            var addedProductTypeDto = _mapper.Map<ProductType, ProductTypeDto>(addedProductType);

            return addedProductTypeDto;
        }

        public async Task<ProductTypeDto> UpdateAsync(ProductTypeDto productType)
        {
            var productTypeModel = _mapper.Map<ProductTypeDto, ProductType>(productType);

            var updatedProductType = await _productTypeRepository.UpdateAsync(productTypeModel);
            var updatedProductTypeDto = _mapper.Map<ProductType, ProductTypeDto>(updatedProductType);

            return updatedProductTypeDto;
        }

        public async Task<ProductTypeDto?> DeleteAsync(int id)
        {
            var deletedProductType = await _productTypeRepository.DeleteAsync(id);

            if (deletedProductType != null)
            {
                var deletedProductTypeDto = _mapper.Map<ProductType, ProductTypeDto>(deletedProductType);
                return deletedProductTypeDto;
            }

            return null;
        }
    }
}
