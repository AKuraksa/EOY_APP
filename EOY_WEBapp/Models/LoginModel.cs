using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EOY_WEBapp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Uživatelské jméno je povinné.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Heslo je povinné.")]
        public string Password { get; set; }

    }
}
