using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class School
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
