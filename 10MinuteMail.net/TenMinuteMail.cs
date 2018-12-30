using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _10MinuteMail.net
{
    [Serializable]
    public struct MailResponse
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
    public struct MailContent
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
                mails[i] = await GetMailContent(response.mail_list[i].mail_id);
            }

            return mails;
        }
        
        public async Task<MailContent> GetLastEmail()
        {
            var response = await GetResponse();
            return await GetMailContent(response.mail_list[0].mail_id);
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
