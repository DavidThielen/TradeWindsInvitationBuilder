namespace InvitationBuilder.Models
{
	public interface IMeetingUrl
	{
		/// <summary>
		/// The text to display for the link.
		/// </summary>
		public string Text { get; }

		/// <summary>
		/// The URL for the website.
		/// </summary>
		public string Url { get; }
	}
}
