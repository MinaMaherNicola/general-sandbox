using Tangy.Models.DTOs;

namespace Tangy.Business.Repositories.Contracts
{
    public interface IProductPriceRepository
    {
        Task<ProductPriceDto> Create(ProductPriceDto productPrice);
        Task<List<ProductPriceDto>> CreateBulk(List<ProductPriceDto> productPrices);
        Task<ProductPriceDto> Get(Guid id);
        Task<List<ProductPriceDto>> GetAll(Guid productId);
        Task<int> Delete(Guid id);
        Task<ProductPriceDto> Update(ProductPriceDto productPrice);
    }
}
