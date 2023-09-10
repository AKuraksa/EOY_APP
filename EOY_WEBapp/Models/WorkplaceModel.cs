using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EOY_WEBapp.Models
{
    public class WorkplaceModel
    {
        [JsonPropertyName("id")]
        public Guid ID { get; set; }
        [JsonPropertyName("workplaceName")]
        public string WorkplaceName { get; set; }
        [JsonPropertyName("ip")]
        public string Ip { get; set; }
        [JsonPropertyName("mac")]
        public string Mac { get; set; }
        [JsonPropertyName("state")]
        public bool State { get; set; }
        [JsonPropertyName("deviceName")]
        public string DeviceName { get; set; }
        [JsonPropertyName("getHELP")]
        public bool GetHELP { get; set; }
        [JsonPropertyName("getINFO")]
        public bool GetINFO { get; set; }
        [JsonPropertyName("userLogged")]
        public string? UserLogged { get; set; }
    }
}
