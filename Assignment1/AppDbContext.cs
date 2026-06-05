using Microsoft.EntityFrameworkCore;

namespace Assignment1
{
	public class AppDbContext : DbContext
	{
		// Table for Blogs
		public DbSet<Blog> Blogs { get; set; }

		// Table for BlogTypes
		public DbSet<BlogType> BlogTypes { get; set; }

		// Table for Posts
		public DbSet<Post> Posts { get; set; }

		// Table for PostTypes
		public DbSet<PostType> PostTypes { get; set; }

		// Table for Users
		public DbSet<User> Users { get; set; }

		// Connects to your SQL Server database
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("your connection string here");
		}
	}
}