using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.fitsense.mocks
{
    public class UserRepositoryMock
    {
        public User SearchUser(string userName)
        {
            return new User { Name = "Daniel" };
        }
    }
}
