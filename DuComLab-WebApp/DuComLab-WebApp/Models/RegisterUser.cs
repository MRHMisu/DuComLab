using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessLayer
{
    
    public class RegisterUser:Login
    {
        [Required(ErrorMessage = "*** Please input a the new admin's name")]
        [Display(Name = "Admin name")]
        [DataType(DataType.Text)]
        [StringLength(28, MinimumLength =4)]
        public string Name { get; set; }
    }
}