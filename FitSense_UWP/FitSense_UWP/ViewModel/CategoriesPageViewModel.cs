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
        private MessagingService messagingService;

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

        public CategoriesPageViewModel(IFitDataService dataService, INavigationService dialogService, MessagingService messagingService)
        {
            this.fitDataService = dataService;
            this.navigationService = dialogService;
            this.messagingService = messagingService;
            categories = fitDataService.GetAllCategories().ToObservableCollection();
            LoadCommands();
        }

        private void LoadCommands()
        {
            SwitchPageCommand = new CustomCommand((Object o) =>
            {
                messagingService.Category = SelectedCategory;
                Messenger.Default.Send<UpdateSelectedCategory>(new UpdateSelectedCategory());
                CurrentPage = navigationService.NavigateTo(NavigationService.EXERCISES);
            }, (Object o) =>
            {
                return true;
            });
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
