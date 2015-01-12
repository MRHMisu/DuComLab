using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class CardInput
    {

        [Required(ErrorMessage = "*** Please select card generating date")]
        [Display(Name = "Card Generating Date")]
        [DataType(DataType.Date)]
        public DateTime GeneratingDate { get; set; }

        [Required(ErrorMessage = "*** Please input desired number of cards")]
        [Display(Name = "Number of Cards")]
        [Range(500,2000,ErrorMessage="*** Please input a number between 500 and 2000")]
        public int NumberOfCards { get; set; }
    }
}
