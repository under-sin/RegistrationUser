using Microsoft.EntityFrameworkCore;
using RegistrationUserApi.Domain.Entities;

namespace RegistrationUserApi.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(x => x.Id);
        modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
        modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(120).HasColumnType("varchar(120)");
    }
}