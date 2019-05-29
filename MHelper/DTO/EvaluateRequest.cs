using System;
using Newtonsoft.Json;

namespace MHelper.DTO
{
    public class EvaluateRequest
    {
        [JsonProperty("expression")]
        public string Expression { get; set; }

        [JsonProperty("functionality")]
        public string Functionality { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }
    }
}
