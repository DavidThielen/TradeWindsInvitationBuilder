namespace InvitationBuilder.Models
{
	public interface IAddress
	{
		/// <summary>
		/// The location name like "Events Center". null if it's not a "known" place.
		/// </summary>
		public string? Name { get; }

		/// <summary>
		/// The street name and number. 
		/// </summary>
		public string? StreetNumberAndName { get; }

		/// <summary>
		/// The apartment or suite text/number.
		/// </summary>
		public string? SuiteApt { get; }

		/// <summary>
		/// City / Town.
		/// </summary>
		public string? City { get; }

		/// <summary>
		/// The County or Canton. 
		/// </summary>
		public string? Canton { get; }

		/// <summary>
		/// State or Province. Some countries (Singapore) do not use this.
		/// </summary>
		public string? State { get; }

		/// <summary>
		///  Required.
		/// </summary>
		public string? Country { get; }

		/// <summary>
		/// The full country name (RegionInfo.EnglishName).
		/// </summary>
		public string? PostalCode { get; }

		/// <summary>
		/// use X for longitude and Y for latitude.
		/// </summary>
		public IGeoCode? Location { get; }

		/// <summary>
		/// If this is not set, this library will format the full address from the above properties.
		/// If this is not null, then it will use this property as the full address in the invite.
		/// </summary>
		public string? FullAddress { get; }
	}
}
