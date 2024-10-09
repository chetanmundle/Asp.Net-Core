using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class StudentCourseMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MappingId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
