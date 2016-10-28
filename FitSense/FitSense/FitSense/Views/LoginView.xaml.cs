using FitSense.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FitSense.Views
{
    public partial class LoginView : ContentPage
    {
        //private LoginViewModel viewModel;

        public LoginView()
        {
            InitializeComponent();
            //viewModel = ServiceLocator.Current.GetInstance<LoginViewModel>();

            //this.BindingContext = viewModel;

            
        }
    }
}
