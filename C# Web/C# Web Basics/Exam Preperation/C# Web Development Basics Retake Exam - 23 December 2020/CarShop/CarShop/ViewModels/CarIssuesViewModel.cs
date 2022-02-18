using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CarIssuesViewModel
    {
        public int Year { get; set; }

        public string Model { get; set; }

        public string Id { get; set; }

        public bool UserIsMechanic { get; set; }

        public IEnumerable<IssueListingViewModel> Issues { get; set; }
    }
}
