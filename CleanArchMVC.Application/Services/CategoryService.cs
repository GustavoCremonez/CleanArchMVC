using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            IEnumerable<Category> categoriesEntity = await _categoryRepository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int? id)
        {
            Category categoryEntitie = await _categoryRepository.GetCategoryByIdAsync(id);

            return _mapper.Map<CategoryDTO>(categoryEntitie);
        }

        public async Task AddAsync(CategoryDTO categoryDto)
        {
            Category categoryEntitie = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.CreateAsync(categoryEntitie);
        }

        public async Task UpdateAsync(CategoryDTO categoryDto)
        {
            Category categoryEntitie = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.UpdateAsync(categoryEntitie);
        }

        public async Task RemoveAsync(int? id)
        {
            Category categoryEntitie = _categoryRepository.GetCategoryByIdAsync(id).Result;

            await _categoryRepository.RemoveAsync(categoryEntitie);
        }
    }
}