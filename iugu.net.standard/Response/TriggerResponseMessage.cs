using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace iugu.net.standard.Response
{
    public class TriggerResponseMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("authorization")]
        public string Authorization { get; set; }
        [JsonProperty("event")]
        public string Event { get; set; }
    }
}
