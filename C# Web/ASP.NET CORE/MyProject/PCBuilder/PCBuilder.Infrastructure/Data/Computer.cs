using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Infrastructure.Data
{
    public class Computer
    {
        public Computer()
        {
            Id = Guid.NewGuid();
            Components = new List<Component>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public List<Component> Components { get; set; }
    }
}
