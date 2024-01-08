using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy.Business.Repositories.Contracts;
using Tangy.DataAccess.Data;
using Tangy.DataAccess.Data.Models;
using Tangy.Models.DTOs;

namespace Tangy.Business.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductDto product)
        {
            await context.Products.AddAsync(mapper.Map<Product>(product));
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<int> Delete(Guid id)
        {
            context.Products.Remove(await context.Products.FindAsync(id));
            return await context.SaveChangesAsync();
        }

        public async Task<ProductDto> Get(Guid id)
        {
            return mapper.Map<ProductDto>(await context.Products.AsNoTracking().Include(p => p.Category).FirstAsync(p => p.Id == id));
        }

        public async Task<List<ProductDto>> GetAll()
        {
            return mapper.Map<List<ProductDto>>(await context.Products.AsNoTracking().Include(p => p.Category).ToListAsync());
        }

        public async Task<ProductDto> Update(ProductDto product)
        {
            Product productEntity = (await context.Products.FindAsync(product.Id))!;
            productEntity.Name = product.Name;
            productEntity.Description = product.Description;
            productEntity.ShopFavorite = product.ShopFavorite;
            productEntity.CustomerFavorite = product.CustomerFavorite;
            productEntity.Color = product.Color;
            productEntity.ImageUrl = product.ImageUrl;
            productEntity.CategoryId = product.CategoryId.Value;

            context.Products.Update(productEntity);
            await context.SaveChangesAsync();
            return product;
        }
    }
}
