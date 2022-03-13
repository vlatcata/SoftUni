using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Infrastructure.Data
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public decimal TotalPrice => Components.Sum(c => c.Price);

        public List<Component> Components { get; set; }
    }
}
