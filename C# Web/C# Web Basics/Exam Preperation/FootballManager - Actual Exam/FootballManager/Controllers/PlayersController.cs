using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels.Player;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(Request request, IPlayerService _playerService) : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response All(AllPlayersViewModel model)
        {
            IEnumerable<AllPlayersViewModel> players = playerService.GetAll();

            return View(new
            {
                Players = players,
                IsAuthenticated = true
            });
        }

        [Authorize]
        public Response Collection()
        {
            var players = playerService.GetPlayers(User.Id);

            return View(new 
            {
                Players = players,
                IsAuthenticated = true
            });
        }

        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddPlayerViewModel model)
        {
            (bool isCreated, string error) = playerService.CreatePlayer(model);

            if (!isCreated)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response AddToCollection(int playerId)
        {
            (bool isAdded, string error) = playerService.AddPlayer(playerId, User.Id);

            if (!isAdded)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response RemoveFromCollection(int playerId)
        {
            playerService.RemovePlayer(playerId, User.Id);

            return Redirect("/Players/Collection");
        }
    }
}
