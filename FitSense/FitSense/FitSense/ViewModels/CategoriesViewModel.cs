using fitsense.models;
using FitSense.Constants;
using FitSense.Dependencies;
using FitSense.Extensions;
using FitSense.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitSense.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        private IUserDataService userDataService;
        private INavigationService navigationService;

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get
            {
                return categories;
            }
            private set
            {
                ObservableCollection<Category> old = categories;
                categories = value;
                RaisePropertyChanged("Categories", old, value, true);
            }
        }

        public RelayCommand<object> CategorySelectedCommand { get; private set; }

        public CategoriesViewModel(INavigationService navigationService, IUserDataService userDataService)
        {
            this.userDataService = userDataService;
            this.navigationService = navigationService;

            InitializeCommands();
            LoadDataAsync();
        }
       
        private async void LoadDataAsync()
        {
            var result = await new CategoryRepository().GetCategoriesAsync();
            Categories = result.ToObservableCollection();
        }

        private void InitializeCommands()
        {
            CategorySelectedCommand = new RelayCommand<object>(async (item) =>
            {
                await navigationService.PushAsync(PageUrls.EXERCISESVIEW).ContinueWith((antecedent) =>
                {
                    MessengerInstance.Send((item is Category ? (Category)item : null), Messages.CategoryUpdated);
                });
            });
        }
    }
}