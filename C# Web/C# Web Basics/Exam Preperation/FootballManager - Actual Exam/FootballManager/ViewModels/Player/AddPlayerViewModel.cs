using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.Player
{
    public class AddPlayerViewModel
    {
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Username must be between {2} and [1} characters long")]
        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Position must be between {2} and {1} characters long")]
        public string Position { get; set; }

        [Range(0, 10, ErrorMessage = "Speed must be between 0 and 10")]
        public byte Speed { get; set; }

        [Range(0, 10, ErrorMessage = "Endurance must be between 0 and 10")]
        public byte Endurance { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot be more than 200 characters")]
        public string Description { get; set; }
    }
}
