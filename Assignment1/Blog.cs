namespace Assignment1
{
	public class Blog
	{
		// Unique ID for each blog (Primary Key)
		public int BlogId { get; set; }

		// Web address of the blog
		public string Url { get; set; }

		// Whether the blog is public or private
		public bool IsPublic { get; set; }

		// Links this blog to a Blog Type
		public int BlogTypeId { get; set; }

		// List of all posts in this blog
		public List<Post> Posts { get; set; }

		// Used to access the related BlogType object
		public BlogType BlogType { get; set; }
	}
}