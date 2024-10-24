using TradeWindsDateTime;

namespace InvitationBuilder.Models
{
	public interface IAppointment
	{
		/// <summary>
		/// The appointment’s subject.
		/// </summary>
		public string Subject { get; }

		/// <summary>
		/// The appointment's elevator pitch. This is a short description of the event.
		/// </summary>
		public string? ElevatorPitch { get; }

		/// <summary>
		/// The appointment's full description, in ASCII text. The invite will use this description <b>or</b>
		/// the DescriptionHtml, depending on the invite type. It will never use both (unless there's a future
		/// format which accepts an HTML and TEXT description).
		/// </summary>
		public string? DescriptionText { get; }

		/// <summary>
		/// The appointment's full description, in HTML. This can be the &lt;body&gt; content, it can include
		/// the &lt;body&gt; tags, or it can include the &lt;html&gt; tags wrapping it. The various calendar
		/// programs appear to handle all the various combinations of this.
		/// </summary>
		public string? DescriptionHtml { get; }

		/// <summary>
		/// The URL for the appointment if it is a meeting, etc. with a webpage describing the meeting.
		/// </summary>
		public IMeetingUrl? MeetingWebpage { get; }

		/// <summary>
		/// The meeting URL (for remote &amp; hybrid), so Zoom, etc. null for in-person meetings.
		/// </summary>
		public IMeetingUrl? MeetingLink { get; }
		
		/// <summary>
		/// The meeting location (for in-person &amp; hybrid). null for remote meetings.
		/// </summary>
		public IAddress? Address { get; }

		/// <summary>
		/// Specifies the appointment’s start DateTime. For a reoccurring appointment this is the start of the
		/// first instance.<br/>
		/// Note that some calendar programs can handle, for a reoccurring appointment, that this can be set
		/// to say a Tuesday and the re-occurrence is every Thursday and it works. But this is not a good idea
		/// as some calendar programs choke on this.<br/>
		/// Note that this API supports distinct time zones for the start and end datetime, but some of the
		/// invite formats do not support that.
		/// </summary>
		public DateTimeZone StartDateTime { get; }

		/// <summary>
		/// Specifies the appointment’s end DateTime. For a reoccurring appointment this is the end of the
		/// first instance.<br/>
		/// Note that some calendar programs can handle, for a reoccurring appointment, that this can be set
		/// to say a Tuesday and the re-occurrence is every Thursday and it works. But this is not a good idea
		/// as some calendar programs choke on this.<br/>
		/// Note that this API supports distinct time zones for the start and end datetime, but some of the
		/// invite formats do not support that. In that case the StartDateTime.TimeZone is used for the end.
		/// </summary>
		public DateTimeZone EndDateTime { get; }

		/// <summary>
		/// True if this is an all-day appointment.
		/// </summary>
		public bool AllDay { get; }

		/// <summary>
		/// The RRULE for a reoccurring appointment. Required for reoccurring appointments and ignored for one-time
		/// appointment. <b>At present this is not supported!</b>
		/// </summary>
		public string? ReoccurrenceRule { get; }

		/// <summary>
		/// A unique identifier for this appointment. Reuse this when updating an invite so that the recipient
		/// will then have their calendar appointment updated instead of an additional appointment added.
		/// </summary>
		public string CalendarUid { get; }
	}
}
