using Tangy.Models.DTOs;

namespace Tangy.Business.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<ProductDto> Create(ProductDto product);
        Task<ProductDto> Get(Guid id);
        Task<List<ProductDto>> GetAll();
        Task<int> Delete(Guid id);
        Task<ProductDto> Update(ProductDto product);
    }
}
