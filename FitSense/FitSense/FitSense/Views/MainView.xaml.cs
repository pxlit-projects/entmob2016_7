using FitSense.Dependencies;
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
    public partial class MainView : ContentPage
    {
        public MainViewModel viewModel { get; private set; }
        private IUserDataService userDataService;
        public MainView()
        {
            InitializeComponent();
            viewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
            userDataService = ServiceLocator.Current.GetInstance<IUserDataService>();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (userDataService.LoggedInUser == null)
                //viewModel.LoadCommand.Execute(null);
        }
    }
}
