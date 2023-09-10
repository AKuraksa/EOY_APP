using System.Text.Json.Serialization;

namespace EOY_WEBapp.Models
{
    public class WorkerModel
    {
        [JsonPropertyName("id")]
        public Guid ID { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("updated")]
        public DateTime? Updated { get; set; }
        [JsonPropertyName("workerFirstName")]
        public string WorkerFirstName { get; set; }
        [JsonPropertyName("workerLastName")]
        public string WorkerLastName { get; set; }
        [JsonPropertyName("authentificatorID")]
        public string AuthentificatorID {get; set;}
        [JsonPropertyName("loggedWorkplace")]
        public string? LoggedWorkplace { get;set;}


    }
}
