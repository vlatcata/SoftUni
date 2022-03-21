using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Core.Models.Cart
{
    public class CartViewModel
    {
        public decimal TotalPrice => Components.Sum(c => c.Price);

        public List<AddComponentViewModel>? Components { get; set; } = new List<AddComponentViewModel>();
    }
}
