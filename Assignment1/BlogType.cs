namespace Assignment1
{
	public class BlogType
	{
		// Unique ID for each blog type (Primary Key)
		public int BlogTypeId { get; set; }

		// Status of the blog type
		public string Status { get; set; }

		// Name of the blog type
		public string Name { get; set; }

		// Description of the blog type
		public string Description { get; set; }

		// List of blogs with this type
		public List<Blog> Blogs { get; set; }
	}
}