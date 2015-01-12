using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class BalanceSheetInput
    {
        [Required(ErrorMessage = "*** Please Select a Starting Date")]
        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime MonthStart { get; set; }


        [Required(ErrorMessage = "*** Please Select an Ending Date")]
        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime MonthEnd { get; set; }

        [Required(ErrorMessage = "*** Please input the unit price")]
        [Display(Name = "Unit price")]
        [Range(10,250, ErrorMessage = "*** Unit price may vary between 10 Taka to and 250 Taka")]
        public int UnitPrice { get; set; }


    }
}
