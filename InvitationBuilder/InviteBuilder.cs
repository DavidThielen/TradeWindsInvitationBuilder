// copyright (C) 2024 by David Thielen. ALL RIGHTS RESERVED
// This code is confidential and is only to be viewed and/or used by authorized individuals & entities.

using InvitationBuilder.Models;
using InvitationBuilder.Providers;

namespace InvitationBuilder
{
    /// <summary>
    /// This builds a calendar file or link for a user to download an invite. All conversion of
    /// an Event to the invite components is performed here.
    /// </summary>
    public class InviteBuilder
    {
	    /// <summary>
	    /// Which provider this is for. Used to determine which Build method to call.
	    /// </summary>
	    public enum ProviderType
	    {
		    /// <summary>
		    /// Google link.
		    /// </summary>
		    Google,
		    /// <summary>
		    /// .msg file.
		    /// </summary>
		    Outlook,
		    /// <summary>
		    /// .ics file.
		    /// </summary>
		    Ics
	    }

		private IInviteProvider GoogleBuilder { get; }
        private IInviteProvider IcsBuilder { get; }
        private IInviteProvider MsgBuilder { get; }

        /// <summary>
        /// The appointment used in this builder.
        /// </summary>
        private readonly IAppointment _appointment;

        /// <summary>
        /// The individual that owns the appointment. The invite is from this person.
        /// </summary>
        private readonly IPerson _owner;

        public InviteBuilder(IAppointment appointment, IPerson owner)
        {
            ArgumentNullException.ThrowIfNull(appointment, nameof(IAppointment));
            ArgumentNullException.ThrowIfNull(owner, nameof(owner));

	        _appointment = appointment;
	        _owner = owner;

	        GoogleBuilder = new GoogleInviteProvider();
            IcsBuilder = new IcsInviteProvider();
            MsgBuilder = new MsgInviteProvider();
        }

		/// <summary>
		/// For file types, the MIME type of the file.
		/// </summary>
		/// <param name="type">The invite type.</param>
		/// <returns>The MIME type of the invite file.</returns>
		/// <exception cref="NotImplementedException">Thrown if this type is a url (not a file).</exception>
        public string GetMimeType(ProviderType type)
        {
            switch (type)
            {
                case ProviderType.Google:
                    return GoogleBuilder.MimeType;
                case ProviderType.Ics:
                    return IcsBuilder.MimeType;
                case ProviderType.Outlook:
                    return MsgBuilder.MimeType;
                default:
                    throw new NotImplementedException($"Type {type} is not implemented");
            }
        }

		/// <summary>
		/// For file types, the file extension (example: .ics).
		/// </summary>
		/// <param name="type">The invite type.</param>
		/// <returns>The file extension (example: .ics).</returns>
		/// <exception cref="NotImplementedException">Thrown if this type is a url (not a file).</exception>
		public string GetExtension(ProviderType type)
        {
            switch (type)
            {
                case ProviderType.Google:
                    return GoogleBuilder.Extension;
                case ProviderType.Ics:
                    return IcsBuilder.Extension;
                case ProviderType.Outlook:
                    return MsgBuilder.Extension;
                default:
                    throw new NotImplementedException($"Type {type} is not implemented");
            }
        }

		/// <summary>
		/// Create a url that is the invite.
		/// </summary>
		/// <param name="type">The invite type.</param>
		/// <param name="recipient">Who the invite is being sent to.</param>
		/// <returns>The invite as a url.</returns>
		/// <exception cref="NotImplementedException">Thrown if this type is a file (not a url).</exception>
		public string GetLink(ProviderType type, IPerson recipient)
        {
	        ArgumentNullException.ThrowIfNull(recipient, nameof(recipient));

            switch (type)
            {
                case ProviderType.Google:
                    return GoogleBuilder.BuildLink(_appointment, _owner, recipient);
                default:
                    throw new NotImplementedException($"Type {type} is a file, not a link");
            }
        }

		/// <summary>
		/// Create an invite file.
		/// </summary>
		/// <param name="type">The invite type.</param>
		/// <param name="recipient">Who the invite is being sent to.</param>
		/// <returns>The invite file in a stream.</returns>
		/// <exception cref="NotImplementedException">Thrown if this type is a url (not a file).</exception>
        public Stream GetFile(ProviderType type, IPerson recipient)
		{
			ArgumentNullException.ThrowIfNull(recipient, nameof(recipient));

            switch (type)
            {
                case ProviderType.Ics:
                    return IcsBuilder.BuildFile(_appointment, _owner, recipient);
                case ProviderType.Outlook:
                    return MsgBuilder.BuildFile(_appointment, _owner, recipient);
                default:
                    throw new NotImplementedException($"Type {type} is a link, not a file");
            }
        }
    }
}
