﻿using System;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RestSharp;

namespace EOY_WEBapp.Dto
{
    public class LoginDto
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
