using Microsoft.EntityFrameworkCore;
using APIScarby.Models;
public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {

    }

    public DbSet<pharmacy> pharmacys { get; set; }
}