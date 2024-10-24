// copyright (C) 2024 by David Thielen. ALL RIGHTS RESERVED
// This code is confidential and is only to be viewed and/or used by authorized individuals & entities.

using InvitationBuilder.Models;
using MsgKit;
using MsgKit.Enums;

namespace InvitationBuilder.Providers
{
	internal class MsgInviteProvider : InviteProviderBase, IInviteProvider
	{
		/// <inheritdoc />
		public IInviteProvider.InviteType Type => IInviteProvider.InviteType.File;

		/// <inheritdoc />
		public string MimeType => "application/vnd.ms-outlook";

		/// <inheritdoc />
		public string Extension => ".msg";

		/// <inheritdoc />
		public Stream BuildFile(IAppointment appointment, IPerson owner, IPerson recipient)
		{

			using (var appt = new Appointment(
				       new Sender(owner.Email, owner.Name),
				       appointment.Subject))
			{
				appt.Recipients.AddTo(recipient.Email, recipient.Name);
				appt.Subject = appointment.Subject;
				var fullAddress = BuildFullAddress(appointment);
				if (!string.IsNullOrEmpty(fullAddress))
					appt.Location = fullAddress.Replace("\n", ", ");
				appt.MeetingStart = appointment.StartDateTime.UtcDateTime;
				appt.MeetingEnd = appointment.EndDateTime.UtcDateTime;
				appt.AllDay = appointment.AllDay;
				appt.BodyText = BuildTextDescription(appointment);
				appt.BodyHtml = BuildHtmlDescription(appointment);
				appt.SentOn = DateTime.UtcNow;
				appt.Importance = MessageImportance.IMPORTANCE_NORMAL;
				appt.IconIndex = MessageIconIndex.SingleInstanceAppointment;
				appt.InternetMessageId = appointment.CalendarUid;

				// no using on any of this because we're returning result that may be using the streams.
				var buffer = new MemoryStream();
				appt.Save(buffer);
				buffer.Position = 0;
				return buffer;
			}
		}

		/// <inheritdoc />
		public string BuildLink(IAppointment appointment, IPerson owner, IPerson recipient)
		{
			throw new NotImplementedException(".MSG is always a file, never a url.");
		}
	}
}
