using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidisc2.Models
{
    public struct Hole
    {
        public Hole(int par, int length)
        {
            this.Length = length;
            this.Par = par;
        }

        public int Par { get; set; }
        public int Length { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ScaffoldColumn(false)]
        public string HolesStr { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }

        // Not mapped
        [NotMapped]
        public List<Hole> Holes {
            get
            {
                List<Hole> ret = new List<Hole>();

                try
                {
                    // split to par,length
                    string[] holeStrs = this.HolesStr.Split('|');
                    foreach(string holeStr in holeStrs)
                    {
                        string[] holeStrParts = holeStr.Split(';');
                        if (!string.IsNullOrEmpty(holeStrParts[0])
                            && !string.IsNullOrEmpty(holeStrParts[0]))
                        {
                            int par = Int32.Parse(holeStrParts[0]);
                            int length = Int32.Parse(holeStrParts[1]);
                            ret.Add(new Hole(par, length));
                        }   
                    }
                }
                catch(Exception ex)
                {
                    Utils.Logger.LogError("Failed to parse holes from database string. Details: " + ex.ToString());
                }

                return ret;
            }
            set
            {
                string retStr = "";
                foreach (Hole hole in value)
                {
                    retStr += hole.Par + ";" + hole.Length + "|";
                }

                this.HolesStr = retStr;
            }
        }
    }
}

