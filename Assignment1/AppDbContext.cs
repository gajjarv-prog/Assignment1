using Microsoft.EntityFrameworkCore;

namespace Assignment1
{
	// This class represents our database session.
	// It lets us query and save data using C# objects (no raw SQL needed).
	public class AppDbContext : DbContext
	{
		// Represents the "Blogs" table in the database
		public DbSet<Blog> Blogs { get; set; }

		// Represents the "BlogTypes" table in the database
		public DbSet<BlogType> BlogTypes { get; set; }

		// Represents the "Posts" table in the database
		public DbSet<Post> Posts { get; set; }

		// Represents the "PostTypes" table in the database
		public DbSet<PostType> PostTypes { get; set; }

		// Represents the "Users" table in the database
		public DbSet<User> Users { get; set; }

		// This method tells EF Core HOW to connect to the database.
		// It's called automatically by EF Core before any database operation.
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			try
			{
				// Connection string breakdown:
				// Server=.\SQLEXPRESS        -> connect to local SQL Server Express instance
				// Database=EFCoreDemo        -> name of the database to use
				// Trusted_Connection=True     -> use Windows Authentication (no username/password needed)
				// TrustServerCertificate=True -> skip SSL certificate validation (common for local dev)
				optionsBuilder.UseSqlServer(
					@"Server=.\SQLEXPRESS;Database=EFCoreDemo;Trusted_Connection=True;TrustServerCertificate=True;"
				);
			}
			catch (Exception d)
			{
				// If something goes wrong setting up the connection,
				// print the error instead of crashing silently.
				Console.WriteLine($"Didn't work: {d}");
			}
		}
	}
}