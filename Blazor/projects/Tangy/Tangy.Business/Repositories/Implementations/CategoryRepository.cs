using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tangy.Business.Repositories.Contracts;
using Tangy.DataAccess.Data;
using Tangy.DataAccess.Data.Models;
using Tangy.Models.DTOs;

namespace Tangy.Business.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> Create(CategoryDto categoryDto)
        {
            EntityEntry<Category> addedCategory = await context.Categories.AddAsync(mapper.Map<Category>(categoryDto));
            await context.SaveChangesAsync();
            return mapper.Map<CategoryDto>(addedCategory.Entity);
        }

        public async Task<int> Delete(Guid id)
        {
            context.Categories.Remove((await context.Categories.FindAsync(id))!);
            return await context.SaveChangesAsync();
        }

        public async Task<CategoryDto> Get(Guid id)
        {
            return mapper.Map<CategoryDto>(await context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id));
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            return mapper.Map<List<CategoryDto>>(await context.Categories.AsNoTracking().ToListAsync());
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            context.Categories.Update(mapper.Map<Category>(categoryDto));
            await context.SaveChangesAsync();
            return categoryDto;
        }
    }
}
