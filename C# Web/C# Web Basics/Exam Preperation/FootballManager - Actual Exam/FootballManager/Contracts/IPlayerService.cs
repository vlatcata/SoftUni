using FootballManager.ViewModels.Player;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        (bool isCreated, string error) CreatePlayer(AddPlayerViewModel model);
        IEnumerable<AllPlayersViewModel> GetAll();
        (bool isAdded, string error) AddPlayer(int playerId, string userId);
        IEnumerable<AllPlayersViewModel> GetPlayers(string userId);
        void RemovePlayer(int playerId, string userId);
    }
}
