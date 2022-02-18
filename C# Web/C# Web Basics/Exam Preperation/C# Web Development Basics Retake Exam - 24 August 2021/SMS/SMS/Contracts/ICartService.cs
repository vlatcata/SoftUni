using SMS.Models.Cart;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface ICartService
    {
        IEnumerable<CartDetailsViewModel> GetProducts(string userId);
        IEnumerable<CartDetailsViewModel> AddProduct(string productId, string userId);
        void BuyProducts(string userId);
    }
}
