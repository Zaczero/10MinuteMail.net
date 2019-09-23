using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10MinuteMail.net.Types
{
    [Serializable]
    public class MailContent
    {
        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }
        [JsonProperty(PropertyName = "gravatar")]
        public string Avatar { get; set; }
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "datetime")]
        public string Datetime { get; set; }
        [JsonProperty(PropertyName = "datetime2")]
        public string DateTime2 { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; set; }
        [JsonProperty(PropertyName = "urls")]
        public string[] Urls { get; set; }
        [JsonProperty(PropertyName = "html")]
        public string[] Html { get; set; }
    }
}
