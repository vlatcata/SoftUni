using PCBuilder.Core.Models.Cart;

namespace PCBuilder.Core.Contracts
{
    public interface ICartService
    {
        Task<bool> CreateComponent(AddComponentViewModel model);
        Task<AddComponentViewModel> GenerateDefaultModel();
        List<AddComponentViewModel> GetAllComponents(string name);
    }
}
