using System;
using System.ComponentModel.DataAnnotations;

namespace Vidisc2.Models
{
    public class Scorecard
    {
        public Scorecard()
        {

        }

        public int ScorecardId { get; set; }
        public int PlayerId { get; set; }
        public int RoundId { get; set; }
        [Required]
        public Player Player { get; set; }
        [Required]
        public Round Round { get; set; }
        [Required]
        public string ScoreSet { get; set; }
        
    }
}
