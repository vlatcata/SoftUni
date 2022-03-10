using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Infrastructure.Data
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
            Components = new List<Component>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        public List<Component> Components { get; set; }
    }
}
