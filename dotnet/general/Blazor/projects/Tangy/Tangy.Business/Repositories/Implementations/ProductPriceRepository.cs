using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy.Business.Repositories.Contracts;
using Tangy.DataAccess.Data;
using Tangy.DataAccess.Data.Models;
using Tangy.Models.DTOs;

namespace Tangy.Business.Repositories.Implementations
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductPriceRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ProductPriceDto> Create(ProductPriceDto productPrice)
        {
            await context.ProductPrices.AddAsync(mapper.Map<ProductPrice>(productPrice));
            await context.SaveChangesAsync();
            return productPrice;
        }

        public async Task<List<ProductPriceDto>> CreateBulk(List<ProductPriceDto> productPrices)
        {
            await context.ProductPrices.AddRangeAsync(mapper.Map<IEnumerable<ProductPrice>>(productPrices));
            return productPrices;
        }

        public async Task<int> Delete(Guid id)
        {
            context.ProductPrices.Remove(await context.ProductPrices.FindAsync(id));
            return await context.SaveChangesAsync();
        }

        public async Task<ProductPriceDto> Get(Guid id)
        {
            return mapper.Map<ProductPriceDto>(await context.ProductPrices.AsNoTracking().Include(p => p.Product).FirstAsync(p => p.Id == id));
        }

        public async Task<List<ProductPriceDto>> GetAll(Guid productId)
        {
            return mapper.Map<List<ProductPriceDto>>(await context.ProductPrices.AsNoTracking().Where(p => p.ProductId == productId).ToListAsync());
        }

        public async Task<ProductPriceDto> Update(ProductPriceDto productPrice)
        {
            ProductPrice productPriceEntity = (await context.ProductPrices.FindAsync(productPrice.Id))!;
            productPriceEntity.ProductId = productPrice.ProductId;
            productPriceEntity.Size = productPrice.Size;
            productPriceEntity.Price = productPrice.Price;

            await context.SaveChangesAsync();
            return productPrice;
        }
    }
}
