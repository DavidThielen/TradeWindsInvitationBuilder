// copyright (C) 2024 by David Thielen. ALL RIGHTS RESERVED
// This code is confidential and is only to be viewed and/or used by authorized individuals & entities.

using System.Web;
using InvitationBuilder.Models;
using TimeZoneConverter;

namespace InvitationBuilder.Providers
{
	internal class GoogleInviteProvider : InviteProviderBase, IInviteProvider
	{
		public IInviteProvider.InviteType Type { get; } = IInviteProvider.InviteType.Link;

		/// <inheritdoc />
		public string MimeType => throw new NotImplementedException("Google invites are always a url, never a file.");

		/// <inheritdoc />
		public string Extension => throw new NotImplementedException("Google invites are always a url, never a file.");


		/// <inheritdoc />
		public Stream BuildFile(IAppointment appointment, IPerson owner, IPerson recipient)
		{
			throw new NotImplementedException("Google invites are always a url, never a file.");
		}

		/// <inheritdoc />
		public string BuildLink(IAppointment appointment, IPerson owner, IPerson recipient)
		{

			var builder = new UriBuilder("https://www.google.com/calendar/event");
			var query = HttpUtility.ParseQueryString(builder.Query);

			// Apparently Google does not support a GUID for an event.
			query["action"] = "TEMPLATE";
			query["text"] = appointment.Subject;

			query["dates"] = ToGoogleDateTime(appointment.StartDateTime.DateTime) + "/" + 
			                 ToGoogleDateTime(appointment.EndDateTime.GetDateTime(appointment.StartDateTime.TimeZoneId));
			var timezone = TZConvert.WindowsToIana(appointment.StartDateTime.TimeZoneId);
			query["ctz"] = timezone;

			query["details"] = BuildTextDescription(appointment);

			var fullAddress = BuildFullAddress(appointment);
			if (!string.IsNullOrEmpty(fullAddress))
				query["location"] = fullAddress.Replace("\n", ", ");

			builder.Query = query.ToString();
			return builder.ToString();
		}

		private static string ToGoogleDateTime(DateTime dt)
		{
			return dt.ToString("yyyyMMddTHHmmss");
		}
	}
}
