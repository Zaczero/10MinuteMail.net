# 10MinuteMail.net

![](https://img.shields.io/github/release/Zaczero/10MinuteMail.net.svg)
![](https://img.shields.io/nuget/v/10MinuteMail.net-API.svg)
![](https://img.shields.io/github/license/Zaczero/10MinuteMail.net.svg)

Simple API wrapper for https://10minutemail.net/

## Download
* https://github.com/Zaczero/10MinuteMail.net/releases/latest

## Sample code

```cs
var tenMinuteMail = new TenMinuteMail();

var email = tenMinuteMail.GetEmailAddress().Result; // current email address
var emails = tenMinuteMail.GetEmails().Result; // emails

tenMinuteMail.GenerateNewEmailAddress().Wait(); // whoops! got new email

var email2 = tenMinuteMail.GetEmailAddress().Result; // new email address

tenMinuteMail.Reset100Minutes().Wait(); // 100 minutes? no problem!

var seconds = tenMinuteMail.GetSecondsLeft().Result; // 6000 seconds
```