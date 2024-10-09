using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table(nameof(Student))]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [MaxLength(250)]
        public string LastName { get; set; }

        public DateTime DateOfBith { get; set; }

        public ICollection<StudentCourseMapping> StudentCourseMappings { get; set; }
    }
}
