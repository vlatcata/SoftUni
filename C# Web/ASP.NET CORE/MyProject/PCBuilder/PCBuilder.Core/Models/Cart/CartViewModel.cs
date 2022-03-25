namespace PCBuilder.Core.Models.Cart
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            TotalPrice = Components.Sum(c => c.Price);
        }

        public Guid CartId { get; set; } = Guid.NewGuid();

        public decimal TotalPrice { get; set; }

        public List<AddComponentViewModel>? Components { get; set; } = new List<AddComponentViewModel>();
    }
}
