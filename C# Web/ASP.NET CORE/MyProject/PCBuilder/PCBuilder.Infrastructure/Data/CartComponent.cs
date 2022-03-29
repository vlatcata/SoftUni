using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Infrastructure.Data
{
    public class CartComponent
    {
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        public Guid CartId { get; set; }

        [ForeignKey(nameof(ComponentId))]
        public Component Component { get; set; }
        public Guid ComponentId { get; set; }
    }
}
