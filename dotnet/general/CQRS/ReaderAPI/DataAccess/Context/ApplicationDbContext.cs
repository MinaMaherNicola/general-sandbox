using Microsoft.EntityFrameworkCore;
using ReaderAPI.DataAccess.Models;

namespace ReaderAPI.DataAccess.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; }
}