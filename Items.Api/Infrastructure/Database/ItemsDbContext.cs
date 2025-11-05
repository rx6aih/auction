namespace Items.Api.Infrastructure.Database;

public class ItemsDbContext : DbContext
{
    public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<Item> Items { get; set; }
}