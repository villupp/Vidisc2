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
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }
    }
}
