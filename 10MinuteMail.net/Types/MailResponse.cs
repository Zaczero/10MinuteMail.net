using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10MinuteMail.net.Types
{
    [Serializable]
    public class MailResponse
    {
        [JsonProperty(PropertyName = "mail_get_user")]
        public string User { get; set; }
        [JsonProperty(PropertyName = "mail_get_mail")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "mail_get_host")]
        public string Host { get; set; }
        [JsonProperty(PropertyName = "mail_get_time")]
        public int GetTime;
        [JsonProperty(PropertyName = "mail_get_duetime")]
        public int DueTime { get; set; }
        [JsonProperty(PropertyName = "mail_server_time")]
        public int ServerTime { get; set; }
        [JsonProperty(PropertyName = "mail_get_key")]
        public string MailKey { get; set; }
        [JsonProperty(PropertyName = "mail_left_time")]
        public int TimeLeft { get; set; }
        [JsonProperty(PropertyName = "mail_recovering_key")]
        public string RecoveringKey { get; set; }
        [JsonProperty(PropertyName = "mail_recovering_mail")]
        public string RecoverableMailAddress { get; set; }
        [JsonProperty(PropertyName = "session_id")]
        public string SessionId { get; set; }
        [JsonProperty(PropertyName = "mail_list")]
        public MailEntry[] MailList { get; set; }
    }
}
