using System.Text.Json.Serialization;

namespace EOY_WEBapp.Models
{
    public class IssueModels
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
