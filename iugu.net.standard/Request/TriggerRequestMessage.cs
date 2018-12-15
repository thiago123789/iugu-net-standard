using Newtonsoft.Json;

namespace iugu.net.standard.Request
{
    public class TriggerRequestMessage
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("authorization")]
        public string Authorization { get; set; }
        [JsonProperty("event")]
        public string Event { get; set; }
    }
}