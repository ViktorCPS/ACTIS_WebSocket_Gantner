using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace GAT.Core.Devices.Gen7
{

    public class Envelope
    {
        public string Cmd { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes MT { get; set; }
        //public JObject Data { get; set; }
        public JObject Data { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? TID { get; set; } = null;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string GID { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public byte? State { get; set; } = null;

        public enum MessageTypes
        {
            Evt,
            Req,
            Rsp
        }


    }
}
