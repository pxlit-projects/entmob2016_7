using FitSense.Model;
using FitSense_UWP.Extensions;
using FitSense_UWP.Messages;
using FitSense_UWP.Services;
using FitSense_UWP.Util;
using FitSense_UWP.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitSense_UWP.ViewModel
{
    public class CategoriesPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SwitchPageCommand { get; set; }
        private IFitDataService fitDataService;
        private INavigationService navigationService;

        private ObservableCollection<Category> categories;
        private Category selectedCategory;

        private Type currentPage { get; set; }
        public Type CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                RaisePropertyChanged("CurrentPage");
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }

        public CategoriesPageViewModel(IFitDataService dataService, INavigationService dialogService)
        {
            this.fitDataService = dataService;
            this.navigationService = dialogService;
            categories = fitDataService.GetAllCategories().ToObservableCollection();

            LoadMessengerListeners();          
            LoadCommands();
        }

        private void LoadMessengerListeners()
        {
            Messenger.Default.Register<ChangePage>(this, changePage => CurrentPage = changePage.Page);
        }

        private void LoadCommands()
        {
            SwitchPageCommand = new AlwaysRunCommand((Object o) =>
            {
                Messenger.Default.Send<UpdateSelectedCategory>(new UpdateSelectedCategory() { Category = SelectedCategory });
                CurrentPage = navigationService.NavigateTo(NavigationService.EXERCISES);
            });
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
