namespace PCBuilder.Core.Models.Cart
{
    public class AddComponentViewModel
    {
        public AddComponentViewModel()
        {
            Specifications = new List<SpecificationsViewModel>();
        }

        public Guid Id { get; set; }

        public string Category { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public List<SpecificationsViewModel> Specifications { get; set; }
    }
}
