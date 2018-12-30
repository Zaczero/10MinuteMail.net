using System.Diagnostics;

namespace _10MinuteMail.net.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var tenMinuteMail = new TenMinuteMail();

            var email = tenMinuteMail.GetEmailAddress().Result;
            var emails = tenMinuteMail.GetEmails().Result;

            tenMinuteMail.GenerateNewEmailAddress().Wait();

            var email2 = tenMinuteMail.GetEmailAddress().Result;

            tenMinuteMail.Reset100Minutes().Wait();

            var seconds = tenMinuteMail.GetSecondsLeft().Result;

            Debugger.Break();
        }
    }
}
