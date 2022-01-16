using System;
using TinyNotes.Common;
using TinyNotes.DataLayer;

namespace TinyNotes.Domain
{
    public class UserService
    {
        public string RegisterUser(UserRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Password = request.Password
            };

            var dbManager = DbFactory.GetInstance("mongo");

            dbManager.InsertUser(user);
            return "User registered successfully.";
        }
        public User LoginUser(UserRequest request)
        {
            var dbManager = DbFactory.GetInstance("mongo");
            var user = dbManager.GetUser(request.Name, request.Password);
            UserSession.SetUserSession(user.Id);
            return user;
        }
        public string Logout(Guid userId)
        {
            UserSession.RemoveUserSession(userId);
            return "User logged out successfully.";
        }
    }
}
