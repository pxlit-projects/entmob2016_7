using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitsense.DAL.dependencies
{
    public interface IUserRepository
    {
        User SearchUser(string userName);
    }
}
