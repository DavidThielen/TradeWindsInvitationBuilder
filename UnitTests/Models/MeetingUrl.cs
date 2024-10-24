using InvitationBuilder.Models;

namespace UnitTests.Models
{
	internal class MeetingUrl : IMeetingUrl
	{
		/// <inheritdoc />
		public string Text { get; }

		/// <inheritdoc />
		public string Url { get; }

		public MeetingUrl(string text, string url)
		{
			Text = text;
			Url = url;
		}
	}
}
