using SMS.Models.Product;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool isCreated, string error) CreateProduct(CreateProductViewModel model);
        IEnumerable<ProductListViewModel> GetProducts();
    }
}
