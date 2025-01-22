using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstASPCore6.Models
{
    public class Student
    {
        [Key]
        public int StdId { get; set; }
        [Column("StudentName",TypeName ="varchar(100)")]
        public string StdName { get; set; }
        [Column("StudentGender", TypeName = "varchar(20)")]
        public string StdGender { get; set; }
        public int StdAge { get; set; }
        public int StdStd { get; set; }
    }
}
