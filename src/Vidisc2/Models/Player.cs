using System;
using System.ComponentModel.DataAnnotations;

namespace Vidisc2.Models
{
    public class Player
    {
        public Player()
        {

        }

        public int PlayerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
