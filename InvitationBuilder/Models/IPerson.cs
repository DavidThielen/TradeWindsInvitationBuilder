namespace InvitationBuilder.Models
{
	public interface IPerson
	{
		/// <summary>
		/// The name of the user.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// The email address for this user.
		/// </summary>
		public string? Email { get; }

		/// <summary>
		/// The user's phone number.
		/// </summary>
		public IPhoneNumber? Phone { get; }
	}
}
