using CleanArchMVC.Application.DTOs;

namespace CleanArchMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();

        Task<CategoryDTO> GetCategoryByIdAsync(int? id);

        Task AddAsync(CategoryDTO categoryDto);

        Task UpdateAsync(CategoryDTO categoryDto);

        Task RemoveAsync(int? id);
    }
}