namespace Assignment1
{
	public class User
	{
		// Unique ID for each user (Primary Key)
		public int UserId { get; set; }

		// Name of the user
		public string Name { get; set; }

		// Email address of the user
		public string EmailAddress { get; set; }

		// Phone number of the user
		public string PhoneNumber { get; set; }

		// One user can have many posts (navigation property)
		public List<Post> Posts { get; set; }
	}
}