using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Regestration:Student
    {
        [DataType(DataType.Text)]
        [StringLength(10, MinimumLength = 10)]
        [Required(ErrorMessage = "*** Please input a card number")]
        [Display(Name = "Card Number")]
        public string CardNumber{ get; set; }
    }
}
