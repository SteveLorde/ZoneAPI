using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Zone.Data.Models;

namespace Zone.Data;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(e => e.CreatedZones)
            .WithOne(e => e.UserOwner)
            .HasForeignKey(e => e.UserOwnerId)
            .IsRequired();
        
        modelBuilder.Entity<User>()
            .HasMany(e => e.JoinedZones)
            .WithMany(e => e.JoinedUsers)
            .UsingEntity<UsersInZones>();
    }
    
    
    public DbSet<Models.ZoneLobby> Zones { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<UsersInZones> UsersInZones { get; set; }
    public DbSet<User> Users { get; set; }
}