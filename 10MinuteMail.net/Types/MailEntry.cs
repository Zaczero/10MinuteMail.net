using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10MinuteMail.net.Types
{
    [Serializable]
    public class MailEntry
    {
        [JsonProperty(PropertyName = "mail_id")]
        public string MailId { get; set; }
        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "datetime")]
        public string DateTime { get; set; }
        [JsonProperty(PropertyName = "datetime2")]
        public string DateTime2 { get; set; }
        [JsonProperty(PropertyName = "timeago")]
        public int TimeAgo { get; set; }
        [JsonProperty(PropertyName = "isread")]
        public string IsRead { get; set; }
    }
}
