using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public int age { get; set; }
        [ForeignKey("School")]
        public int schoolId { get; set; }   
        public virtual School School { get; set; }  
    }
}
