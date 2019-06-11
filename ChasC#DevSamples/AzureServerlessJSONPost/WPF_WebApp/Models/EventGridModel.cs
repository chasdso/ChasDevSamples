using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csc.Res.Generic.TestHarness
{
    public class EventGridModel

    {
        [Newtonsoft.Json.JsonProperty("id")]

        public Guid Id { get; set; }

        [JsonProperty("topic")]

        public string Topic { get; set; }

        [JsonProperty("subject")]

        public string Subject { get; set; }


        [JsonProperty("data")]

        public object Data { get; set; }

        [JsonProperty("eventType")]

        public string EventType { get; set; }

        [JsonProperty("eventTime")]

        public DateTime EventTime { get; set; }

        [JsonProperty("metadataVersion")]

        public long MetadataVersion { get; set; }

        [JsonProperty("dataVersion")]

        public string DataVersion { get; set; }

    }

}