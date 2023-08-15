using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            IEnumerable<Product> productEntities = await _productRepository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(productEntities);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            Product productEntity = await _productRepository.GetProductByIdAsync(id);

            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            Product productEntity = await _productRepository.GetProductCategoryAsync(id);

            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task AddSync(ProductDTO productDTO)
        {
            Product productEntity = _mapper.Map<Product>(productDTO);

            await _productRepository.CreateAsync(productEntity);
        }

        public async Task UpdateSync(ProductDTO productDTO)
        {
            Product productEntity = _mapper.Map<Product>(productDTO);

            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task CreateSync(int? id)
        {
            Product productEntity = _productRepository.GetProductByIdAsync(id).Result;

            await _productRepository.RemoveAsync(productEntity);
        }
    }
}