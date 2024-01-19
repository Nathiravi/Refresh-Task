using System;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class Login
    {
    [Required(ErrorMessage = "UserName can't be empty")]
    public string? Username { get; set; } 

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; } 
    }
}