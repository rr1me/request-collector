using Microsoft.EntityFrameworkCore;

namespace requestCollector;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<Request> Requests { get; set; }
}