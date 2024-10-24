using InvitationBuilder.Models;
using TradeWindsDateTime;

namespace UnitTests.Models
{
	internal class Appointment : IAppointment
	{
		/// <inheritdoc />
		public string Subject { get; }

		/// <inheritdoc />
		public string? ElevatorPitch { get; }

		/// <inheritdoc />
		public string? DescriptionText { get; }

		/// <inheritdoc />
		public string? DescriptionHtml { get; }

		/// <inheritdoc />
		public IMeetingUrl? MeetingWebpage { get; }

		/// <inheritdoc />
		public IMeetingUrl? MeetingLink { get; }

		/// <inheritdoc />
		public IAddress? Address { get; }

		/// <inheritdoc />
		public DateTimeZone StartDateTime { get; }

		/// <inheritdoc />
		public DateTimeZone EndDateTime { get; }

		/// <inheritdoc />
		public bool AllDay { get; }

		/// <inheritdoc />
		public string? ReoccurrenceRule { get; }

		/// <inheritdoc />
		public string CalendarUid { get; }

		public Appointment(string subject, string? elevatorPitch, string? descriptionText, string? descriptionHtml, IMeetingUrl? meetingWebpage, IMeetingUrl? meetingLink, IAddress? address, DateTimeZone startDateTime, DateTimeZone endDateTime, bool allDay, string? reoccurrenceRule, string calendarUid)
		{
			Subject = subject;
			ElevatorPitch = elevatorPitch;
			DescriptionText = descriptionText;
			DescriptionHtml = descriptionHtml;
			MeetingWebpage = meetingWebpage;
			MeetingLink = meetingLink;
			Address = address;
			StartDateTime = startDateTime;
			EndDateTime = endDateTime;
			AllDay = allDay;
			ReoccurrenceRule = reoccurrenceRule;
			CalendarUid = calendarUid;
		}
	}
}
