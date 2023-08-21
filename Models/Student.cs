using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public List<Course> Courses { get; set; }
        
    }
}
