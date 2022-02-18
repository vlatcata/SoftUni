using Sms.Data.Common;
using SMS.Contracts;
using SMS.Data.Models;
using SMS.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public UserService(IValidationService _validationService, IRepository _repo)
        {
            validationService = _validationService;
            repo = _repo;
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
                return (false, errorMsg);
            }

            Cart cart = new Cart();

            User user = new User()
            {
                Cart = cart,
                Username = model.Username,
                Email = model.Email,
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
