using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessLayer
{
    public class HistoryInput
    {

        [Required (ErrorMessage="*** Please select a starting date")]
        [Display (Name="Starting Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "*** Please select an ending date")]
        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}