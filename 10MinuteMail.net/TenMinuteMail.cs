using _10MinuteMail.net.Types;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _10MinuteMail.net
{
    public class TenMinuteMail
    {
        private readonly HttpClient httpClient;

        public TenMinuteMail()
        {
            httpClient = new HttpClient();
        }

        private void SetCookies(HttpResponseMessage responseMessage)
        {
            if (responseMessage.Headers.TryGetValues("set-cookie", out var cookies))
            {
                foreach (var cookie in cookies)
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
                }
            }
        }

        /// <summary>
        /// Gets a list of recived emails and information about the session
        /// </summary>
        public async Task<MailResponse> GetResponse()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/address.api.php");
            var response = await httpClient.SendAsync(request);

            SetCookies(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MailResponse>(json);
        }

        public async Task<MailContent> GetMailContent(string mailId)
        {
            var mailIdSafe = Uri.EscapeUriString(mailId);

            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/mail.api.php?mailid=" + mailIdSafe);
            var response = await httpClient.SendAsync(request);

            SetCookies(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MailContent>(json);
        }

        public async Task<string> GetEmailAddress()
        {
            return (await GetResponse()).mail_get_mail;
        }

        public async Task<int> GetSecondsLeft()
        {
            return (await GetResponse()).mail_left_time;
        }
        
        public async Task<int> GetEmailCount()
        {
            return (await GetResponse()).mail_list.Length;
        }

        public async Task<MailContent[]> GetEmails()
        {
            var response = await GetResponse();

            var mails = new MailContent[response.mail_list.Length];

            for (var i = 0; i < response.mail_list.Length; i++)
            {
                mails[i] = await GetMailContent(response.mail_list[i].MailId);
            }

            return mails;
        }
        
        public async Task<MailContent> GetLastEmail()
        {
            var response = await GetResponse();
            return await GetMailContent(response.mail_list[0].MailId);
        }

        public async Task Reset10Minutes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/more.html");
            var response = await httpClient.SendAsync(request);

            SetCookies(response);
        }

        public async Task Reset100Minutes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/more100.html");
            var response = await httpClient.SendAsync(request);

            SetCookies(response);
        }

        public async Task GenerateNewEmailAddress()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/new.html");
            var response = await httpClient.SendAsync(request);

            SetCookies(response);
        }

        public async Task RecoverExpiredEmailAddress()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://10minutemail.net/recover.html");
            var response = await httpClient.SendAsync(request);

            SetCookies(response);
        }
    }
}
