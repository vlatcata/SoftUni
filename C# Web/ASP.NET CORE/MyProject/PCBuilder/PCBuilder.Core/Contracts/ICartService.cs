using PCBuilder.Core.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Core.Contracts
{
    public interface ICartService
    {
        Task<bool> CreateComponent(AddComponentViewModel model);
        Task<AddComponentViewModel> GenerateDefaultModel();
    }
}
