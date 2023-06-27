namespace ShoppingOnline.Data;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=CTNAL0083678187\\SQLEXPRESS;Database=ShoppingOnline;Trusted_Connection=true;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Set Ticket relations
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.User)
            .WithMany(t => t.Tickets)
            .HasForeignKey(t => t.UserId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Product)
            .WithMany(t => t.Tickets)
            .HasForeignKey(t => t.ProductId);

        // Set DateNow Default Value on Users
        modelBuilder.Entity<User>()
            .Property(e => e.CreatedAt)
            .HasDefaultValue(DateTime.Now);
    }
}
