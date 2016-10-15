using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense_UWP.Services
{
    public interface IDialogService
    {
        void CloseLoginDialog();
        void OpenLoginDialog();
    }
}
