using InvitationBuilder;
using System;
using System.Web;

namespace UnitTests;

public class TestGoogle : TestBase
{
	[Fact]
	public void TestBasics()
	{

		var inviteBuilder = CreateAppointment();

		var visitor = CreateJohnSmith();

		Assert.Throws<NotImplementedException> (() => inviteBuilder.GetMimeType(InviteBuilder.ProviderType.Google));
		Assert.Throws<NotImplementedException> (() => inviteBuilder.GetExtension(InviteBuilder.ProviderType.Google));
		Assert.Throws<NotImplementedException> (() => inviteBuilder.GetFile(InviteBuilder.ProviderType.Google, visitor));
	}

	[Fact]
	public void TestIcsFile()
	{
		var inviteBuilder = CreateAppointment();

		var visitor = CreateJohnSmith();

		var googleUrl = inviteBuilder.GetLink(InviteBuilder.ProviderType.Google, visitor);

		var uri = new Uri(googleUrl);
		var mapAppt = HttpUtility.ParseQueryString(uri.Query);

		Assert.Equal(6, mapAppt.Count);
		Assert.Equal("TEMPLATE", mapAppt.Get("action"));
		Assert.Equal("Tour", mapAppt.Get("text"));
		Assert.Equal("20240926T113000/20240926T133000", mapAppt.Get("dates"));
		Assert.Equal("America/Denver", mapAppt.Get("ctz"));
		Assert.Equal("White House Tour\r\nLots of info about the White House tour...\r\nZoom Meeting ID: 12345: https://www.zoom.com?id=12345", mapAppt.Get("details"));
		Assert.Equal("The White House, 1600 Pennsylvania Ave., Washington, D.C. 20002, United States", mapAppt.Get("location"));
	}
}