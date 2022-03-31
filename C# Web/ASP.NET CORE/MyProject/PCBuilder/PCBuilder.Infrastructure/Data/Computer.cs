using System.ComponentModel.DataAnnotations;

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
        public string UserId { get; set; }

        [Required]
        public List<Component> Components { get; set; }
    }
}
