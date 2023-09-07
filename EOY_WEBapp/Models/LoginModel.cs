﻿using Newtonsoft.Json;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace EOY_WEBapp.Models
{
    public class LoginModel
    {
		[JsonPropertyName("username")]
		[Required(ErrorMessage = "Username is required.")]
		public string Username { get; set; }

        [JsonPropertyName("password")]
		[Required(ErrorMessage = "Password is required.")]
		public string? Password { get; set; }

    }
}
