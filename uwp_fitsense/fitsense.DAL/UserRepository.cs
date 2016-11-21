using fitsense.DAL.dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitsense.models;

namespace fitsense.DAL
{
    public class UserRepository : IUserRepository
    {
        public User SearchUser(string userName)
        {
            return new User { Name = userName };
        }
    }
}
