using RestSharp;
using System.Runtime.CompilerServices;

namespace EOY_WEBapp.Models
{
    public class LoginModel
    {
       
            public string Username { get; set; }
            public string Password { get; set; }
          
        

        async void GetLogin(string username, string password)
        {
            var myClient = new RestClient();
            var request = new RestRequest();
            request.AddQueryParameter("username", username);
        }
    }
}
