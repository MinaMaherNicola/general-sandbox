using Tangy.Models.DTOs;

namespace Tangy.Business.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> Create(CategoryDto categoryDto);
        Task<CategoryDto> Update(CategoryDto categoryDto);
        Task<int> Delete(Guid id);
        Task<CategoryDto> Get(Guid id);
        Task<List<CategoryDto>> GetAll();
    }
}
