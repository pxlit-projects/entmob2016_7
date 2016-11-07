

using System;
using System.Collections.Generic;
using Fitsense.Models;
using FitSense_UWP.Services;
using FitSense.DAL;

namespace FitSenseTest.mocks
{
    class FitDataServiceMock : IFitDataService
    {
        private ICategoryRepository categoryRepository = new MockCategoryRepository();
        private IExerciseRepository exerciseRepository = new MockExerciseRepository();

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetCategories();
        }

        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            throw new NotImplementedException();
        }

        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            return exerciseRepository.GetExercisesFromCategory(category);
        }

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public Set ToggleSelectedSetVisibility(Set set)
        {
            throw new NotImplementedException();
        }
    }
}
