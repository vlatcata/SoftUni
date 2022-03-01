using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Player;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public PlayerService(IValidationService _validationService, IRepository _repo)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool isAdded, string error) AddPlayer(int playerId, string userId)
        {
            bool isAdded = false;
            string error = null;

            var player = repo.All<Player>()
                .Where(p => p.Id == playerId)
                .FirstOrDefault();

            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .ThenInclude(u => u.Player)
                .FirstOrDefault();

            if (player == null || user == null)
            {
                return (false, "Player or User not found");
            }

            bool isPlayerInCollection = user.UserPlayers.Any(x => x.Player == player);

            if (isPlayerInCollection)
            {
                return (false, "Player already in collection");
            }

            user.UserPlayers.Add(new UserPlayer()
            {
                PlayerId = playerId,
                UserId = userId,
                Player = player,
                User = user
            });

            try
            {
                repo.SaveChanges();
                isAdded = true;
            }
            catch (Exception)
            { 

            }

            return (isAdded, error);
        }

        public (bool isCreated, string error) CreatePlayer(AddPlayerViewModel model)
        {
            bool isCreated = false;
            string error = null;

            (bool isValid, string errorMsg) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, errorMsg);
            }

            Player player = new Player()
            {
                Description = model.Description,
                Endurance = model.Endurance,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed              
            };

            try
            {
                repo.Add(player);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
                error = "Could not create player";
            }

            return (isCreated, error);
        }

        public IEnumerable<AllPlayersViewModel> GetAll()
        {
            return repo.All<Player>()
                .Select(p => new AllPlayersViewModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Endurance = p.Endurance,
                    FullName= p.FullName,
                    ImageUrl= p.ImageUrl,
                    Position= p.Position,
                    Speed = p.Speed
                });
        }

        public IEnumerable<AllPlayersViewModel> GetPlayers(string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .ThenInclude(u => u.Player)
                .FirstOrDefault();

            return user.UserPlayers
                .Select(u => u.Player)
                .Select(p => new AllPlayersViewModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Endurance= p.Endurance,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed
                });
        }

        public void RemovePlayer(int playerId, string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .ThenInclude(u => u.Player)
                .FirstOrDefault();

            var player = user.UserPlayers
                .Where(x => x.PlayerId == playerId)
                .FirstOrDefault();

            user.UserPlayers.Remove(player);

            repo.SaveChanges();
        }
    }
}
