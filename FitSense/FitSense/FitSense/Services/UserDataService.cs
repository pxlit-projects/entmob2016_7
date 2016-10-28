using FitSense.Dependencies;
using FitSense.Models;
using FitSense.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Services
{
    public class UserDataService : IUserDataService
    {
        private static UserRepository userRepository = new UserRepository();

        public User LoggedInUser { get; set; }

        public UserDataService()
        {

        }

        public Task LoginAsync(string userName, string password)
        {
            return Task.Factory.StartNew(() =>
            {
                LoggedInUser = new User { UserName = userName };
            });
        }

        public User SearchUser(string userName)
        {
            return userRepository.SearchUser(userName);
        }
    }
}
