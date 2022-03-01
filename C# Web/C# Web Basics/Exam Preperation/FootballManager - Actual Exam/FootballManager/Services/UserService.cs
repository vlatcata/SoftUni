using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public string GetUsername(string userId)
        {
            return repo.All<User>()
                .FirstOrDefault(u => u.Id == userId).Username;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .FirstOrDefault(u => u.Username == model.Username && u.Password == CalculateHash(model.Password));

            return user?.Id;
        }

        public (bool isRegistered, string error) Register(RegisterViewModel model)
        {
            bool isRegistered = false;
            string error = null;

            var (isValid, errorMsg) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, errorMsg);
            }

            User user = new User()
            {
                Email = model.Email,
                Username = model.Username,
                Password = CalculateHash(model.Password),
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                isRegistered = true;
            }
            catch (Exception)
            {
                error = "Unknown error";
            }

            return (isRegistered, error);
        }

        private string CalculateHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
