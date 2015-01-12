using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Student
    {

        
        public int StudentId { get; set; }

        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength =4)]
        [Required(ErrorMessage = "*** Please input the student's name")]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength =2)]
        [Required(ErrorMessage = "*** Please  input the student's department name")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(18, MinimumLength = 2)]
        [Required(ErrorMessage = "*** Please input the student's department roll")]
        [Display(Name = "Department Roll ")]
        public string DepartmentRoll { get; set; }

        [DataType(DataType.Text)]
        [StringLength(18, MinimumLength = 2)]
        [Required(ErrorMessage = "*** Please  input the student's academic year")]
        [Display(Name = "Academic Year ")]
        public string AcademicYear { get; set; }

        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 2)]
        [Required(ErrorMessage = "*** Please input the student's attached  hall name")]
        [Display(Name = "Attached Hall Name ")]
        public string AttachedHallName { get; set; }
    }
}
