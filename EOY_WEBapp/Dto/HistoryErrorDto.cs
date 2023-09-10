using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RestSharp;

namespace EOY_WEBapp.Dto
{
    public class HistoryErrorDto
    {

        [JsonPropertyName("id")]
        public Guid id { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("typeError")]
        public string TypeError { get; set; }
        [JsonPropertyName("workPlace")]
        public string Workplace { get; set; }
        

    }

}
