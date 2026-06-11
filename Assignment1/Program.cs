using Microsoft.EntityFrameworkCore;

namespace Assignment1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (var context = new AppDbContext())
			{
				// Add 3 users
				var user1 = new User { Name = "Alice Smith", EmailAddress = "alice@email.com", PhoneNumber = "416-111-2222" };
				var user2 = new User { Name = "Bob Jones", EmailAddress = "bob@email.com", PhoneNumber = "416-333-4444" };
				var user3 = new User { Name = "Carol White", EmailAddress = "carol@email.com", PhoneNumber = "416-555-6666" };

				context.Users.AddRange(user1, user2, user3);
				context.SaveChanges();

				Console.WriteLine("3 users added!");

				// Add a new post linked to user1
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
			}
		}
	}
}