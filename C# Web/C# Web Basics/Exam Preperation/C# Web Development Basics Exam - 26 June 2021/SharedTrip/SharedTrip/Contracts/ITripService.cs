using SharedTrip.Models;
using SharedTrip.Models.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(TripViewModel model);
        void AddTrip(TripViewModel model);
        IEnumerable<TripListViewModel> GetAlTrips();
        TripDetailsViewModel GetTripDetails(string tripId);
        void AddUserToTrip(string tripId, string id);
    }
}
