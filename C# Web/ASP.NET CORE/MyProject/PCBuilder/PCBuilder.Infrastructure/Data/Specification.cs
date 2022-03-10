using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Infrastructure.Data
{
    public class Specification
    {
        public string Manufacturer { get; set; }

        public DateTime MadeOn { get; set; }

        [ForeignKey(nameof(ComponentId))]
        public Component Component { get; set; }
        public Guid ComponentId { get; set; }
    }
}
