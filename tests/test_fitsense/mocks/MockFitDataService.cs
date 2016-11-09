using fitsense.DAL.dependencies;
using fitsense.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uwp_fitsense.dependencies;

namespace test_fitsense.mocks
{
    public class MockFitDataService : IFitDataService
    {
        private ICategoryRepository categoryRepository = new MockCategoryRepository();
        private IExerciseRepository exerciseRepository = new MockExerciseRepository();
        private ISetRepository setRepository = new MockSetRepository();
        private ICompletedSetRepository completedSetRepository = new MockCompletedSetRepository();

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetCategories();
        }

        public List<CompletedSet> GetCompletedSetsFromSet(Set set)
        {
            return completedSetRepository.GetCompletedSetsFromSet(set);
        }

        public List<Exercise> GetExercisesFromCategory(Category category)
        {
            List<Exercise> exercises = exerciseRepository.GetExercisesFromCategory(category);
            foreach (Exercise e in exercises)
            {
                e.Sets = GetSetsFromExercise(e);
            }
            return exercises;
        }

        public List<Set> GetSetsFromExercise(Exercise exercise)
        {
            List<Set> sets = setRepository.GetSetsFromExercise(exercise);
            foreach (Set s in sets)
            {
                s.CompletedSets = GetCompletedSetsFromSet(s);
            }
            return sets;
        }

        public Set ToggleSelectedSetVisibility(Set set)
        {
            set.ShowCompletedSets = !set.ShowCompletedSets;
            return set;
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}