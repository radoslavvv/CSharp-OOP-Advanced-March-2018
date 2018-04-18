using System;
using System.Linq;
using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    public class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool userNameIsValid = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool passwordIsValid = !string.IsNullOrWhiteSpace(username) && password.Length > 3;

            if (!userNameIsValid || !passwordIsValid)
            {
                throw new ArgumentException("Username or password must be longer than 3 symbols!");
            }

            bool userAlreadyExists = this.forumData.Users.Any(u => u.Username == username);

            if (userAlreadyExists)
            {
                throw new InvalidOperationException("Username is already taken!");
            }

            int userId = this.forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password);

            forumData.Users.Add(user);
            forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }

        public bool TryLogInUser(string username, string password)
        {
            bool userNameIsValid = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool passwordIsValid = !string.IsNullOrWhiteSpace(username) && password.Length > 3;

            if (!userNameIsValid || !passwordIsValid)
            {
                throw new ArgumentException("Username or password must be longer than 3 symbols!");
            }

            User user = this.forumData.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if(user == null)
            {
                return false;
            }

            this.session.Reset();
            this.session.LogIn(user);

            return true;
        }

        public string GetUserName(int userId)
        {
            User user = this.forumData.Users.FirstOrDefault(u => u.Id == userId);

            return user.Username;
        }

        public User GetUserById(int userId)
        {
            User user = this.forumData.Users.FirstOrDefault(u => u.Id == userId);

            return user;
        }
    }
}
