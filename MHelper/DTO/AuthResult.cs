using System;
using Newtonsoft.Json;

namespace MHelper.DTO
{
    public class AuthResult
    {
        [JsonProperty("authenticated")]
        public bool IsAuthenticated { get; set; }

        [JsonProperty("user")]
        public string Login { get; set; }
    }
}
