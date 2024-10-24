namespace InvitationBuilder.Models
{
	/// <summary>
	/// A point on the globe.
	/// </summary>
	public interface IGeoCode
	{
		/// <summary>
		/// The longitude of a point on the globe.
		/// </summary>
		double Longitude { get; }

		/// <summary>
		/// The latitude of a point on the globe.
		/// </summary>
		double Latitude { get; }
	}
}
