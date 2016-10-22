using FitSense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.Dependencies
{
    public interface IUserDataService
    {
        User SearchUser(string userName);

        Task LoginAsync(string userName, string password);

        User LoggedInUser { get; set; }
    }
}
