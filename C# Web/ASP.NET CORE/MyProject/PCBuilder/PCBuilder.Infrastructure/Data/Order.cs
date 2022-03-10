using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCBuilder.Infrastructure.Data
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(ComponentId))]
        public Component Component { get; set; }
        public Guid ComponentId { get; set; }

        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }

        public decimal Price => Component.Price * Quantity;
    }
}
