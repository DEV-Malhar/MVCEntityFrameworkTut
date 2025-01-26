using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseFirstASPCore6.Models;

public partial class Student
{
    [Key,Display(Name ="Id")]
    public int StdId { get; set; }
    [Required,Display(Name = "Name")]
    public string StudentName { get; set; }
    [Display(Name = "Gender")]
    public string StudentGender { get; set; }
    [Display(Name = "Age")]
    public int StdAge { get; set; }
    [Display(Name = "Class")]
    public int StdStd { get; set; }
}
