using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class AddCarViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Model must be between {2} and {1} characters long")]
        public string Model { get; set; }

        public int Year { get; set; }

        public string Image { get; set; }

        [RegularExpression("[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string PlateNumber { get; set; }
    }
}
