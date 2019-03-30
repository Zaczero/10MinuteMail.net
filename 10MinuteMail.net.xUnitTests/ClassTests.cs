using _10MinuteMail.net.Types;
using System;
using Xunit;

namespace _10MinuteMail.net.xUnitTests
{
    public class ClassTests
    {
        [Fact]
        public void CanCreateMailResponse()
        {
            var response = new MailResponse();
        }
        [Fact]
        public void CanCreateMailEntry()
        {
            var response = new MailEntry();
        }
        [Fact]
        public void CanCreateMailContent()
        {
            var response = new MailContent();
        }
    }
}
