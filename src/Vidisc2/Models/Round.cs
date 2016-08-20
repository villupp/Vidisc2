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
        [Required]
        public Course Course { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "One or more scorecards required for a round")]
        public virtual ICollection<Scorecard> Scorecards { get; set; }
    }
}
