using InvitationBuilder;
using InvitationBuilder.Models;
using TradeWindsDateTime;
using UnitTests.Models;

namespace UnitTests
{
	public class TestBase
	{

		protected static InviteBuilder CreateAppointment()
		{
			var address = new Address("The White House", "1600 Pennsylvania Ave.", null, "Washington", null,
				"D.C.", "United States", "20002", new GeoCode(77.0365, 38.8977), null);

			var toursUrl = new MeetingUrl("White House Tours", "https://whitehouse.gov");
			var zoomUrl = new MeetingUrl("Zoom Meeting ID: 12345", "https://www.zoom.com?id=12345");

			var owner = new Person("Tour Guide", "tour-office@whitehouse.gov",
				new PhoneNumber("+12025551212", "+1 (202) 555-1212"));
			var appointment = new Appointment("Tour", "White House Tour",
				"Lots of info about the White House tour...",
				"Lots of <b>interesting</b> info about the White House tour...",
				toursUrl, zoomUrl, address,
				new DateTimeZone(new DateTime(2024, 9, 26, 11, 30, 0), "Mountain Standard Time"),
				new DateTimeZone(new DateTime(2024, 9, 26, 13, 30, 0), "Mountain Standard Time"),
				false, null, Guid.NewGuid().ToString());

			return new InviteBuilder(appointment, owner);
		}

		protected static IPerson CreateJohnSmith()
		{
			return new Person("John Smith", "john@smith.us",
				new PhoneNumber("+12025553434", "+1 (202) 555-3434"));
		}
	}
}
