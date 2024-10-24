// copyright (C) 2024 by David Thielen. ALL RIGHTS RESERVED
// This code is confidential and is only to be viewed and/or used by authorized individuals & entities.

using System.Text;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using InvitationBuilder.Models;
using TimeZoneConverter;

namespace InvitationBuilder.Providers
{
	internal class IcsInviteProvider : InviteProviderBase, IInviteProvider
	{
		public IInviteProvider.InviteType Type { get; } = IInviteProvider.InviteType.File;

		/// <inheritdoc />
		public string MimeType => "text/calendar";

		/// <inheritdoc />
		public string Extension => ".ics";

		/// <inheritdoc />
		public Stream BuildFile(IAppointment appointment, IPerson owner, IPerson recipient)
		{

			var timezone = TZConvert.WindowsToIana(appointment.StartDateTime.TimeZoneId);
			var ce = new CalendarEvent
			{
				Start = new CalDateTime(appointment.StartDateTime.DateTime, timezone),
				End = new CalDateTime(appointment.EndDateTime.DateTime, timezone),
				Description = BuildTextDescription(appointment),
				Summary = appointment.Subject,
				Uid = appointment.CalendarUid
			};
			var fullAddress = BuildFullAddress(appointment);
			if (!string.IsNullOrEmpty(fullAddress))
				ce.Location = fullAddress.Replace("\n", ", ");
			if (appointment.Address?.Location != null)
				ce.GeographicLocation = new GeographicLocation(appointment.Address.Location.Latitude, appointment.Address.Location.Longitude);

			// zoom if have it, otherwise EventProfile
			var link = appointment.MeetingLink ?? appointment.MeetingWebpage;
			if (! string.IsNullOrEmpty(link?.Url))
				ce.Url = new Uri(link.Url);
			var calendar = new Ical.Net.Calendar();
			calendar.Events.Add(ce);

			// no using on any of this because we're returning a result that may be using the streams.
			var serializer = new CalendarSerializer();
			var icsContent = serializer.SerializeToString(calendar);
			return new MemoryStream(Encoding.UTF8.GetBytes(icsContent));
		}

		/// <inheritdoc />
		public string BuildLink(IAppointment appointment, IPerson owner, IPerson recipient)
		{
			throw new NotImplementedException(".ICS is always a file, never a url.");
		}
	}
}
