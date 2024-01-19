using System;
using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuthentication.Models{
    public class User{
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Username should minimum of 3 characters and maximum of 50 characters" )]
        public string? Username{get;set;}
        [Required(ErrorMessage ="Please enter password")]
        public string? Password{get;set;}
    
    }
}