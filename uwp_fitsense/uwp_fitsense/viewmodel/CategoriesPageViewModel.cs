using fitsense.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using uwp_fitsense.dependencies;
using uwp_fitsense.extensions;
using uwp_fitsense.messages;
using uwp_fitsense.services;
using uwp_fitsense.utility;

namespace uwp_fitsense.viewmodel
{
    public class CategoriesPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SwitchPageCommand { get; set; }
        public ICommand AddCategoryCommand { get; set; }
        private IFitDataService fitDataService;
        private INavigationService navigationService;       

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

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        private Category selectedCategory;
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
            LoadData();        
            LoadMessengerListeners();
            LoadCommands();
        }

        public void LoadData()
        {
            categories = fitDataService.GetAllCategories().ToObservableCollection();
            if (categories.Count > 0)
            {
                SelectedCategory = categories.First();
            }
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
            AddCategoryCommand = new AlwaysRunCommand((Object o) =>
            {
                fitDataService.AddCategory(new Category()
                {
                    Name = "Categorie 2"
                });
            });
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}