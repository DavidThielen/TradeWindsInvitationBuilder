# TradeWindsInvitationBuilder

This is very much a work in progress. None of these are officially documented anywhere. And for .ics everyone has their own extensions, again not documented anywhere.

The approach is you give the `InviteBuilder` object your appointment properties. And then call it to get the invitation files & links for that specific appointment and recipient. What I have here works and it gives you a complete invitation. As I get more information about these specifications this will imporve.

You can accomplish all this using the below libraries instead of this library. The advantage of this library is with a few calls you get all the invitation files/links.

> This is under the MIT license. If you find this useful I ask (not a requirement) that you consider reading my book [I DON’T KNOW WHAT I'M DOING!: How a Programmer Became a Successful Startup CEO](https://a.co/d/bEpDlJR).
> 
> And if you like it, please review it on Amazon and/or GoodReads. The number of legitimate reviews helps a lot. Much appreciated.

## Reoccurring Appointments

I have not been able to find the specification for this - for any of the formats. If/when I get this, I will add it. Until then, sorry.

## If You are Aware of Additional Information for any of the Specifications

If you are aware of any additional information, please enter an Issue with the information and anything additional you have to add. I'm very happy if you implement it yourself, but I'll do it if you don't have time.

## Sources

* [iCalendar.org - all things .ics](https://icalendar.org/#google_vignette)
* [wikipedia - .ics file format](https://en.wikipedia.org/wiki/ICalendar)
* [Google documentation](https://github.com/InteractionDesignFoundation/add-event-to-calendar-docs/blob/main/services/google.md)
* [ical.net - wrapper to build an .ICS file](https://github.com/ical-org/ical.net)
* [MsgKit - wrapper to build a .MSG file](https://github.com/Sicos1977/MsgKit)


