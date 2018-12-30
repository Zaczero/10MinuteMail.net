# 10MinuteMail.net

Simple API wrapper for https://10minutemail.net/

## Download
* https://github.com/Zaczero/10MinuteMail.net/releases/latest

## Sample code

```cs
var tenMinuteMail = new TenMinuteMail();

var email = tenMinuteMail.GetEmailAddress().Result; // email address
var emails = tenMinuteMail.GetEmails().Result; // emails

tenMinuteMail.GenerateNewEmailAddress().Wait(); // whoops! got new email

var email2 = tenMinuteMail.GetEmailAddress().Result; // new email

tenMinuteMail.Reset100Minutes().Wait(); // 100 minutes? no problem!

var seconds = tenMinuteMail.GetSecondsLeft().Result; // 6000 seconds
```

## Structures

```cs
[Serializable]
public struct MailResponse // https://10minutemail.net/address.api.php
{
    public string mail_get_user;
    public string mail_get_mail;
    public string mail_get_host;
    public int mail_get_time;
    public int mail_get_duetime;
    public int mail_server_time;
    public string mail_get_key;
    public int mail_left_time;
    public string mail_recovering_key;
    public string mail_recovering_mail;
    public string session_id;
    public MailEntry[] mail_list;
}

[Serializable]
public struct MailEntry
{
    public string mail_id;
    public string from;
    public string subject;
    public string datetime;
    public string datetime2;
    public int timeago;
    public bool isread;
}

[Serializable]
public struct MailContent // https://10minutemail.net/mail.api.php?mailid=MAIL_ID
{
    public string from;
    public string gravatar;
    public string to;
    public string subject;
    public string datetime;
    public int timestamp;
    public string datetime2;
    public string[] urls;
    public string[] html;
}
```