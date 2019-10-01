using System.Net.Mail;
using Xunit;

namespace _10MinuteMail.net.xUnitTests
{
    public class TenMinuteMailTests
    {
        private TenMinuteMail tenMinuteMail = new TenMinuteMail();
        private string _address;

        public string Address
        {
            get {
                if (_address == null)
                {
                    var t = tenMinuteMail.GetEmailAddress();
                    t.Wait();
                    Address = t.Result;
                }
                return _address;
            }
            set { _address = value; }
        }


        [Fact]
        public async System.Threading.Tasks.Task CanGetResponseAsync()
        {
            await tenMinuteMail.GetResponse();
        }


        //Auto generated test

        [Fact]
        public async System.Threading.Tasks.Task CanGetResponse()
        {
            await tenMinuteMail.GetResponse();
}

        [Fact]
        public async System.Threading.Tasks.Task CanGetEmailAddress()
        {
            await tenMinuteMail.GetEmailAddress();
}

        [Fact]
        public async System.Threading.Tasks.Task CanGetHost()
        {
            await tenMinuteMail.GetHost();
}

        [Fact]
        public async System.Threading.Tasks.Task CanGetSecondsLeft()
        {
            await tenMinuteMail.GetSecondsLeft();
}

        [Fact]
        public async System.Threading.Tasks.Task CanGetEmailCount()
        {
            await tenMinuteMail.GetEmailCount();
        }

        [Fact]
        public async System.Threading.Tasks.Task CanGetEmails()
        {
            await tenMinuteMail.GetEmails();
        }

        [Fact]
        public async System.Threading.Tasks.Task CanGetLastEmail()
        {
            await tenMinuteMail.GetLastEmail();
        }

        [Fact]
        public async System.Threading.Tasks.Task CanReset10Minutes()
        {
            await tenMinuteMail.Reset10Minutes();
        }

        [Fact]
        public async System.Threading.Tasks.Task CanReset100Minutes()
        {
            await tenMinuteMail.Reset100Minutes();
        }

        [Fact]
        public async System.Threading.Tasks.Task CanGenerateNewEmailAddress()
        {
            await tenMinuteMail.GenerateNewEmailAddress();
        }

        [Fact]
        public async System.Threading.Tasks.Task CanRecoverEmailAddress()
        {
	        await tenMinuteMail.RecoverEmailAddress();
        }
    }
}
