using FitSense.Dependencies;
using FitSense.Models;
using FitSense.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitsense.models;

namespace FitSense.Services
{
    public class UserDataService : IUserDataService
    {
        private static UserRepository userRepository = new UserRepository();

        private DummyRepository dummyRepository;

        public User LoggedInUser { get; set; }

        User IUserDataService.LoggedInUser
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public UserDataService(DummyRepository dummyRepository)
        {
            this.dummyRepository = dummyRepository;
        }

        public Task LoginAsync(string userName, string password)
        {
            return Task.Factory.StartNew(() =>
            {
                LoggedInUser = new User { Name = userName };
            });
        }

        public fitsense.models.User SearchUser(string userName)
        {
            return userRepository.SearchUser(userName);
        }

        User IUserDataService.SearchUser(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            return dummyRepository.GetAllCategories().ToList();
        }
    }
}
