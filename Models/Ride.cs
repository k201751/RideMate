using System;
using System.ComponentModel.DataAnnotations;

namespace RideMate.Models
{
    public class Ride
    {
        public int Id { get; set; }

        [Required]
        public string StartingLocation { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        [Range(1, 10)] // Make sure this is within a reasonable range
        public int AvailableSeats { get; set; }
    }
}
