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
        public string mail_get_user { get; set; }
        [JsonProperty(PropertyName = "mail_get_mail")]
        public string mail_get_mail { get; set; }
        [JsonProperty(PropertyName = "mail_get_host")]
        public string mail_get_host { get; set; }
        [JsonProperty(PropertyName = "mail_get_time")]
        public int mail_get_time;
        [JsonProperty(PropertyName = "mail_get_duetime")]
        public int mail_get_duetime { get; set; }
        [JsonProperty(PropertyName = "mail_server_time")]
        public int mail_server_time { get; set; }
        [JsonProperty(PropertyName = "mail_get_key")]
        public string mail_get_key { get; set; }
        [JsonProperty(PropertyName = "mail_left_time")]
        public int mail_left_time { get; set; }
        [JsonProperty(PropertyName = "mail_recovering_key")]
        public string mail_recovering_key { get; set; }
        [JsonProperty(PropertyName = "mail_recovering_mail")]
        public string mail_recovering_mail { get; set; }
        [JsonProperty(PropertyName = "session_id")]
        public string session_id { get; set; }
        [JsonProperty(PropertyName = "mail_list")]
        public MailEntry[] mail_list { get; set; }
    }
}
