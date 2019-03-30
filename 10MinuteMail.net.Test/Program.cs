using System;
using System.Diagnostics;

namespace _10MinuteMail.net.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var tenMinuteMail = new TenMinuteMail();

            var email = tenMinuteMail.GetEmailAddress().Result;
            Console.WriteLine(email);
            Debugger.Break();
            while (true)
            {
                var emails = tenMinuteMail.GetEmails().Result;
                Debugger.Break();
            }
        }
    }
}
