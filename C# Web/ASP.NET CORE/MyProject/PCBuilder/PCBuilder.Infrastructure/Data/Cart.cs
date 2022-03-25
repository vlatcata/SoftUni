using PCBuilder.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCBuilder.Infrastructure.Data
{
    public class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid();
            Components = new List<Component>();
            TotalPrice = Components.Sum(c => c.Price);
        }

        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "Money")]
        public decimal TotalPrice { get; set; }

        public List<Component> Components { get; set; }
    }
}
