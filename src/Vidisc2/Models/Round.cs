using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidisc2.Models
{
    public class Round
    {
        public Round()
        {
            this.Scorecards = new List<Scorecard>();
        }

        public int RoundId { get; set; }
        public int CourseId { get; set; }
        [Required]
        public Course Course { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public virtual ICollection<Scorecard> Scorecards { get; set; }
    }
}
