using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwp_fitsense.dependencies
{
    public interface INavigationService
    {
        Type NavigateTo(String destination);
        void NavigateFromLoginToApplication();
    }
}
