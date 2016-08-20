using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ScaffoldColumn(false)]
        public string ScoreSetStr { get; set; }

        // Not mapped
        [NotMapped]
        public List<int> ScoreSet
        {
            get
            {
                List<int> ret = new List<int>();

                try
                {
                    // Split to individual score integers
                    string[] scores = this.ScoreSetStr.Split(';');
                    foreach (string score in scores)
                    {
                        if (!string.IsNullOrEmpty(score))
                        {
                            ret.Add(Int32.Parse(score));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.Logger.LogError("Failed to parse score set from database string. Details: " + ex.ToString());
                }

                return ret;
            }
            set
            {
                string retStr = "";

                for (int i = 0; i < value.Count; i++)
                {
                    retStr += value[i];
                    if (i != (value.Count - 1)) retStr += ",";
                }

                this.ScoreSetStr = retStr;
            }
        }

    }
}
