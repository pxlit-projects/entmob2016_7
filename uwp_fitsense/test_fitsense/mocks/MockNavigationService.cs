using System;
using uwp_fitsense.dependencies;

namespace test_fitsense.mocks
{
    public class MockNavigationService : INavigationService
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
                    return typeof(ExercisesPage);
                case SETSPEREXERCISE:
                    return typeof(SetsPerExercisePage);
                default:
                    return typeof(CategoriesPage);
            }
        }

        public void NavigateFromLoginToApplication()
        {
            throw new NotImplementedException();
        }
    }
}
