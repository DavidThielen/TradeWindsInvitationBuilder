using InvitationBuilder;

namespace UnitTests
{
	public class TestIcs : TestBase
	{
		[Fact]
		public void TestBasics()
		{

			var inviteBuilder = CreateAppointment();

			var visitor = CreateJohnSmith();

			Assert.Equal("text/calendar", inviteBuilder.GetMimeType(InviteBuilder.ProviderType.Ics));
			Assert.Equal(".ics", inviteBuilder.GetExtension(InviteBuilder.ProviderType.Ics));

			Assert.Throws<NotImplementedException> (() => inviteBuilder.GetLink(InviteBuilder.ProviderType.Ics, visitor));
		}

		[Fact]
		public void TestIcsFile()
		{
			var inviteBuilder = CreateAppointment();

			var visitor = CreateJohnSmith();

			var icsStream = inviteBuilder.GetFile(InviteBuilder.ProviderType.Ics, visitor);
			var streamReader = new StreamReader(icsStream);
			var icsString = streamReader.ReadToEnd();

			Assert.True(icsString.Length > 0);

			var lines = icsString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

			// starting with a space is a line continuation
			var listLines = new List<string>();
			foreach (var line in lines)
				if (line.StartsWith(' '))
					listLines[^1] += line.Trim();
				else
					listLines.Add(line);

			Assert.Equal(16, listLines.Count);
			// probably better to search for each entry - but this works.
			Assert.Equal("DTEND;TZID=America/Denver:20240926T133000", listLines[5]);
			Assert.Equal("DTSTART;TZID=America/Denver:20240926T113000", listLines[7]);
			Assert.Equal("GEO:38.897700;77.036500", listLines[8]);
			Assert.Equal("LOCATION:The White House\\, 1600 Pennsylvania Ave.\\, Washington\\, D.C. 20002\\, United States", listLines[9]);
		}
	}
}
