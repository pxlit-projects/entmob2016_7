using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uwp_fitsense.dependencies;

namespace uwp_fitsense.services
{
    class NavigationService : INavigationService
    {
        public const String EXERCISES = "Exercises";
        public const String SETSPEREXERCISE = "SetsPerExercise";
        public const String LOGIN = "Login";

        public Type NavigateTo(String destination)
        {
            switch (destination)
            {
                case LOGIN:
                    return typeof(LoginPage);
                case EXERCISES:
                    return typeof(Oefeningen);
                case SETSPEREXERCISE:
                    return typeof(SetsPerExercisePage);
                default:
                    return typeof(CategoriesPage);
            }
        }

        public void NavigateFromLoginToApplication()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(CategoriesPage));
        }
    }
}
