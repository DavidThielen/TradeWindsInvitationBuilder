using InvitationBuilder.Models;

namespace UnitTests.Models
{
	internal class PhoneNumber : IPhoneNumber
	{
		/// <inheritdoc />
		public string E164Number { get; }

		/// <inheritdoc />
		public string FormattedNumber { get; }

		public PhoneNumber(string e164Number, string formattedNumber)
		{
			E164Number = e164Number;
			FormattedNumber = formattedNumber;
		}
	}
}
