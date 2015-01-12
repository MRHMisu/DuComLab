using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessLayer
{
    public class Login
    {
        [Required(ErrorMessage = "*** Please input  valid email address")]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(28, MinimumLength = 4)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*** Please input the password")]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }


    }
}