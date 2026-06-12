using Microsoft.EntityFrameworkCore;

namespace Assignment1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (var context = new AppDbContext())
			{
				var user1 = new User { Name = "Vaishnavi Gajjar", EmailAddress = "vaishnavi@email.com", PhoneNumber = "416-111-2222" };
				var user2 = new User { Name = "Parthiv Gajjar", EmailAddress = "parthiv@email.com", PhoneNumber = "416-333-4444" };
				var user3 = new User { Name = "Ravi Mistry", EmailAddress = "ravi@email.com", PhoneNumber = "416-555-6666" };
				var user4 = new User { Name = "Dhruval Suthar", EmailAddress = "dhruval@email.com", PhoneNumber = "416-777-8888" };
				var user5 = new User { Name = "Divam Suthar", EmailAddress = "ds@email.com", PhoneNumber = "416-999-0000" };

				context.Users.AddRange(user1, user2, user3, user4, user5);
				context.SaveChanges();
				Console.WriteLine("5 users added!");
			
				// Add a new Post linked to a User
				var newPost = new Post
				{
					Title = "My First Post",
					Content = "Hello from EF Core!",
					BlogId = 1,       // must exist already
					PostTypeId = 1,   // must exist already
					UserId = user1.UserId
				};

				context.Posts.Add(newPost);
				context.SaveChanges();
				Console.WriteLine("New post added with user!");

				// Display all posts with their authors
				Console.WriteLine("\n--- All Posts ---");

				var allPosts = context.Posts
					.Include(p => p.User)
					.ToList();

				foreach (var post in allPosts)
				{
					Console.WriteLine($"\"{post.Title}\" by {post.User?.Name ?? "Unknown"}");
				}
			}
		}
	}
}