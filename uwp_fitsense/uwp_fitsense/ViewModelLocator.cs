using fitsense.DAL;
using uwp_fitsense.dependencies;
using uwp_fitsense.services;
using uwp_fitsense.viewmodel;

namespace uwp_fitsense
{
    public class ViewModelLocator
    {
        private static IFitDataService dataService = new FitDataService(
            new CategoryRepository(), new ExerciseRepository(), new SetRepository(), new CompletedSetRepository());
        private static INavigationService navigationService = new NavigationService();

        private SetsPerExerciseViewModel setsPerExerciseViewModel = new SetsPerExerciseViewModel(dataService, navigationService);
        public SetsPerExerciseViewModel SetsPerExerciseViewModel
        {
            get { return setsPerExerciseViewModel; }
            set { setsPerExerciseViewModel = value; }
        }

        private LoginViewModel loginViewModel = new LoginViewModel(navigationService);//, LoginService.Instance);
        public LoginViewModel LoginViewModel
        {
            get { return loginViewModel; }
            set { loginViewModel = value; }
        }

        private CategoriesPageViewModel categoriesPageViewModel = new CategoriesPageViewModel(dataService, navigationService);
        public CategoriesPageViewModel CategoriesPageViewModel
        {
            get { return categoriesPageViewModel; }
            set { categoriesPageViewModel = value; }
        }

        private ExercisesViewModel exercisesViewModel = new ExercisesViewModel(dataService, navigationService);
        public ExercisesViewModel ExercisesViewModel
        {
            get { return exercisesViewModel; }
            set { exercisesViewModel = value; }
        }
    }
}