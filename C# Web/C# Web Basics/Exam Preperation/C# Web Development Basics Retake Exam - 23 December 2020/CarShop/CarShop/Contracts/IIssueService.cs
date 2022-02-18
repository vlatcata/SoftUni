using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface IIssueService
    {
        bool UserCanAccessCar(string userId, string carId);
        object GetCarIssues(string userId, string carId);
    }
}
