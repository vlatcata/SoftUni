using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Name must be between {2} and {1}")]
        public string Name { get; set; }

        public string Price { get; set; }
    }
}
