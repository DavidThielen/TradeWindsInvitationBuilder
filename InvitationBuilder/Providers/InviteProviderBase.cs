using InvitationBuilder.Models;
using System.Text;
using System.Text.Encodings.Web;

namespace InvitationBuilder.Providers
{
	internal class InviteProviderBase
	{
		public static string BuildTextDescription(IAppointment appointment)
		{
			var sb = new StringBuilder();

			if (!string.IsNullOrEmpty(appointment.ElevatorPitch))
				sb.AppendLine(appointment.ElevatorPitch.Trim());

			if (!string.IsNullOrEmpty(appointment.DescriptionText))
				sb.AppendLine(appointment.DescriptionText.Trim());

			if (appointment.MeetingLink is not null)
				sb.AppendLine($"{appointment.MeetingLink.Text}: {appointment.MeetingLink.Url}");

			return sb.ToString().Trim();
		}

		public static string BuildHtmlDescription(IAppointment appointment)
		{
			var sb = new StringBuilder();
			if (!string.IsNullOrEmpty(appointment.ElevatorPitch))
				sb.AppendLine("<p>" + appointment.ElevatorPitch.Trim() + "</p>");
			if (!string.IsNullOrEmpty(appointment.DescriptionHtml))
				sb.AppendLine(appointment.DescriptionHtml);

			if (appointment.MeetingLink is not null)
				sb.AppendLine($"<p><a href=\"{appointment.MeetingLink.Url}\">{appointment.MeetingLink.Text}</a></p>");

			return sb.ToString().Trim();
		}

		public static string? BuildFullAddress(IAppointment appointment)
		{
			ArgumentNullException.ThrowIfNull(appointment.Address, nameof(appointment.Address));

			if (appointment.Address is null)
				return null;

			if (! string.IsNullOrEmpty(appointment.Address.FullAddress))
				return appointment.Address.FullAddress;

			StringBuilder sb = new StringBuilder();
			if (!string.IsNullOrEmpty(appointment.Address.Name))
				sb.Append(appointment.Address.Name).Append('\n');
			if (!string.IsNullOrEmpty(appointment.Address.StreetNumberAndName))
			{
				sb.Append(appointment.Address.StreetNumberAndName);
				if (!string.IsNullOrEmpty(appointment.Address.SuiteApt))
					sb.Append(" ").Append(appointment.Address.SuiteApt);
				sb.Append('\n');
			}
			else if (!string.IsNullOrEmpty(appointment.Address.SuiteApt))
				sb.Append(appointment.Address.SuiteApt).Append('\n');
			if (!string.IsNullOrEmpty(appointment.Address.City))
				sb.Append(appointment.Address.City);
			if (!string.IsNullOrEmpty(appointment.Address.State))
				sb.Append(", ").Append(appointment.Address.State);
			if (!string.IsNullOrEmpty(appointment.Address.PostalCode))
				sb.Append(" ").Append(appointment.Address.PostalCode).Append('\n');
			if (!string.IsNullOrEmpty(appointment.Address.Country))
				sb.Append(appointment.Address.Country);

			while (sb.ToString().StartsWith(", "))
				sb.Remove(0, 2);
			while (sb.ToString().EndsWith("\n"))
				sb.Remove(sb.Length - 1, 1);
			if (sb.Length == 0)
				return null;
			return sb.ToString().Trim();
		}

		public static string? BuildFullAddressHtml(IAppointment appointment)
		{
			ArgumentNullException.ThrowIfNull(appointment.Address, nameof(appointment.Address));

			if (appointment.Address is null)
				return null;

			var asciiFullAddress = BuildFullAddress(appointment);
			if (asciiFullAddress == null) 
				return null;

			// convert any \n to <br/> - encode the rest.
			asciiFullAddress = asciiFullAddress.Replace("\n", "fh#$*23k");
			asciiFullAddress = HtmlEncoder.Default.Encode(asciiFullAddress);
			return asciiFullAddress.Replace("fh#$*23k", "<br/>");
		}
	}
	}
