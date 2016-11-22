using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks
{
    public class UserRepositoryMock : IUserRepository
    {

        public User SearchUser(string userName)
        {
            return new User { Name = userName };
        }
    }
}
