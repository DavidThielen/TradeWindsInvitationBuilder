using InvitationBuilder;

namespace UnitTests;

public class TestMsg : TestBase
{
	[Fact]
	public void TestBasics()
	{

		var inviteBuilder = CreateAppointment();

		var visitor = CreateJohnSmith();

		Assert.Equal("application/vnd.ms-outlook", inviteBuilder.GetMimeType(InviteBuilder.ProviderType.Outlook));
		Assert.Equal(".msg", inviteBuilder.GetExtension(InviteBuilder.ProviderType.Outlook));

		Assert.Throws<NotImplementedException> (() => inviteBuilder.GetLink(InviteBuilder.ProviderType.Outlook, visitor));
	}

	[Fact]
	public void TestIcsFile()
	{
		var inviteBuilder = CreateAppointment();

		var visitor = CreateJohnSmith();

		var msgStream = inviteBuilder.GetFile(InviteBuilder.ProviderType.Outlook, visitor);

		// Don't have a library to read the file other than the one that created it - which isn't much of a test.
		Assert.Equal(0, msgStream.Position);
		Assert.True(msgStream.Length > 1000);
	}
}