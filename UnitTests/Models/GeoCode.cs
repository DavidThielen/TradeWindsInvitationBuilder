using InvitationBuilder.Models;

namespace UnitTests.Models
{
	internal class GeoCode : IGeoCode
	{
		/// <inheritdoc />
		public double Longitude { get; }

		/// <inheritdoc />
		public double Latitude { get; }

		public GeoCode(double longitude, double latitude)
		{
			Longitude = longitude;
			Latitude = latitude;
		}
	}
}
