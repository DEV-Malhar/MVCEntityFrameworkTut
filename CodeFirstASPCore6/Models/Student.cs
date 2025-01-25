using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstASPCore6.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student ID")]
        public int StdId { get; set; }
        [Column("StudentName",TypeName ="varchar(100)"),Display(Name ="Name")]
        public string StdName { get; set; }
        [Column("StudentGender", TypeName = "varchar(20)"),Display(Name = "Gender")]
        public string StdGender { get; set; }
        [Display(Name = "Age")]
        public int StdAge { get; set; }
        [Display(Name = "Class")]
        public int StdStd { get; set; }
    }
}
