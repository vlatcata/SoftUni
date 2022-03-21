using PCBuilder.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Core.Models.Cart
{
    public class AddComponentViewModel
    {
        public CategoryName Category { get; set; }

        public string? Model { get; set; }

        public string? Manufacturer { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public List<SpecificationsViewModel>? Specifications { get; set; } = new List<SpecificationsViewModel>();
    }
}
