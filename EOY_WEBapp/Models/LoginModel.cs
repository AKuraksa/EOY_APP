using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace EOY_WEBapp.Models
{
    public class LoginModel
    {
       
        [JsonPropertyName("id")]
        public Guid id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("permission")]
        public bool Permission { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

    }
}
