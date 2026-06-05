using System.Reflection.Metadata;

namespace Assignment1
{
	public class Post
	{
		// Unique ID for each post (Primary Key)
		public int PostId { get; set; }

		// Title of the post
		public string Title { get; set; }

		// Main text/body of the post
		public string Content { get; set; }

		// Links this post to a Blog
		public int BlogId { get; set; }

		// Links this post to a Post Type
		public int PostTypeId { get; set; }

		// Links this post to a User (Foreign Key)
		public int UserId { get; set; }

		// Used to access the related Blog object
		public Blog Blog { get; set; }

		// Used to access the related PostType object
		public PostType PostType { get; set; }

		// Used to access the related User object
		public User User { get; set; }
	}
}