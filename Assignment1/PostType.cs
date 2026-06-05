namespace Assignment1
{
	public class PostType
	{
		// Unique ID for each post type (Primary Key)
		public int PostTypeId { get; set; }

		// Status of the post type
		public string Status { get; set; }

		// Name of the post type
		public string Name { get; set; }

		// Description of the post type
		public string Description { get; set; }

		// List of posts with this type
		public List<Post> Posts { get; set; }
	}
}