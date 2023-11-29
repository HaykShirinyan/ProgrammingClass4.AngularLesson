using AutoMapper;
using ProgrammingClass4.AngularLesson.DataTransferObjects;
using ProgrammingClass4.AngularLesson.Models;
using ProgrammingClass4.AngularLesson.Repositories.Definitions;
using ProgrammingClass4.AngularLesson.Services.Definitions;

namespace ProgrammingClass4.AngularLesson.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<ProductDto> GetAllProducts()
        {
            var productModelList = _productRepository.GetAllProducts();
            var productDtoList = _mapper.Map<List<Product>, List<ProductDto>>(productModelList);

            return productDtoList;
        }

        public ProductDto? GetProduct(int id) 
        { 
            var productModel = _productRepository.GetProduct(id);

            if (productModel != null) 
            {
                var productDto = _mapper.Map<Product, ProductDto>(productModel);
                return productDto;
            }

            return null;
        }

        public ProductDto AddProduct(ProductDto product)
        {
            var productModel = _mapper.Map<ProductDto, Product>(product);

            var addedProduct = _productRepository.AddProduct(productModel);
            var addedProductDto = _mapper.Map<Product, ProductDto>(addedProduct);

            return addedProductDto;
        }

        public ProductDto UpdateProduct(ProductDto product)
        {
            var productModel = _mapper.Map<ProductDto, Product>(product);

            var updatedProduct = _productRepository.UpdateProduct(productModel);
            var updatedProductDto = _mapper.Map<Product, ProductDto>(updatedProduct);

            return updatedProductDto;
        }

        public ProductDto? DeleteProduct(int id)
        {
            var deletedProduct = _productRepository.DeleteProduct(id);

            if (deletedProduct != null)
            {
                var deletedProductDto = _mapper.Map<Product, ProductDto>(deletedProduct);
                return deletedProductDto;
            }

            return null;
        }
    }
}
