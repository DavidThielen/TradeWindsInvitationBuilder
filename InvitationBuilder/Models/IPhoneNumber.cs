namespace InvitationBuilder.Models
{
	public interface IPhoneNumber
	{
		/// <summary>
		/// The phone number in the E.164 standard format.
		/// </summary>
		public string E164Number { get; }

		/// <summary>
		/// The phone number in the format "+1 (303) 123-4567"
		/// </summary>
		public string FormattedNumber { get; }
	}
}
