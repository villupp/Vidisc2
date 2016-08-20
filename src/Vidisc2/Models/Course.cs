using System;
using System.ComponentModel.DataAnnotations;

namespace Vidisc2.Models
{
    public class Course
    {
        public Course()
        {

        }

        public int CourseId { get; set; }
        [Required]
        public string Holes { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
