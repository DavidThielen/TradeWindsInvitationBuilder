using InvitationBuilder.Models;

namespace UnitTests.Models
{
	internal class Person : IPerson
	{
		/// <inheritdoc />
		public string Name { get; }

		/// <inheritdoc />
		public string? Email { get; }

		/// <inheritdoc />
		public IPhoneNumber? Phone { get; }

		public Person(string name, string? email, IPhoneNumber? phone)
		{
			Name = name;
			Email = email;
			Phone = phone;
		}
	}
}
