using System.Reflection;
using Dubai.Inventory.Domain.Products;
using Dubai.Inventory.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dubai.Inventory.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}