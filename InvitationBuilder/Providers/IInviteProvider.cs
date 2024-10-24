// copyright (C) 2024 by David Thielen. ALL RIGHTS RESERVED
// This code is confidential and is only to be viewed and/or used by authorized individuals & entities.

using InvitationBuilder.Models;

namespace InvitationBuilder.Providers
{
	/// <summary>
	/// Each calendar builder is responsible for creating a specific type of calendar file.
	/// This is used to build a link or file for a user to download an invite.
	/// </summary>
	internal interface IInviteProvider
	{
		/// <summary>
		/// Specify if this provides a file or link.
		/// </summary>
		public enum InviteType
		{
			Link,
			File
		}

		/// <summary>
		/// Every instance is one of these types. This determines which Build method to call.
		/// </summary>
		InviteType Type { get; }

		/// <summary>
		/// For file types, the MIME type of the file.
		/// </summary>
		string MimeType { get; }

		/// <summary>
		/// For file types, the file extension.
		/// </summary>
		string Extension { get; }

		/// <summary>
		/// Build an invite file (.ics, .msg, etc.).
		/// </summary>
		/// <param name="appointment">The appointment.</param>
		/// <param name="owner">The owner (sender) of the appointment.</param>
		/// <param name="recipient">The recipient of this invitation.</param>
		/// <returns>The appointment as a file.</returns>
		Stream BuildFile(IAppointment appointment, IPerson owner, IPerson recipient);

		/// <summary>
		/// Build an invite URL (Google, etc.).
		/// </summary>
		/// <param name="appointment">The appointment.</param>
		/// <param name="owner">The owner (sender) of the appointment.</param>
		/// <param name="recipient">The recipient of this invitation.</param>
		/// <returns>The appointment as a url.</returns>
		string BuildLink(IAppointment appointment, IPerson owner, IPerson recipient);
	}
}
