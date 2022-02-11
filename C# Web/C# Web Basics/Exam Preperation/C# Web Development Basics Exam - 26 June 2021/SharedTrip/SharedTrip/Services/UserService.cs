using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = GetUserByUsername(model.Username) != null;

            if (userExists)
            {
                throw new ArgumentException("Registration failed");
            }

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password
            };

            //Does not work for some reason
            //user.Password = HashPassword(model.Password);

            repo.Add(user);
            repo.SaveChanges();
        }

        private User GetUserByUsername(string username)
        {
            return repo.All<User>().FirstOrDefault(u => u.Username == username);
        }

        private string HashPassword(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.Username == null || model.Username.Length < 5 || model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username doesn't meet the requirements (between 5 and 20 characters long)"));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required"));
            }

            if (model.Password == null || model.Password.Length < 6 || model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password doesn't meet the requirements (between 6 and 20 characters long)"));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Passwords don't match"));
            }

            return (isValid, errors);
        }

        public (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model)
        {
            bool isCorrect = false;
            string userId = string.Empty;

            //Does not work
            //HashPassword(model.Username);

            var user = GetUserByUsername(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == model.Password;
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (userId, isCorrect);
        }
    }
}
