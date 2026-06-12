using Microsoft.EntityFrameworkCore;

namespace Assignment1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (var context = new AppDbContext())
			{
				// -----------------------------
				// STEP 1: Add Users
				// -----------------------------
				var user1 = new User { Name = "Vaishnavi Gajjar", EmailAddress = "vaishnavi@email.com", PhoneNumber = "416-111-2222" };
				var user2 = new User { Name = "Parthiv Gajjar", EmailAddress = "parthiv@email.com", PhoneNumber = "416-333-4444" };
				var user3 = new User { Name = "Ravi Mistry", EmailAddress = "ravi@email.com", PhoneNumber = "416-555-6666" };
				var user4 = new User { Name = "Dhruval Suthar", EmailAddress = "dhruval@email.com", PhoneNumber = "416-777-8888" };
				var user5 = new User { Name = "Divam Suthar", EmailAddress = "ds@email.com", PhoneNumber = "416-999-0000" };

				context.Users.AddRange(user1, user2, user3, user4, user5);
				context.SaveChanges();

				Console.WriteLine("5 users added!");

				// -----------------------------
				// STEP 1.5: Ensure a Blog, BlogType, and PostTypes exist
				// -----------------------------
				// Posts need a valid BlogId and PostTypeId (foreign keys),
				// so we create those records first if they don't exist.
				var blogType = new BlogType { Status = "Active", Name = "Tech", Description = "Technology blog" };
				context.BlogTypes.Add(blogType);
				context.SaveChanges();

				var blog = new Blog { Url = "https://myblog.com", IsPublic = true, BlogTypeId = blogType.BlogTypeId };
				context.Blogs.Add(blog);
				context.SaveChanges();

				var postType1 = new PostType { Status = "Active", Name = "Article", Description = "Long-form article" };
				var postType2 = new PostType { Status = "Active", Name = "Note", Description = "Short note" };
				context.PostTypes.AddRange(postType1, postType2);
				context.SaveChanges();

				Console.WriteLine("Blog, BlogType, and PostTypes created!");

				// -----------------------------
				// STEP 2: Add Posts linked to Users
				// -----------------------------
				var post1 = new Post
				{
					Title = "My First Post",
					Content = "Hello from EF Core!",
					BlogId = blog.BlogId,
					PostTypeId = postType1.PostTypeId,
					UserId = user1.UserId   // linked to Vaishnavi
				};

				var post2 = new Post
				{
					Title = "Learning EF Core Migrations",
					Content = "Migrations make schema changes easy.",
					BlogId = blog.BlogId,
					PostTypeId = postType1.PostTypeId,
					UserId = user2.UserId   // linked to Parthiv
				};

				var post3 = new Post
				{
					Title = "Database Relationships 101",
					Content = "Foreign keys connect related tables.",
					BlogId = blog.BlogId,
					PostTypeId = postType2.PostTypeId,
					UserId = user3.UserId   // linked to Ravi
				};

				var post4 = new Post
				{
					Title = "Why I Love C#",
					Content = "Strongly typed languages catch bugs early.",
					BlogId = blog.BlogId,
					PostTypeId = postType1.PostTypeId,
					UserId = user4.UserId   // linked to Dhruval
				};

				var post5 = new Post
				{
					Title = "Tips for Clean Code",
					Content = "Keep methods short and well-named.",
					BlogId = blog.BlogId,
					PostTypeId = postType2.PostTypeId,
					UserId = user5.UserId   // linked to Divam
				};

				context.Posts.AddRange(post1, post2, post3, post4, post5);
				context.SaveChanges();

				Console.WriteLine("5 posts added, each linked to a user!");

				// -----------------------------
				// STEP 3: Display all posts with their authors
				// -----------------------------
				Console.WriteLine("\n--- All Posts ---");

				var allPosts = context.Posts
					.Include(p => p.User)   // join with User table
					.ToList();

				foreach (var post in allPosts)
				{
					Console.WriteLine($"\"{post.Title}\" by {post.User?.Name ?? "Unknown"}");
				}
			}
		}
	}
}