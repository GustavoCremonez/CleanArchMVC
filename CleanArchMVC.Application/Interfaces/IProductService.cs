using CleanArchMVC.Application.DTOs;

namespace CleanArchMVC.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int? id);

        //Task<ProductDTO> GetProductCategoryAsync(int? id);

        Task AddSync(ProductDTO productDTO);

        Task UpdateSync(ProductDTO productDTO);

        Task CreateSync(int? id);
    }
}