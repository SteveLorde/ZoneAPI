using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Zone.Data.Data.Models;

namespace Zone.Data.Data;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["DatabaseConnection"]);
    }
    
    
    public DbSet<Models.Zone> Zones { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<User> Users { get; set; }
}