using _10MinuteMail.net.Types;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _10MinuteMail.net
{
    public class TenMinuteMail
    {
        private readonly HttpClient _httpClient;

        public TenMinuteMail()
        {
            _httpClient = new HttpClient();
        }

        private void SetCookies(HttpResponseMessage responseMessage)
        {
            if (responseMessage.Headers.TryGetValues("set-cookie", out var cookies))
            {
                foreach (var cookie in cookies)
                {
                    _httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
                }
            }
        }

        /// <summary>
        /// Gets a list of revived emails and information about the session
        /// </summary>
        public async Task<MailResponse> GetResponse()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/address.api.php");
            var response = await _httpClient.SendAsync(request);

            SetCookies(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MailResponse>(json);
        }

        public async Task<MailContent> GetMailContent(string mailId)
        {
            var mailIdSafe = Uri.EscapeUriString(mailId);

            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/mail.api.php?mailid=" + mailIdSafe);
            var response = await _httpClient.SendAsync(request);

            SetCookies(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MailContent>(json);
        }

        public async Task<string> GetEmailAddress()
        {
            return (await GetResponse()).Address;
        }

        public async Task<string> GetHost()
        {
            return (await GetResponse()).Host;
        }

        public async Task<int> GetSecondsLeft()
        {
            return (await GetResponse()).TimeLeft;
        }
        
        public async Task<int> GetEmailCount()
        {
            return (await GetResponse()).MailList.Length;
        }

        public async Task<MailContent[]> GetEmails()
        {
            //Get the list of emails that we have...
            var response = await GetResponse();
            //Create array to store result in
            var mails = new MailContent[response.MailList.Length];
            //For each email get it from the server
            for (var i = 0; i < response.MailList.Length; i++)
            {
                mails[i] = await GetMailContent(response.MailList[i].MailId);
            }

            return mails;
        }
        
        public async Task<MailContent> GetLastEmail()
        {
            var response = await GetResponse();
            return await GetMailContent(response.MailList[0].MailId);
        }

        public async Task Reset10Minutes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/more.html");
            var response = await _httpClient.SendAsync(request);

            SetCookies(response);
        }

        public async Task Reset100Minutes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/more100.html");
            var response = await _httpClient.SendAsync(request);

            SetCookies(response);
        }

        public async Task GenerateNewEmailAddress()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/new.html");
            var response = await _httpClient.SendAsync(request);

            SetCookies(response);
        }

        public async Task RecoverEmailAddress()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/recover.html");
            var response = await _httpClient.SendAsync(request);

            SetCookies(response);
        }
    }
}
