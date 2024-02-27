using Microsoft.EntityFrameworkCore;

namespace TestProject1.Application;

public class Context(DbContextOptions<Context> context) : DbContext(context)
{
    public DbSet<User> Users { get; set; }
}
