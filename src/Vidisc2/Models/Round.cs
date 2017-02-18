using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public virtual ICollection<Scorecard> Scorecards { get; set; }
        [NotMapped]
        public string PlayerIdsStr { get; set; }
    }
}
