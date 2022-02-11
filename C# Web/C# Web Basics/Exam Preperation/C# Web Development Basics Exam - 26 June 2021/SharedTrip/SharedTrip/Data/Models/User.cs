using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserTrips = new List<UserTrip>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20), MinLength(6)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
